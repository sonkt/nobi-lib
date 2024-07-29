namespace GbLib.RabbitMQ
{
    public interface IRabbitEvent
    {
        DateTime OccurredOn => DateTime.Now;
    }
}