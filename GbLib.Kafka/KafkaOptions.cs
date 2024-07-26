namespace GbLib.Kafka
{
    public class KafkaOptions
    {
        public bool Enabled { get; set; }
        public ClientOptions ClientOptions { get; set; } = new ClientOptions();
        public ConsumerOptions ConsumerOptions { get; set; } = new ConsumerOptions();
        public ProducerOptions ProducerOptions { get; set; } = new ProducerOptions();
    }
}