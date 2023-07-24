using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public class ExcelColumnModel
    {
        public string ColumnName { get; set; }
        public string BodyTextAlign { get; set; } = "left";
        public string TextBodyColor { get; set; }
        public string BgBodyColor { get; set; }
        public int Order { get; set; } = 1;
        public string DataFormat { get; set; } = "General";
        public int BodyColSpan { get; set; } = 1;
        public int Width { get; set; }
        public List<ExcelHeaderModel> Headers { get; set; }
        public List<ExcelFooterModel> Footers { get; set; }
    }
    public class ExcelHeaderModel
    {
        public string BgHeaderColor { get; set; }
        public string TextHeaderColor { get; set; }
        public string HeaderText { get; set; }
        public int HeaderColSpan { get; set; } = 1;
        public int HeaderRowSpan { get; set; } = 1;
        public string HeaderTextAlign { get; set; } = "center";
    }
    public class ExcelFooterModel
    {
        public string BgFooterColor { get; set; }
        public string TextFooterColor { get; set; }
        public string FooterText { get; set; }
        public string FooterTextAlign { get; set; } = "center";
        public int FooterColSpan { get; set; } = 1;
        public int FooterRowSpan { get; set; } = 1;
    }
}
