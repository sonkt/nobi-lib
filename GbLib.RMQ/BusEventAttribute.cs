namespace GbLib.RMQ
{
    public class BusEventAttribute : Attribute
    {
        #region Constructors

        public BusEventAttribute(string _queue, string _routingKey, bool usePublicQueue = true, bool useConfirmSelect = true)
        {
            QueueName = _queue;
            RoutingKey = _routingKey;
            UsePublicQueue = usePublicQueue;
            UseConfirmSelect = useConfirmSelect;
        }

        #endregion Constructors

        #region Properties

        public string QueueName { get; }

        public string RoutingKey { get; }

        public bool UsePublicQueue { get; set; }

        public bool UseConfirmSelect { get; set; }

        #endregion Properties
    }
}