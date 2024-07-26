using Confluent.Kafka;

namespace GbLib.Kafka
{
    public class ConsumerOptions
    {
        public string GroupId { get; set; }
        public bool EnableAutoCommit { get; set; } = true;
        public bool EnableAutoOffsetStore { get; set; } = true;
        public int MaxPollIntervalMs { get; set; } = 300000;
        public int HeartbeatIntervalMs { get; set; } = 3000;
        public int SessionTimeoutMs { get; set; } = 30000;
        public AutoOffsetReset AutoOffsetReset { get; set; } = AutoOffsetReset.Earliest;
    }
}