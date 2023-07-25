using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public interface ICorrelationContext
    {
        #region Properties

        Guid CorrelationId { get; }

        #endregion Properties
    }
}
