namespace GbLib.RabbitMQ
{
    public class RabbitMqOptions
    {
        #region Properties

        public bool Enabled { get; set; }
        public string Namespace { get; set; }
        public string ExchangePrefix { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; }
        public List<string> Hostnames { get; set; }
        public int RequestTimeout { get; set; }
        public int PublishConfirmTimeout { get; set; }
        public int RecoveryInterval { get; set; }
        public bool PersistentDeliveryMode { get; set; }
        public bool AutoCloseConnection { get; set; }
        public bool AutomaticRecovery { get; set; }
        public bool TopologyRecovery { get; set; }
        public ExchangeOption Exchange { get; set; }
        public QueueOption Queue { get; set; }

        #endregion Properties

        public class ExchangeOption
        {
            public bool Durable { get; set; }
            public bool AutoDelete { get; set; }
            public string Type { get; set; }
        }

        public class QueueOption
        {
            public bool AutoDelete { get; set; }
            public bool Durable { get; set; }
            public bool Exclusive { get; set; }
        }
    }
}