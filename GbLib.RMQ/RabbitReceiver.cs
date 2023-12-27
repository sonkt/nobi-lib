using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace GbLib.RMQ
{
    public class RabbitReceiver<T> : IHostedService
        where T : IRabbitEvent
    {
        private readonly RabbitMqOptions _rabbitMqOptions;
        private readonly RabbitUtility _rabbitUtility;
        private readonly IServiceProvider _serviceProvider;
        private readonly IModel _channel;

        public RabbitReceiver(RabbitMqOptions rabbitMqOptions, IModel chanel, RabbitUtility rabbitUtility, IServiceProvider serviceProvider)
        {
            _rabbitMqOptions = rabbitMqOptions;
            _channel = chanel;
            _rabbitUtility = rabbitUtility;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            SubscribeEvent();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Dispose();
            return Task.CompletedTask;
        }

        private void SubscribeEvent()
        {
            try
            {
                var exchangeName = _rabbitMqOptions.Exchange.Name;
                var queueName = _rabbitUtility.GetQueueName<T>();
                var routingKey = _rabbitUtility.GetRoutingKey<T>();
                _channel.ExchangeDeclare(exchangeName, _rabbitMqOptions.Exchange.Type, _rabbitMqOptions.Exchange.Durable, _rabbitMqOptions.Exchange.AutoDelete);
                _channel.QueueDeclare(queueName, _rabbitMqOptions.Queue.Durable, _rabbitMqOptions.Queue.Exclusive, _rabbitMqOptions.Queue.AutoDelete ? !_rabbitUtility.IsPublic<T>() ? true : false : false, null);
                _channel.QueueBind(queueName, exchangeName, routingKey);

                var consummerAsync = new AsyncEventingBasicConsumer(_channel);
                consummerAsync.Received += ConsummerAsync_Received;
                _channel.BasicConsume(queueName,
                            autoAck: false,
                            consumer: consummerAsync);
                Console.WriteLine($"[GbLib]: Bắt đầu đợi Event {nameof(T)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GbLib]: RabbitMQ receiver: Có lỗi khi subscribe event: {nameof(T)}. {ex.Message}");
            }
        }

        private async Task ConsummerAsync_Received(object sender, BasicDeliverEventArgs @event)
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
                        Console.WriteLine($"[GbLib]: RabbitMQ receiver: Không Reg được EventHandler {nameof(T)}");
                    }
                }
                else
                {
                    Console.WriteLine($"[GbLib]: Event không có dữ liệu {message}");
                }
            }
        }

        private async Task<bool> TryHandleAsync(Func<Task> handle)
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(_rabbitMqOptions.Retries, i => TimeSpan.FromSeconds(_rabbitMqOptions.RetryInterval));
            return await retryPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    await handle();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}