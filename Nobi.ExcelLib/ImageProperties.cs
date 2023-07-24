using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.ExcelLib
{
    public class ImageProperties
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MarginTop { get; set; }
        public int MarginLeft { get; set; }
    }

}
