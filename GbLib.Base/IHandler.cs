using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public interface IHandler
    {
        #region Methods

        IHandler Always(Func<Task> always);

        Task ExecuteAsync();

        IHandler Handle(Func<Task> handle);

        IHandler OnCustomError(Func<EventBusException, Task> onCustomError, bool rethrow = false);

        IHandler OnError(Func<Exception, Task> onError, bool rethrow = false);

        IHandler OnSuccess(Func<Task> onSuccess);

        #endregion Methods
    }
}
