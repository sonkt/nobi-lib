using GbLib.Base;
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
    public class RabbitMqSubscriber : IRabbitMqSubscriber, IDisposable
    {
        #region Fields

        private readonly ILogger<RabbitMqSubscriber> _logger;
        private readonly RabbitUtility _rabbitUtility;
        private readonly RabbitMqOptions _rabbitMqOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnectionFactory _connectionFactory;
        private IModel _channel;
        private IConnection _connection;

        #endregion Fields

        #region Constructors

        public RabbitMqSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _rabbitMqOptions = _serviceProvider.GetService<RabbitMqOptions>();
            _rabbitUtility = app.ApplicationServices.GetService<RabbitUtility>();
            _connectionFactory = app.ApplicationServices.GetService<IConnectionFactory>();
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            if (_rabbitMqOptions.Enabled)
            {
                _logger = app.ApplicationServices.GetService<ILogger<RabbitMqSubscriber>>();
            }
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        #endregion Constructors

        #region Methods

        public IRabbitMqSubscriber SubscribeEvent<TEvent>() where TEvent : IEvent
        {
            var exchange = _rabbitUtility.GetExchangeName<TEvent>();
            var queue = _rabbitUtility.GetQueueName<TEvent>();
            var routingKey = _rabbitUtility.GetRoutingKey<TEvent>();

            // Tạo Exchange
            try
            {
                _channel.ExchangeDeclare(exchange,
                                 type: _rabbitMqOptions.Exchange.Type,
                                 _rabbitMqOptions.Exchange.Durable,
                                 _rabbitMqOptions.Exchange.AutoDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" [!] Exchange {exchange} đã tồn tại.");
            }

            // Tạo Queue
            try
            {
                _channel.QueueDeclare(queue,
                                _rabbitMqOptions.Queue.Durable,
                                _rabbitMqOptions.Queue.Exclusive,
                                _rabbitMqOptions.Queue.AutoDelete ? !_rabbitUtility.IsPublic<TEvent>() ? true : false : false,
                                null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" [!] Queue {queue} đã tồn tại.");
            }
            // Gán queue vào Exchange với Routing Key
            try
            {
                _channel.QueueBind(queue,
                              exchange,
                              routingKey);
                _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" [!] Queue {queue} đã được gán vào exchang {exchange} với routing key {routingKey}.");
            }

            Console.WriteLine($" [*] Waiting for messages from {typeof(TEvent).Name}.");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var eventHandler = _serviceProvider.GetService<IEventHandler<TEvent>>();
                var dataEvent = JsonConvert.DeserializeObject<TEvent>(message);
                var resultHandle = await TryHandleAsync(dataEvent, () => eventHandler.HandleAsync(dataEvent, CorrelationContext.Create(Guid.NewGuid())));
                if (resultHandle)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            try
            {
                _channel.BasicConsume(queue,
                                autoAck: false,
                                consumer: consumer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Consume không thành công!");
            }
            return this;
        }

        private async Task<bool> TryHandleAsync<TMessage>(TMessage message, Func<Task> handle)
        {
            var currentRetry = 0;
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(_rabbitMqOptions.Retries, i => TimeSpan.FromSeconds(_rabbitMqOptions.RetryInterval));

            var messageName = message.GetType().Name;

            return await retryPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    var retryMessage = currentRetry == 0 ? string.Empty : $"Retry: {currentRetry}'.";
                    var messageType = message is IEvent ? "n event" : " command";
                    await handle();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        #endregion Methods
    }
}