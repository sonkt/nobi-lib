namespace GbLib.RMQ
{
    public interface IRabbitEventHandler<in T> where T : IRabbitEvent
    {
        #region Methods

        Task HandleAsync(T _event);

        #endregion Methods
    }
}