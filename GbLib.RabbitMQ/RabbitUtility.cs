using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace GbLib.RabbitMQ
{
    public class RabbitUtility
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _defaultNamespace;

        public RabbitUtility(IServiceProvider serviceProvider, RabbitMqOptions options)
        {
            _serviceProvider = serviceProvider;
            _defaultNamespace = options.Namespace;
        }

        public string GetExchangeName<T>()
        {
            var options = _serviceProvider.GetService<RabbitMqOptions>();
            var prefix = string.IsNullOrEmpty(options?.ExchangePrefix) ? "" : options.ExchangePrefix;
            var _exchange = typeof(T).GetCustomAttribute<BusEventAttribute>()?.ExchangeName ?? _defaultNamespace;
            return $"{prefix}{_exchange}".ToLowerInvariant();
        }

        public string GetRoutingKey<T>()
        {
            var options = _serviceProvider.GetService<RabbitMqOptions>();
            var prefix = string.IsNullOrEmpty(options?.ExchangePrefix) ? "" : options.ExchangePrefix;
            var _routingKey = typeof(T).GetCustomAttribute<BusEventAttribute>()?.RoutingKey ?? _defaultNamespace;
            _routingKey = string.IsNullOrWhiteSpace(_routingKey) ? string.Empty : $"{_routingKey}";

            return $"{prefix}{_routingKey}".ToLowerInvariant();
        }

        public string GetQueueName<T>()
        {
            var options = _serviceProvider.GetService<RabbitMqOptions>();
            var prefix = string.IsNullOrEmpty(options?.ExchangePrefix) ? "" : options.ExchangePrefix;
            var name = Dns.GetHostName();
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            var _queue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.QueueName ?? _defaultNamespace;
            var isPublicQueue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
            return isPublicQueue ? $"{prefix}{_queue}".ToLowerInvariant() : $"{prefix}{ip}_{_queue}".ToLowerInvariant();
        }

        public bool IsPublic<T>()
        {
            return typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
        }
    }
}