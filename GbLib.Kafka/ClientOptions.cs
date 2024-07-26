using Confluent.Kafka;

namespace GbLib.Kafka
{
    public class ClientOptions
    {
        public bool HasAuth { get; set; } = true;
        public string BootstrapServers { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MessageMaxBytes { get; set; } = 1000000;
        public SaslMechanism SaslMechanism { get; set; } = SaslMechanism.Plain;
        public SecurityProtocol SecurityProtocol { get; set; } = SecurityProtocol.SaslPlaintext;
        public bool SocketKeepaliveEnable { get; set; } = true;
        public int MetadataMaxAgeMs { get; set; } = 900000;
        public int ConnectionsMaxIdleMs { get; set; } = 600000;
        public int ReconnectBackoffMaxMs { get; set; } = 10000;
        public int ReconnectBackoffMs { get; set; } = 10000;
        public bool AllowAutoCreateTopics { get; set; }
    }
}