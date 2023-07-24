using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.DapperOrm.Entities
{
    public interface IEntityBase<TKey>
    {
        #region Properties

        TKey Id { get; set; }

        #endregion Properties
    }
}
