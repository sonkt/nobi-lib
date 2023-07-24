namespace Nobi.Loging
{
    public class RabbitMQSinksOptions
    {
        #region Properties

        public string ApplicationName { get; set; }

        public bool Enabled { get; set; }

        public string Exchange { get; set; }

        public string ExchangeType { get; set; }

        public string Hostname { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string RouteKey { get; set; }

        public string Username { get; set; }

        #endregion Properties
    }
}
