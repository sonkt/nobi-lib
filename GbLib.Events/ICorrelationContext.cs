namespace GbLib.Events
{
    public interface ICorrelationContext
    {
        #region Properties

        Guid CorrelationId { get; }

        #endregion Properties
    }
}