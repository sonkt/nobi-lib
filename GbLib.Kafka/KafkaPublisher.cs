using Confluent.Kafka;
using GbLib.Events;
using GbLib.Extensions;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace GbLib.Kafka
{
    public class KafkaPublisher<TProducerConf> : IKafkaProducer<TProducerConf>, IDisposable
        where TProducerConf : ProducerConfig
    {
        private IProducer<string, string> _producer;
        private readonly ILogger<KafkaPublisher<TProducerConf>> _logger;
        private readonly TProducerConf _producerConfig;

        public KafkaPublisher(ILogger<KafkaPublisher<TProducerConf>> logger, TProducerConf producerConfig)
        {
            _logger = logger;
            _logger = logger;
            _producerConfig = producerConfig;
            _producer = new ProducerBuilder<string, string>(_producerConfig).Build();
        }

        public void Dispose()
        {
            _producer.Dispose();
        }

        public async Task<bool> PublishAsync<TEvent>(TEvent _event) where TEvent : IEvent
        {
            try
            {
                var topic = GetTopic<TEvent>();
                var key = GetKey<TEvent>();
                var jsonData = JsonSerializer.Serialize(_event);
                var message = new Message<string, string> { Key = key, Value = jsonData };

                var cts = new CancellationTokenSource();
                cts.CancelAfter(10000);

                var result = await _producer.ProduceAsync(topic, message, cts.Token);
                if (result.Status == PersistenceStatus.Persisted)
                {
                    return true;
                }
                _logger.LogWarning($"Đẩy data lên Kafka không thành công");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Có lỗi khi đẩy data lên Kafka");
            }
            return false;
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