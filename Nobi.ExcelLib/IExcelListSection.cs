using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public interface IExcelListSection : IExcelSection
    {
        IExcelListSection SetColumnSpan(int colspan);
        IExcelListSection SetDataFormat(ExcelCellFormat format);
    }
}
