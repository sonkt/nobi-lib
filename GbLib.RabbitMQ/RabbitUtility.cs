using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace GbLib.RabbitMQ
{
    public class RabbitUtility
    {
        public RabbitUtility()
        {
        }

        public string GetExchangeName<T>(string defaultName = "")
        {
            var _exchange = typeof(T).GetCustomAttribute<BusEventAttribute>()?.ExchangeName ?? defaultName;
            return $"{_exchange}".ToLowerInvariant();
        }

        public string GetRoutingKey<T>()
        {
            var _routingKey = typeof(T).GetCustomAttribute<BusEventAttribute>()?.RoutingKey ?? typeof(T).Name;
            _routingKey = string.IsNullOrWhiteSpace(_routingKey) ? string.Empty : $"{_routingKey}";
            return $"{_routingKey}".ToLowerInvariant();
        }

        public string GetQueueName<T>(string prefix = "")
        {
            var name = Dns.GetHostName();
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            var _queue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.QueueName ?? typeof(T).Name;
            var isPublicQueue = typeof(T).GetCustomAttribute<BusEventAttribute>()?.UsePublicQueue ?? false;
            return isPublicQueue ? $"{prefix}{_queue}".ToLowerInvariant() : $"{prefix}{ip}_{_queue}".ToLowerInvariant();
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