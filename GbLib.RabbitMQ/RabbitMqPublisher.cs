using GbLib.Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GbLib.RabbitMQ
{
    public class RabbitMqPublisher : IRabbitMqPublisher, IDisposable
    {
        #region Fields

        private IModel _channel;
        private IConnection _connection;
        private readonly ILogger<RabbitMqPublisher> _logger;
        private readonly RabbitUtility _rabbitUtility;
        private readonly RabbitMqOptions _rabbitMqOptions;
        private readonly IConnectionFactory _connectionFactory;

        #endregion Fields

        #region Constructors

        public RabbitMqPublisher(RabbitUtility rabbitUtility, ILogger<RabbitMqPublisher> logger, RabbitMqOptions rabbitMqOptions, IConnectionFactory connectionFactory)
        {
            _logger = logger;
            _rabbitUtility = rabbitUtility;
            _rabbitMqOptions = rabbitMqOptions;
            _connectionFactory = connectionFactory;
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public void Init()
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        #endregion Constructors

        #region Methods

        public Task PublishAsync<TEvent>(TEvent _event, ICorrelationContext context)
            where TEvent : IEvent
        {
            _channel.ConfirmSelect();
            var exchange = _rabbitUtility.GetExchangeName<TEvent>();
            var routingKey = _rabbitUtility.GetRoutingKey<TEvent>();
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.Persistent = _rabbitMqOptions.PersistentDeliveryMode;

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_event));
            var countRetry = 0;
            while (_rabbitMqOptions.RetryInterval >= countRetry)
            {
                _channel.BasicPublish(exchange, routingKey, basicProperties, body);
                try
                {
                    _channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(_rabbitMqOptions.RequestTimeout));
                    break;
                }
                catch
                {
                    countRetry++;
                    _logger.LogError($"Dữ liệu đẩy lên Rabbit không thành công. Thử lại lần thứ {countRetry}");
                }
            }
            return Task.CompletedTask;
        }

        #endregion Methods
    }
}