namespace GbLib.Base
{
    public interface IEvent
    {
        #region Properties

        string EventMessage { get; }

        int EventType { get; }

        int EventVersion { get; }

        DateTime OccurredOn { get; }

        #endregion Properties
    }
}
