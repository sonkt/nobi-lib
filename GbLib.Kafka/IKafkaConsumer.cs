using GbLib.Base;

namespace GbLib.Kafka
{
    public interface IKafkaConsumer
    {
        #region Methods

        IKafkaConsumer ConsumeEvent<TEvent>() where TEvent : IEvent;

        #endregion Methods
    }
}
