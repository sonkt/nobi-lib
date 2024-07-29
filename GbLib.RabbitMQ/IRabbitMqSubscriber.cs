using GbLib.RabbitMQ.Configurations;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqSubscriber<TConfig>
        where TConfig : RabbitConfig
    {
        #region Methods

        IRabbitMqSubscriber<TConfig> SubscribeEvent<TEvent>()
            where TEvent : IRabbitEvent;

        #endregion Methods
    }
}