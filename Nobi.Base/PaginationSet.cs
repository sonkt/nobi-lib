using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Base
{
    public class PaginationSet<T>
    {
        #region Properties

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public IEnumerable<T> Items { set; get; }

        public int TotalCount { set; get; }

        #endregion Properties
    }
}
