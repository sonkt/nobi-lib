using Confluent.Kafka;
using GbLib.Events;

namespace GbLib.Kafka
{
    /// <summary>
    /// Defines the <see cref="IKafkaConsumer" />.
    /// </summary>
    public interface IKafkaConsumer<TConsumerConf>
        where TConsumerConf : ConsumerConfig
    {
        #region Methods

        IKafkaConsumer<TConsumerConf> ConsumeEvent<TEvent>() where TEvent : IEvent;

        #endregion Methods
    }
}