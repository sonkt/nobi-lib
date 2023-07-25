using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        #region Methods

        Task HandleAsync(TEvent _event, ICorrelationContext context);

        #endregion Methods
    }
}
