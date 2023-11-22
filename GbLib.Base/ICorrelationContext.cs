namespace GbLib.Base
{
    public interface ICorrelationContext
    {
        #region Properties

        Guid CorrelationId { get; }

        #endregion Properties
    }
}