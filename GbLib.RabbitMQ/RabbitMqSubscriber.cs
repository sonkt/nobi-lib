using GbLib.RabbitMQ.Builders;
using GbLib.RabbitMQ.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace GbLib.RabbitMQ
{
    public class RabbitMqSubscriber<TConfig> : IRabbitMqSubscriber<TConfig>, IDisposable
         where TConfig : RabbitConfig
    {
        #region Fields

        private readonly ILogger<RabbitMqSubscriber<TConfig>> _logger;
        private readonly RabbitUtility _rabbitUtility;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        private readonly TConfig _config;

        #endregion Fields

        #region Constructors

        public RabbitMqSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _config = _serviceProvider.GetService<TConfig>();
            _rabbitUtility = app.ApplicationServices.GetService<RabbitUtility>();
            _channel = new ChanelBuilder(_config).Build();
            _logger = app.ApplicationServices.GetService<ILogger<RabbitMqSubscriber<TConfig>>>();
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

        public IRabbitMqSubscriber<TConfig> SubscribeEvent<TEvent>() where TEvent : IRabbitEvent
        {
            try
            {
                var exchangeName = _rabbitUtility.GetExchangeName<TEvent>();
                var queueName = _rabbitUtility.GetQueueName<TEvent>();
                var routingKey = _rabbitUtility.GetRoutingKey<TEvent>();
                _channel.ExchangeDeclare(exchangeName, _config.Exchange.Type, _config.Exchange.Durable, _config.Exchange.AutoDelete);
                _channel.QueueDeclare(queueName, _config.Queue.Durable, _config.Queue.Exclusive, _config.Queue.AutoDelete ? !_rabbitUtility.IsPublic<TEvent>() ? true : false : false, null);
                _channel.QueueBind(queueName, exchangeName, routingKey);
                _channel.BasicQos(0, _config.PrefetchCount, false);

                var consummerAsync = new AsyncEventingBasicConsumer(_channel);
                consummerAsync.Received += ConsummerAsync_Received<TEvent>;
                _channel.BasicConsume(queueName,
                            autoAck: false,
                            consumer: consummerAsync);
                Console.WriteLine($"[GbLib]: Bắt đầu đợi Event {typeof(TEvent).Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GbLib]: RabbitMQ receiver: Có lỗi khi subscribe event: {typeof(TEvent).Name}. {ex.Message}");
            }
            return this;
        }

        private async Task ConsummerAsync_Received<T>(object sender, BasicDeliverEventArgs @event) where T : IRabbitEvent
        {
            var body = @event.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var eventHandler = _serviceProvider.GetService<IRabbitEventHandler<T>>();
            if (eventHandler != null)
            {
                var dataEvent = JsonConvert.DeserializeObject<T>(message);
                if (dataEvent != null)
                {
                    var resultHandle = await TryHandleAsync(() => eventHandler.HandleAsync(dataEvent));
                    if (resultHandle)
                    {
                        _channel.BasicAck(@event.DeliveryTag, false);
                    }
                    else
                    {
                        _channel.BasicReject(@event.DeliveryTag, _config.EnableRequeue);
                        Console.WriteLine($"[GbLib]: Message chưa được xử lý và đã requeue: {message}");
                    }
                }
                else
                {
                    Console.WriteLine($"[GbLib]: Event không có dữ liệu {message}");
                }
            }
            else
            {
                Console.WriteLine($"[GbLib]: EventHandler không tồn tại {message}");
            }
        }

        private async Task<bool> TryHandleAsync(Func<Task> handle)
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(_config.Retries, i => TimeSpan.FromSeconds(_config.RetryInterval));
            return await retryPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    await handle();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[GbLib]: Có lỗi khi xử ký event {ex.Message}");
                    return false;
                }
            });
        }

        #endregion Methods
    }
}