using GbLib.Base;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqPublisher
    {
        #region Methods

        void Init();

        Task PublishAsync<TEvent>(TEvent _event, ICorrelationContext context)
            where TEvent : IEvent;

        #endregion Methods
    }
}