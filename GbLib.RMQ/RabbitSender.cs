using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GbLib.RMQ
{
    public class RabbitSender<T> where T : IRabbitEvent
    {
        private readonly IModel _channel;
        private readonly RabbitMqOptions _options;
        private readonly RabbitUtility _rabbitUtility;

        public RabbitSender(RabbitMqOptions options, IModel channel, RabbitUtility rabbitUtility)
        {
            _channel = channel;
            _options = options;
            _rabbitUtility = rabbitUtility;
        }

        public void PublishAsync(T entity)
        {
            var isConfirm = _rabbitUtility.IsConfirm<T>();
            if (isConfirm)
            {
                _channel.ConfirmSelect();
            }
            var message = JsonSerializer.Serialize(entity);
            var key = _rabbitUtility.GetRoutingKey<T>();
            var body = Encoding.UTF8.GetBytes(message);
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.Persistent = _options.PersistentDeliveryMode;
            var exchangeName = _rabbitUtility.GetExchangeName<T>();
            var countRetry = 0;
            while (_options.RetryInterval >= countRetry)
            {
                try
                {
                    _channel.BasicPublish(exchange: exchangeName, routingKey: key, basicProperties: basicProperties, body: body);
                    if (isConfirm)
                    {
                        try
                        {
                            _channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(_options.PublishConfirmTimeout));
                            break;
                        }
                        catch
                        {
                            countRetry++;
                        }
                    }
                    else
                    {
                        countRetry = _options.RetryInterval + 1;
                    }
                }
                catch
                {
                    countRetry++;
                }
            }
            Console.WriteLine($"[GbLib]: Đã gửi event {typeof(T).Name}. Routing Key:{key}");
        }
    }
}