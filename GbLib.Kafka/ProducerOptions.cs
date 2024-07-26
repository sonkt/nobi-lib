using Confluent.Kafka;

namespace GbLib.Kafka
{
    public class ProducerOptions
    {
        public int BatchSize { get; set; } = 1000000;
        public int RequestTimeoutMs { get; set; } = 30000;
        public int MessageTimeoutMs { get; set; } = 300000;
    }
}