namespace GbLib.Kafka
{
    public class BusEventAttribute : Attribute
    {
        #region Constructors

        public BusEventAttribute(string _keyName, string _topic)
        {
            KeyName = _keyName;
            TopicName = _topic;
        }

        #endregion Constructors

        #region Properties

        public string KeyName { get; }

        public string TopicName { get; }

        #endregion Properties
    }
}
