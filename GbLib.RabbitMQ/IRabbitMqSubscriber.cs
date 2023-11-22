using GbLib.Base;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqSubscriber
    {
        #region Methods

        IRabbitMqSubscriber SubscribeEvent<TEvent>()
            where TEvent : IEvent;

        #endregion Methods
    }
}