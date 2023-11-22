using GbLib.Base;

namespace GbLib.Kafka
{
    public interface IKafkaProducer
    {
        #region Methods

        Task<bool> PublishAsync<TEvent>(TEvent _event)
            where TEvent : IEvent;

        #endregion Methods
    }
}