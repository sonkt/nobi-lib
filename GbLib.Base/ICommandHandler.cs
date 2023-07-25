using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GbLib.Base
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        #region Methods

        Task HandleAsync(TCommand command, ICorrelationContext context);

        #endregion Methods
    }
}
