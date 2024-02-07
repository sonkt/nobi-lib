using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace GbLib.RMQ
{
    public class RabbitUtility
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMqOptions _rabbitMqOptions;
        private readonly string _defaultNamespace;

        public RabbitUtility(IServiceProvider serviceProvider, RabbitMqOptions options)
        {
            _serviceProvider = serviceProvider;
            _defaultNamespace = options.Exchange.Name;
            _rabbitMqOptions = options;
        }
        public string GetExchangeName<T>()
        {
            var _exchange = typeof(T).GetCustomAttribute<BusEventAttribute>()?.ExchangeName ?? _defaultNamespace;
            return $"{_rabbitMqOptions.Prefix}{_exchange}".ToLowerInvariant();
        }

        public string GetRoutingKey<T>()
        {
            var _routingKey = typeof(T).GetCustomAttribute<BusEventAttribute>()?.RoutingKey ?? typeof(T).Name;
            _routingKey = string.IsNullOrWhiteSpace(_routingKey) ? string.Empty : $"{_routingKey}";
            return $"{_rabbitMqOptions.Prefix}{_routingKey}".ToLowerInvariant();
        }

        public string GetQueueName<T>()
        {
            var name = Dns.GetHostName();
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            var _queue =typeof(T).GetCustomAttribute<BusEventAttribute>()?.QueueName ?? typeof(T).Name;
            var isPublicQueue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
            return isPublicQueue ? $"{_rabbitMqOptions.Prefix}{_queue}".ToLowerInvariant() : $"{_rabbitMqOptions.Prefix}{ip}_{_queue}".ToLowerInvariant();
        }

        public bool IsPublic<T>()
        {
            return typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
        }
        public bool IsConfirm<T>()
        {
            return typeof(T).GetCustomAttribute<BusEventAttribute>()?.UseConfirmSelect ?? true;
        }
    }
}