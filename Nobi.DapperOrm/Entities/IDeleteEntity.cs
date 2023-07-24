using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.DapperOrm.Entities
{
    public interface IDeleteEntity
    {
        #region Properties

        bool? IsDeleted { get; set; }

        #endregion Properties
    }
}
