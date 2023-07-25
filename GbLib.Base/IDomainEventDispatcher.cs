namespace GbLib.Base
{
    public interface IDomainEventDispatcher : IDisposable
    {
        #region Methods

        Task Dispatch(IEvent @event);

        #endregion Methods
    }
}
