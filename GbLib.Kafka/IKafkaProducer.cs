using Confluent.Kafka;
using GbLib.Events;

namespace GbLib.Kafka
{
    /// <summary>
    /// Defines the <see cref="IKafkaProducer" />.
    /// </summary>
    public interface IKafkaProducer<TProducerConf>
        where TProducerConf : ProducerConfig
    {
        #region Methods

        Task<bool> PublishAsync<TEvent>(TEvent _event)
            where TEvent : IEvent;
        #endregion Methods
    }
}