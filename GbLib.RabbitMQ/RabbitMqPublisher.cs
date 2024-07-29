using GbLib.RabbitMQ.Builders;
using GbLib.RabbitMQ.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GbLib.RabbitMQ
{
    public class RabbitMqPublisher<TConfig> : IRabbitMqPublisher<TConfig>, IDisposable
        where TConfig : RabbitConfig
    {
        #region Fields

        private IModel _channel;
        private readonly ILogger<RabbitMqPublisher<TConfig>> _logger;
        private readonly RabbitUtility _rabbitUtility;
        private readonly TConfig _config;

        #endregion Fields

        #region Constructors

        public RabbitMqPublisher(IApplicationBuilder app)
        {
            _logger = app.ApplicationServices.GetService<ILogger<RabbitMqPublisher<TConfig>>>();
            _rabbitUtility = app.ApplicationServices.GetService<RabbitUtility>();
            _config = app.ApplicationServices.GetService<TConfig>();
            _channel = new ChanelBuilder(_config).Build();
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
            }
            _channel.Dispose();
        }

        #endregion Constructors

        #region Methods

        public Task PublishAsync<T>(T _event)
            where T : IRabbitEvent
        {
            if (_event != null)
            {
                var isConfirm = _rabbitUtility.IsConfirm<T>();
                if (isConfirm)
                {
                    _channel.ConfirmSelect();
                }
                var message = JsonConvert.SerializeObject(_event);
                var key = _rabbitUtility.GetRoutingKey<T>();
                var body = Encoding.UTF8.GetBytes(message);
                var basicProperties = _channel.CreateBasicProperties();
                basicProperties.Persistent = _config.PersistentDeliveryMode;
                var exchangeName = _rabbitUtility.GetExchangeName<T>();
                var countRetry = 0;
                while (_config.RetryInterval >= countRetry)
                {
                    try
                    {
                        _channel.BasicPublish(exchange: exchangeName, routingKey: key, basicProperties: basicProperties, body: body);
                        if (isConfirm)
                        {
                            try
                            {
                                _channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(_config.PublishConfirmTimeout));
                                break;
                            }
                            catch
                            {
                                countRetry++;
                            }
                        }
                        else
                        {
                            countRetry = _config.RetryInterval + 1;
                        }
                    }
                    catch
                    {
                        countRetry++;
                    }
                }
            }
            return Task.CompletedTask;
        }

        #endregion Methods
    }
}