namespace GbLib.Events
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