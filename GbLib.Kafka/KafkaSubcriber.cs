using Confluent.Kafka;
using GbLib.Events;
using GbLib.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;

namespace GbLib.Kafka
{
    public class KafkaSubcriber<TConsumerConf> : IKafkaConsumer<TConsumerConf>, IDisposable
         where TConsumerConf : ConsumerConfig
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ILogger<KafkaSubcriber<TConsumerConf>> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TConsumerConf _consumerConfig;

        public KafkaSubcriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _logger = app.ApplicationServices.GetService<ILogger<KafkaSubcriber<TConsumerConf>>>();
            _consumerConfig = app.ApplicationServices.GetService<TConsumerConf>();
            _consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
        }

        public IKafkaConsumer<TConsumerConf> ConsumeEvent<TEvent>() where TEvent : IEvent
        {
            var cts = new CancellationTokenSource();
            Task.Factory.StartNew(() => StartConsumerLoopAsync<TEvent>(cts.Token));
            return this;
        }

        public void Dispose()
        {
            _consumer.Dispose();
        }

        private void StartConsumerLoopAsync<TEvent>(CancellationToken cancellationToken) where TEvent : IEvent
        {
            var _topic = $"{GetTopic<TEvent>()}";
            var _key = $"{GetKey<TEvent>()}";
            _consumer.Subscribe(_topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult == null || consumeResult.IsPartitionEOF)
                    {
                        continue;
                    }
                    if (consumeResult.Topic != _topic)
                    {
                        continue;
                    }

                    var message = consumeResult?.Message?.Value;
                    var key = consumeResult?.Message?.Key;
                    if (string.IsNullOrEmpty(message) || ((string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(_key))))
                    {
                        continue;
                    }
                    var _event = JsonConvert.DeserializeObject<TEvent>(message);
                    if (_event != null)
                    {
                        var eventHandler = _serviceProvider.GetService<IEventHandler<TEvent>>();
                        var task = Task.Run(async () => await eventHandler.HandleAsync(_event, CorrelationContext.Create(Guid.NewGuid())));
                        task.Wait();
                    }
                }
                catch (OperationCanceledException oce)
                {
                    _logger.LogError(oce, $"Có lỗi khi consume kafka");
                    continue;
                }
                catch (ConsumeException e)
                {
                    _logger.LogError(e, $"Có lỗi khi consume kafka: {e.Error.Reason}");
                    if (e.Error.IsFatal)
                    {
                        break;
                    }
                    continue;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Có lỗi khi consume kafka");
                    break;
                }
                Thread.Sleep(_consumerConfig.HeartbeatIntervalMs != null ? _consumerConfig.HeartbeatIntervalMs.Value : 3000);
            }
        }
        private string GetConsumerGroup<T>()
        {
            var _excName = typeof(T).GetCustomAttribute<BusEventAttribute>()?.ExchangeName ?? $"{typeof(T).GetGenericTypeName()}";
            _excName = string.IsNullOrWhiteSpace(_excName) ? string.Empty : $"{_excName}";

            return $"{_excName}".ToLowerInvariant();
        }

        private string GetTopic<T>()
        {
            var _topicName = typeof(T).GetCustomAttribute<BusEventAttribute>()?.QueueName ?? $"{typeof(T).GetGenericTypeName()}";
            _topicName = string.IsNullOrWhiteSpace(_topicName) ? string.Empty : $"{_topicName}";

            return $"{_topicName}".ToLowerInvariant();
        }

        private string GetKey<T>()
        {
            var _key = typeof(T).GetCustomAttribute<BusEventAttribute>()?.RoutingKey ?? "";
            _key = string.IsNullOrWhiteSpace(_key) ? string.Empty : $"{_key}";

            return $"{_key}".ToLowerInvariant();
        }
    }
}