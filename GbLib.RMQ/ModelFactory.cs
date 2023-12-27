using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.RMQ
{
    public class ModelFactory:IDisposable
    {
        private readonly IConnection _connection;
        private readonly RabbitMqOptions _settings;
        public ModelFactory(IConnectionFactory connectionFactory, RabbitMqOptions settings)
        {
            _settings = settings;
            _connection = connectionFactory.CreateConnection();
        }

        public IModel CreateChannel()
        {
            var channel = _connection.CreateModel();
            channel.ExchangeDeclare(exchange: _settings.Exchange.Name, durable: _settings.Exchange.Durable, autoDelete:_settings.Exchange.AutoDelete, type: _settings.Exchange.Type);
            return channel;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
