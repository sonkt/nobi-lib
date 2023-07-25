using Confluent.Kafka;
using GbLib.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;

namespace GbLib.Kafka
{
    public class KafkaSubcriber : IKafkaConsumer, IDisposable
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ILogger<KafkaSubcriber> _logger;
        private readonly KafkaOptions _kafkaOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConsumerConfig _consumerConfig;
        private readonly string _defaultTopic;

        public KafkaSubcriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _kafkaOptions = _serviceProvider.GetService<KafkaOptions>();
            if (_kafkaOptions.Enabled)
            {
                _logger = app.ApplicationServices.GetService<ILogger<KafkaSubcriber>>();
                _consumerConfig = app.ApplicationServices.GetService<ConsumerConfig>();
                _consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
                _defaultTopic = _kafkaOptions.DefaultTopic;
            }
        }

        public IKafkaConsumer ConsumeEvent<TEvent>() where TEvent : IEvent
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
            var topic = $"{_kafkaOptions.PrefixTopic}{GetTopic<TEvent>()}";
            if (string.IsNullOrEmpty(topic))
            {
                topic = $"{_kafkaOptions.PrefixTopic}{_defaultTopic}";
            }
            _consumer.Subscribe(topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult == null || consumeResult.IsPartitionEOF)
                    {
                        continue;
                    }
                    if (consumeResult.Topic != topic)
                    {
                        continue;
                    }

                    var message = consumeResult?.Message?.Value;
                    var key = consumeResult?.Message?.Key;
                    if (string.IsNullOrEmpty(message) || (string.IsNullOrEmpty(key) && !_kafkaOptions.UseKeyNull))
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
                Thread.Sleep(_kafkaOptions.SleepMs);
            }
        }

        private string GetTopic<T>()
        {
            var _topicName = typeof(T).GetCustomAttribute<BusEventAttribute>()?.TopicName ?? _defaultTopic;
            _topicName = string.IsNullOrWhiteSpace(_topicName) ? string.Empty : $"{_topicName}";

            return $"{_topicName}".ToLowerInvariant();
        }
    }
}
