using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public abstract class EventBase : IEvent, INotification
    {
        #region Properties

        public string EventMessage { get; protected set; } = string.Empty;

        public int EventType { get; protected set; } = 0;

        public int EventVersion { get; protected set; } = 1;

        public DateTime OccurredOn { get; protected set; } = DateTimeOffset.Now.UtcDateTime;

        #endregion Properties
    }
}
