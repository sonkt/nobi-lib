using GbLib.RabbitMQ.Configurations;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqPublisher<TConfig>
        where TConfig : RabbitConfig
    {
        #region Methods

        Task PublishAsync<TEvent>(TEvent _event)
            where TEvent : IRabbitEvent;

        #endregion Methods
    }
}