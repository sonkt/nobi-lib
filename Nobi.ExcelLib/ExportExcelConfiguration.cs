using OfficeOpenXml;

namespace Nobi.ExcelLib
{

    public class ExportExcelConfiguration
    {
        public IList<ExcelSection> Sections { get; set; } = new List<ExcelSection>();

        public double DefaultRowHeight { get; set; } = 14.25;
        public eOrientation IsLandscape { get; set; } = eOrientation.Portrait;
        public bool AutofitColumn { get; set; }
        public string WorklSheetName { get; set; }
        public ePaperSize PaperSize { get; set; } = ePaperSize.A4;
        public bool FitToPage { get; set; } = true;
        public int FitToWidth { get; set; } = 1;
        public int FitToHeight { get; set; } = 0;
        public bool HorizontalCentered { get; set; } = true;


        public ExportExcelConfiguration()
        { }
    }
}
