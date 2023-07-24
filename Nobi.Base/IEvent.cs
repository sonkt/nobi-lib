using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Base
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
