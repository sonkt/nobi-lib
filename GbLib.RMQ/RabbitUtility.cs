using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace GbLib.RMQ
{
    public class RabbitUtility
    {
        private readonly IServiceProvider _serviceProvider;

        public RabbitUtility(IServiceProvider serviceProvider, RabbitMqOptions options)
        {
            _serviceProvider = serviceProvider;
        }


        public string GetRoutingKey<T>()
        {
            var options = _serviceProvider.GetService<RabbitMqOptions>();
            var _routingKey = typeof(T).GetCustomAttribute<BusEventAttribute>()?.RoutingKey ?? typeof(T).Name;
            _routingKey = string.IsNullOrWhiteSpace(_routingKey) ? string.Empty : $"{_routingKey}";

            return $"{options?.Exchange.Name}_{_routingKey}".ToLowerInvariant();
        }

        public string GetQueueName<T>()
        {
            var options = _serviceProvider.GetService<RabbitMqOptions>();
            var name = Dns.GetHostName();
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            var _queue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.QueueName ?? typeof(T).Name;
            var isPublicQueue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
            return isPublicQueue ? $"{options?.Exchange.Name}_{_queue}".ToLowerInvariant() : $"{ip}_{options?.Exchange.Name}_{_queue}".ToLowerInvariant();
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