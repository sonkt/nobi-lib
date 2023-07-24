using OfficeOpenXml.Style;
using System.Drawing;

namespace Nobi.ExcelLib
{
    public class ExcelSectionBuilder<T> where T : IExcelSection
    {
        public ExcelSection Build = null;

        public ExcelSectionBuilder()
        {
            if (typeof(T) == typeof(IExcelGridSection))
            {
                Build = new ExcelGridSection();
            }
            else if (typeof(T) == typeof(IExcelListSection))
            {
                Build = new ExcelListSection();
            }
            else if (typeof(T) == typeof(IExcelImageSection))
            {
                Build = new ExcelImageSection();
            }
            else
            {
                Build = new ExcelTextSection();
            }

        }
        public ExcelSectionBuilder<T> SetMarginTop(int value)
        {
            Build.MarginTop = value;
            return this;
        }

        public ExcelSectionBuilder<T> SetCollection(IList<object> collection)
        {
            Build.Data = collection;
            return this;
        }

        public ExcelSectionBuilder<T> SetBorderStyle(ExcelBorderStyle style)
        {
            Build.BorderStyle = style;
            return this;
        }

        public ExcelSectionBuilder<T> SetBorderColor(Color color)
        {
            Build.BorderColor = color;
            return this;
        }
        public ExcelSectionBuilder<T> SetStartColumn(int startIndex)
        {
            Build.StartColumnOfContent = startIndex;
            return this;
        }
        public ExcelSectionBuilder<T> SetStartRows(int startIndex)
        {
            Build.StartRowOfContent = startIndex;
            return this;
        }

    }

}
