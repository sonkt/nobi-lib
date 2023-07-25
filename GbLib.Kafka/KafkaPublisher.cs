using Confluent.Kafka;
using GbLib.Base;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace GbLib.Kafka
{
    public class KafkaPublisher : IKafkaProducer, IDisposable
    {
        private readonly IProducer<string, string> _producer;
        private readonly ILogger<KafkaPublisher> _logger;
        private readonly KafkaOptions _kafkaOptions;
        private readonly ProducerConfig _producerConfig;
        private readonly string _defaultTopic;

        public KafkaPublisher(ILogger<KafkaPublisher> logger,
            ProducerConfig producerConfig,
            KafkaOptions kafkaOptions
            )
        {
            _logger = logger;
            _logger = logger;
            _producerConfig = producerConfig;
            _kafkaOptions = kafkaOptions;
            _producer = new ProducerBuilder<string, string>(_producerConfig).Build();
            _defaultTopic = _kafkaOptions.DefaultTopic;
        }

        public void Dispose()
        {
            _producer.Dispose();
        }

        public async Task<bool> PublishAsync<TEvent>(TEvent _event) where TEvent : IEvent
        {
            try
            {
                var topic = $"{_kafkaOptions.PrefixTopic}{GetTopic<TEvent>()}";
                var key = GetKey<TEvent>();
                if (string.IsNullOrEmpty(topic))
                {
                    topic = $"{_kafkaOptions.PrefixTopic}{_defaultTopic}";
                }
                var jsonData = JsonSerializer.Serialize(_event);
                var message = new Message<string, string> { Key = _kafkaOptions.UseKeyNull ? null : key, Value = jsonData };

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
            var _topicName = typeof(T).GetCustomAttribute<BusEventAttribute>()?.TopicName ?? _defaultTopic;
            _topicName = string.IsNullOrWhiteSpace(_topicName) ? string.Empty : $"{_topicName}";

            return $"{_topicName}".ToLowerInvariant();
        }

        private string GetKey<T>()
        {
            var _exName = typeof(T).GetCustomAttribute<BusEventAttribute>()?.KeyName ?? _defaultTopic;
            _exName = string.IsNullOrWhiteSpace(_exName) ? string.Empty : $"{_exName}";

            return $"{_exName}".ToLowerInvariant();
        }
    }
}
