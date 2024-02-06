using Autofac;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GbLib.Kafka
{
    public static class Extensions
    {
        public static void BuildContainerKafkaEventBus(this ContainerBuilder builder, Assembly assembly = null)
        {
            builder.RegisterType<KafkaPublisher>().As<IKafkaProducer>().SingleInstance();
            builder.RegisterType<KafkaSubcriber>().As<IKafkaConsumer>().SingleInstance();
        }

        public static IKafkaConsumer KafkaEventBusSubcriber(this IApplicationBuilder app)
          => new KafkaSubcriber(app);

        public static IServiceCollection AddBusKafkaConfig(this IServiceCollection services)
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();

                var _kafkaOptions = new KafkaOptions();
                config.Bind("KafkaOptions", _kafkaOptions);
                services.AddSingleton(_kafkaOptions);

                // Producer Config
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = _kafkaOptions.BootstrapServers,
                    SaslMechanism = SaslMechanism.Plain,
                    SecurityProtocol = SecurityProtocol.SaslPlaintext,
                    SaslUsername = _kafkaOptions.UserName,
                    SaslPassword = _kafkaOptions.Password,
                    MessageMaxBytes = _kafkaOptions.MessageMaxBytes != 0 ? _kafkaOptions.MessageMaxBytes : 40 * 1024 * 1024
                };
                services.AddSingleton(producerConfig);

                // Consumer Config
                var consumerConfig = new ConsumerConfig
                {
                    GroupId = $"{_kafkaOptions.PrefixTopic}{_kafkaOptions.GroupId}",
                    BootstrapServers = _kafkaOptions.BootstrapServers,
                    EnableAutoCommit = true,
                    EnableAutoOffsetStore = true,
                    MaxPollIntervalMs = _kafkaOptions.MaxPollIntervalSeconds * 1000,
                    SocketKeepaliveEnable = true,
                    MetadataMaxAgeMs = 900000,
                    ConnectionsMaxIdleMs = 600000,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    HeartbeatIntervalMs = 3000,
                    SessionTimeoutMs = 30000,
                    ReconnectBackoffMaxMs = 10000,
                    ReconnectBackoffMs = 1000,
                    SaslMechanism = SaslMechanism.Plain,
                    SecurityProtocol = SecurityProtocol.SaslPlaintext,
                    SaslUsername = _kafkaOptions.UserName,
                    SaslPassword = _kafkaOptions.Password,
                };
                services.AddSingleton(consumerConfig);

                return services;
            }
        }
    }
}