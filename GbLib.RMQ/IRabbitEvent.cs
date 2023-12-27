namespace GbLib.RMQ
{
    public interface IRabbitEvent
    {
        DateTime OccurredOn => DateTime.Now;
    }
}