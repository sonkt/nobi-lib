using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Base
{
    public interface IDomainEventDispatcher : IDisposable
    {
        #region Methods

        Task Dispatch(IEvent @event);

        #endregion Methods
    }
}
