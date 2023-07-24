using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public interface IExcelTextSection : IExcelSection
    {
        IExcelTextSection SetColumnSpan(int colspan);
        IExcelTextSection SetDataFormat(ExcelCellFormat format);
    }
}
