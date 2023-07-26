using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public interface ISelfInfoService
    {
        #region Properties

        string Id { get; }

        string Name { get; }

        #endregion Properties
    }
}
