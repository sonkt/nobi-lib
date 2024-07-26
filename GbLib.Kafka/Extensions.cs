using Autofac;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Kafka
{
    public static class Extensions
    {
        /// <summary>
        ///  Đăng ký Publisher cho Kafka
        /// </summary>
        /// <typeparam name="TProducerConf">Cấu hình Producer</typeparam>
        /// <param name="builder"></param>
        public static void RegisterKafkaPublisher<TProducerConf>(this ContainerBuilder builder) where TProducerConf : ProducerConfig
        {
            builder.RegisterType<KafkaPublisher<TProducerConf>>().As<IKafkaProducer<TProducerConf>>().SingleInstance();
        }

        /// <summary>
        /// Đăng ký Kafka Consumer
        /// </summary>
        /// <typeparam name="TConsumerConf">Cấu hình Consumer</typeparam>
        /// <param name="builder"></param>
        public static void RegisterKafkaConsumer<TConsumerConf>(this ContainerBuilder builder) where TConsumerConf : ConsumerConfig
        {
            builder.RegisterType<KafkaSubcriber<TConsumerConf>>().As<IKafkaConsumer<TConsumerConf>>().SingleInstance();
        }

        /// <summary>
        /// kafka Subscriber Invoke
        /// </summary>
        /// <typeparam name="TConsumerConf"></typeparam>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IKafkaConsumer<TConsumerConf> KafkaSubcriber<TConsumerConf>(this IApplicationBuilder app) where TConsumerConf : ConsumerConfig => new KafkaSubcriber<TConsumerConf>(app);

        public static IServiceCollection AddKafkaProducerConfig<TProducerConf>(this IServiceCollection services, string sectionName) where TProducerConf : ProducerConfig, new()
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();
                var _kafkaOptions = new KafkaOptions();
                config.Bind(sectionName, _kafkaOptions);

                if (_kafkaOptions.Enabled)
                {
                    var producerConfig = new TProducerConf();
                    //Producer Options
                    producerConfig.RequestTimeoutMs = _kafkaOptions.ProducerOptions.RequestTimeoutMs;
                    producerConfig.BatchSize = _kafkaOptions.ProducerOptions.BatchSize;
                    producerConfig.MessageTimeoutMs = _kafkaOptions.ProducerOptions.MessageTimeoutMs;
                    // Client Options
                    producerConfig.BootstrapServers = _kafkaOptions.ClientOptions.BootstrapServers;
                    producerConfig.MessageMaxBytes = _kafkaOptions.ClientOptions.MessageMaxBytes;
                    if (_kafkaOptions.ClientOptions.HasAuth)
                    {
                        producerConfig.SaslUsername = _kafkaOptions.ClientOptions.UserName;
                        producerConfig.SaslPassword = _kafkaOptions.ClientOptions.Password;
                        producerConfig.SaslMechanism = _kafkaOptions.ClientOptions.SaslMechanism;
                        producerConfig.SecurityProtocol = _kafkaOptions.ClientOptions.SecurityProtocol;
                    }
                    services.AddSingleton(producerConfig);
                }
                return services;
            }
        }

        public static IServiceCollection AddKafkaConsumerConfig<TConsumerConf>(this IServiceCollection services, string sectionName) where TConsumerConf : ConsumerConfig, new()
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();
                var _kafkaOptions = new KafkaOptions();
                config.Bind(sectionName, _kafkaOptions);

                if (_kafkaOptions.Enabled)
                {
                    var consumerConfig = new TConsumerConf();
                    //Consumer Options
                    consumerConfig.GroupId = $"{_kafkaOptions.ConsumerOptions.GroupId}";
                    consumerConfig.EnableAutoCommit = _kafkaOptions.ConsumerOptions.EnableAutoCommit;
                    consumerConfig.EnableAutoOffsetStore = _kafkaOptions.ConsumerOptions.EnableAutoOffsetStore;
                    consumerConfig.MaxPollIntervalMs = _kafkaOptions.ConsumerOptions.MaxPollIntervalMs;
                    consumerConfig.AutoOffsetReset = _kafkaOptions.ConsumerOptions.AutoOffsetReset;
                    consumerConfig.HeartbeatIntervalMs = _kafkaOptions.ConsumerOptions.HeartbeatIntervalMs;
                    consumerConfig.SessionTimeoutMs = _kafkaOptions.ConsumerOptions.SessionTimeoutMs;
                    // Client Options
                    consumerConfig.BootstrapServers = _kafkaOptions.ClientOptions.BootstrapServers;
                    consumerConfig.MessageMaxBytes = _kafkaOptions.ClientOptions.MessageMaxBytes;
                    consumerConfig.SocketKeepaliveEnable = _kafkaOptions.ClientOptions.SocketKeepaliveEnable;
                    consumerConfig.MetadataMaxAgeMs = _kafkaOptions.ClientOptions.MetadataMaxAgeMs;
                    consumerConfig.ConnectionsMaxIdleMs = _kafkaOptions.ClientOptions.ConnectionsMaxIdleMs;
                    consumerConfig.ReconnectBackoffMaxMs = _kafkaOptions.ClientOptions.ReconnectBackoffMaxMs;
                    consumerConfig.ReconnectBackoffMs = _kafkaOptions.ClientOptions.ReconnectBackoffMs;
                    if (_kafkaOptions.ClientOptions.HasAuth)
                    {
                        consumerConfig.SaslUsername = _kafkaOptions.ClientOptions.UserName;
                        consumerConfig.SaslPassword = _kafkaOptions.ClientOptions.Password;
                        consumerConfig.SaslMechanism = _kafkaOptions.ClientOptions.SaslMechanism;
                        consumerConfig.SecurityProtocol = _kafkaOptions.ClientOptions.SecurityProtocol;
                    }

                    services.AddSingleton(consumerConfig);
                }
            }
            return services;
        }
    }
}