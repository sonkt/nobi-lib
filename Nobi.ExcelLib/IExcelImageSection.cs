using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public interface IExcelImageSection : IExcelSection
    {
        ExcelImageSection SetImage(List<ImageProperties> list);
    }
}
