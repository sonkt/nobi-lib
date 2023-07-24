using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public class ExcelImageSection : ExcelSection, IExcelImageSection
    {
        public IList<ImageProperties> Images { get; set; }

        public ExcelImageSection SetImage(List<ImageProperties> list)
        {
            Images = list;
            return this;
        }
    }
}
