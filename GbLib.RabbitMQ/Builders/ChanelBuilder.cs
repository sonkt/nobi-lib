using GbLib.RabbitMQ.Configurations;
using RabbitMQ.Client;

namespace GbLib.RabbitMQ.Builders
{
    public class ChanelBuilder
    {
        private readonly RabbitConfig _config;
        private readonly IConnectionFactory _connectionFactory;

        public ChanelBuilder(RabbitConfig config)
        {
            _config = config;
            _connectionFactory = new ConnectionFactory
            {
                HostName = _config.Hostnames[0],
                UserName = _config.Username,
                Password = _config.Password,
                AutomaticRecoveryEnabled = _config.AutomaticRecovery,
                Port = _config.Port,
                VirtualHost = string.IsNullOrEmpty(_config.VirtualHost) ? "/" : _config.VirtualHost,
                DispatchConsumersAsync = true
            };
        }

        public IModel Build()
        {
            var connection = _connectionFactory.CreateConnection();
            return connection.CreateModel();
        }
    }
}