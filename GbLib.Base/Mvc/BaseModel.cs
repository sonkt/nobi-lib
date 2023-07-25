using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base.Mvc
{
    public abstract class BaseModel
    {
        public bool? IsDeleted { get; set; }

        public string? Keyword { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
