namespace GbLib.Kafka
{
    public class KafkaOptions
    {
        public bool Enabled { get; set; }
        public string? BootstrapServers { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int MaxPollIntervalSeconds { get; set; }
        public int SleepMs { get; set; } = 10000;
        public string? DefaultTopic { get; set; }
        public string? PrefixTopic { get; set; }
        public bool UseKeyNull { get; set; } = true;
        public string? GroupId { get; set; }
        public int MessageMaxBytes { get; set; }
    }
}