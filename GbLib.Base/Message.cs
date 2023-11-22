using MediatR;

namespace GbLib.Base
{
    public abstract class Message<T> : IRequest<T> where T : class
    {
        #region Constructors

        protected Message()
        {
            MessageType = GetType().Name;
        }

        #endregion Constructors

        #region Properties

        public Guid AggregateId { get; protected set; }

        public string MessageType { get; protected set; }

        #endregion Properties
    }
}