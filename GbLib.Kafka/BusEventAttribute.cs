namespace GbLib.Kafka
{
    /// <summary>
    /// Defines the <see cref="BusEventAttribute" />.
    /// </summary>
    public class BusEventAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_exchange">Exchagne Name (RabbitMQ) hoặc Consumer Group(Kafka) </param>
        /// <param name="_queue">Queue Name (RabbitMQ) hoặc Topic (Kafka)</param>
        /// <param name="_routingKey">RoutingKey (RabbitMQ) hoặc Key (Kafka)</param>
        /// <param name="usePublicQueue"></param>
        /// <param name="useConfirmSelect"></param>
        public BusEventAttribute(string _exchange, string _queue, string _routingKey = null, bool usePublicQueue = true, bool useConfirmSelect = true)
        {
            ExchangeName = _exchange;
            QueueName = _queue;
            RoutingKey = _routingKey;
            UsePublicQueue = usePublicQueue;
            UseConfirmSelect = useConfirmSelect;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Exchagne Name (RabbitMQ) hoặc Consumer Group(Kafka) 
        /// </summary>
        public string ExchangeName { get; }

        /// <summary>
        /// Queue Name (RabbitMQ) hoặc Topic (Kafka)
        /// </summary>

        public string QueueName { get; }

        /// <summary>
        /// RoutingKey (RabbitMQ) hoặc Key (Kafka)
        /// </summary>
        public string RoutingKey { get; }

        public bool UsePublicQueue { get; set; }

        public bool UseConfirmSelect { get; set; }

        #endregion Properties
    }
}