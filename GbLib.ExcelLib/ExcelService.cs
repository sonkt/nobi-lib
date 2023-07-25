using GbLib.Base.Helpers;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Reflection;

namespace GbLib.ExcelLib
{

    public class ExcelService
    {
        private readonly List<string> LIST_EXCEL_COLUMN_NAME = new List<string> {"A","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
        "AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
        "BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
        "CA","CB","CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
        "DA","DB","DC","DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
        "EA","EB","EC","ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
        "FA","FB","FC","FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ"
        };
        private readonly string DEFAULT_IMAGE = "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";

        private ExcelWorksheet ws;
        private readonly ExportExcelConfiguration _setting;

        public ExcelService(ExportExcelConfiguration reportConfiguration)
        {
            _setting = reportConfiguration;
        }
        public async Task<string> ExportExcel()
        {
            try
            {
                // Setting Environment
                string filename = DateTime.Now.ToString("ssddMMyyyy") + "blank.xlsx";
                string newPath = Path.Combine(Directory.GetCurrentDirectory(), $"ExcelTemplate").Trim();
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);
                string fileURL = Path.Combine(Directory.GetCurrentDirectory(), $"ExcelTemplate/{filename}").Trim();

                FileInfo file = new FileInfo(fileURL);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                if (file.Exists) file.Delete();
                var package = new ExcelPackage(file);
                ws = package.Workbook.Worksheets.Add(string.IsNullOrEmpty(_setting.WorklSheetName) ? "Report" : _setting.WorklSheetName);

                ws.DefaultRowHeight = _setting.DefaultRowHeight;

                #region Config Body Content of Report
                var lastRowIndex = 0;
                foreach (var section in _setting.Sections)
                {
                    var startRow = 0;
                    if (section.GetType() == typeof(ExcelGridSection))
                    {
                        var item = (ExcelGridSection)section;
                        var _totalColumn = item.Columns.Count;
                        // Insert nội dung của lưới (bao gồm cả header)
                        if (item.StartRowOfContent == 0 || item.StartRowOfContent == lastRowIndex)
                        {
                            startRow = lastRowIndex + item.MarginTop + 1;
                        }
                        else
                        {
                            startRow = item.StartRowOfContent + item.MarginTop;
                        }
                        SettingGridContent(startRow, item.Data, item.Columns, item.RowHeight);
                        lastRowIndex = ws.Dimension.End.Row;
                    }
                    else if (section.GetType() == typeof(ExcelListSection))
                    {
                        var item = (ExcelListSection)section;

                        if (item.StartRowOfContent == 0)
                        {
                            startRow = lastRowIndex + item.MarginTop + 1;
                        }
                        else
                        {
                            startRow = item.StartRowOfContent + item.MarginTop;
                        }
                        SettingListContent(startRow, item.StartColumnOfContent, item.ColumnSpan, item.Data.Select(x => x.ToString())?.ToList() ?? new List<string> { }, item.DataFormat);

                        lastRowIndex = ws.Dimension.End.Row;
                    }
                    else if (section.GetType() == typeof(ExcelTextSection))
                    {
                        var item = (ExcelTextSection)section;
                        if (item.StartRowOfContent == 0)
                        {
                            startRow = lastRowIndex + item.MarginTop + 1;
                        }
                        else
                        {
                            startRow = item.StartRowOfContent + item.MarginTop;
                        }
                        SettingTextContent(startRow, item.StartColumnOfContent, item.ColumnSpan, item.Data?.FirstOrDefault()?.ToString(), item.DataFormat);

                        lastRowIndex = ws.Dimension.End.Row;
                    }
                    else if (section.GetType() == typeof(ExcelImageSection))
                    {
                        var item = (ExcelImageSection)section;   // Xử lý ảnh
                        item.Images?.ToList().ForEach(x => ImportImage(x.ImageUrl, x.RowIndex, x.ColumnIndex, x.Width, x.Height, x.Name, x.MarginLeft, x.MarginTop));
                    }
                }
                #endregion
                ws.PrinterSettings.Orientation = _setting.IsLandscape;
                ws.PrinterSettings.PaperSize = _setting.PaperSize;
                ws.PrinterSettings.HorizontalCentered = _setting.HorizontalCentered;
                ws.PrinterSettings.FitToPage = _setting.FitToPage;
                ws.PrinterSettings.FitToWidth = _setting.FitToWidth;
                ws.PrinterSettings.FitToHeight = _setting.FitToHeight;

                if (_setting.AutofitColumn)
                {
                    ws.Cells.AutoFitColumns();
                }
                await package.SaveAsync();
                return fileURL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region Support Function

        private void SettingTextContent(int startRowIndex, int startColumnIndex, int columnSpan, string content, ExcelCellFormat cellFormat)
        {
            var colName = LIST_EXCEL_COLUMN_NAME[startColumnIndex];

            ws.Cells[$"{colName}{startRowIndex}"].Value = content;

            var cellAddress = MergeColumns(startRowIndex, startColumnIndex, columnSpan);

            SetRowHeight(startRowIndex, startRowIndex + columnSpan, cellFormat.RowHeight);
            CellFormat(cellFormat, cellAddress);
        }

        private void SettingListContent(int startRowIndex, int startColumnIndex, int columnSpan, IList<string> collection, ExcelCellFormat cellFormat)
        {
            try
            {
                var currentRowIndex = startRowIndex;
                foreach (var item in collection)
                {
                    var colName = LIST_EXCEL_COLUMN_NAME[startColumnIndex];
                    ws.Cells[$"{colName}{currentRowIndex}"].Value = item;

                    var cellAddress = MergeColumns(currentRowIndex, startColumnIndex, columnSpan);

                    CellFormat(cellFormat, cellAddress);

                    currentRowIndex++;
                }
                string startColumnName = LIST_EXCEL_COLUMN_NAME[startColumnIndex];
                string endColumnName = LIST_EXCEL_COLUMN_NAME[startColumnIndex + columnSpan - 1];
                string rangeBorder = $"{startColumnName}{startRowIndex}:{endColumnName}{currentRowIndex - 1}";
                SetRowHeight(startRowIndex, currentRowIndex, cellFormat.RowHeight);
                SetRangeBorder(rangeBorder, cellFormat.BorderColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void SettingGridContent(int startRowIndex, IList<object> listObjects, IList<ExcelGridColumn> listConfigColumns, double rowDataHeight = 14.25, double rowHeaderHeight = 30, double rowFooterHeight = 20)
        {
            try
            {
                Type modelType = TypeHelper.GetItemTypeOfList(listObjects);
                var columns = listConfigColumns.OrderBy(x => x.Order).ToList();
                var numberRowOfHeader = columns?.First()?.Header?.Count ?? 0;
                var numberRowOfFooter = columns?.First()?.Footer?.Count ?? 0;
                foreach (var col in columns)
                {
                    int numberHeaderRowOfCol = col.Header?.Count ?? 0;
                    if (numberHeaderRowOfCol > numberRowOfHeader)
                    {
                        numberRowOfHeader = numberHeaderRowOfCol;
                    }
                    var numberFooterRowOfCol = col.Footer?.Count ?? 0;
                    if (numberHeaderRowOfCol > numberRowOfFooter)
                    {
                        numberRowOfFooter = numberHeaderRowOfCol;
                    }
                }


                var headerRow = startRowIndex;
                var startBodyRow = headerRow + numberRowOfHeader;
                var endBodyRow = startBodyRow + (listObjects.Count != 0 ? listObjects.Count : 1) - 1;
                var footerRow = endBodyRow + 1;
                var endColumnIndex = LIST_EXCEL_COLUMN_NAME[columns.Count];

                #region Xử lý binding cột dữ liệu
                int columnCounter = 1;
                var hasFooter = false;
                // Duyệt qua các cột
                foreach (var column in columns)
                {
                    string colName = LIST_EXCEL_COLUMN_NAME[columnCounter];
                    // Setting header
                    var headerRowCounter = headerRow;
                    foreach (var header in column.Header)
                    {
                        string colHeaderAddress = $"{colName}{headerRowCounter}:{colName}{headerRowCounter}";
                        ws.Cells[colHeaderAddress].Value = header.Title;
                        if (header.ColumnSpan > 1)
                        {
                            MergeColumns(headerRowCounter, columnCounter, header.ColumnSpan);
                        }
                        if (header.RowSpan > 1)
                        {
                            MergeRows(headerRowCounter, columnCounter, header.RowSpan);
                        }
                        CellFormat(header.Format, colHeaderAddress);
                        ws.Column(columnCounter).Width = column.Width;
                        headerRowCounter++;
                    }
                    // Setting Data Cell format
                    string dataAddress = $"{colName}{startBodyRow}:{colName}{endBodyRow}";
                    for (int i = startBodyRow; i <= endBodyRow; i++)
                    {
                        MergeColumns(i, columnCounter, column.ColumnSpan);
                    }
                    CellFormat(column.BodyFormat, dataAddress);

                    // Setting Footer
                    if (column.Footer != null && column.Footer.Count > 0)
                    {

                        var footerRowCounter = footerRow;
                        foreach (var footer in column.Footer)
                        {
                            hasFooter = true;
                            string colFooterAddress = $"{colName}{footerRowCounter}:{colName}{footerRowCounter}";
                            CellFormat(footer.Format, colFooterAddress);
                            ws.Cells[colFooterAddress].Value = footer.Content;
                            if (footer.ColumnSpan > 1)
                            {
                                MergeColumns(footerRowCounter, columnCounter, footer.ColumnSpan);
                            }
                            if (footer.RowSpan > 1)
                            {
                                MergeRows(footerRowCounter, columnCounter, footer.RowSpan);
                            }
                            footerRowCounter++;
                        }
                    }
                    columnCounter++;
                }
                #endregion

                #region Đổ dữ liệu đã Binding vào Excel, thiết lập border

                string startColumn = LIST_EXCEL_COLUMN_NAME[1];
                string configStartRow = $"{startColumn}{startBodyRow}";
                string rangeBorder = $"{startColumn}{headerRow}:{endColumnIndex}{(hasFooter ? footerRow + numberRowOfFooter - 1 : endBodyRow)}";

                SetRowHeight(headerRow, headerRow + numberRowOfHeader, rowHeaderHeight);
                SetRowHeight(startBodyRow, endBodyRow, rowDataHeight);
                SetRowHeight(footerRow, footerRow + numberRowOfFooter, rowFooterHeight);

                SetBorder(rangeBorder);
                if (modelType != null)
                {
                    var propertiesSort = MakePropertyList(modelType, columns);
                    var listDataToExport = MakeDataToExport(listObjects, propertiesSort);
                    var range = ws.Cells[configStartRow].LoadFromCollection(listDataToExport, false);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void CellFormat(ExcelCellFormat format, string address)
        {
            ws.Cells[address].Style.Fill.PatternType = format.FillStyle;
            ws.Cells[address].Style.Fill.BackgroundColor.SetColor(format.BackgroundColor);
            ws.Cells[address].Style.HorizontalAlignment = format.TextAlignment;
            ws.Cells[address].Style.VerticalAlignment = format.TextVerticalAlignment;
            ws.Cells[address].Style.TextRotation = format.TextRotation;
            ws.Cells[address].Style.Font.Color.SetColor(format.TextColor);
            ws.Cells[address].Style.Font.Size = format.FontSize;
            ws.Cells[address].Style.Font.Italic = format.IsItalic;
            ws.Cells[address].Style.Font.Bold = format.IsBold;
            ws.Cells[address].Style.Font.UnderLine = format.IsUnderline;
            ws.Cells[address].Style.Font.Name = format.FontName;
            ws.Cells[address].Style.WrapText = format.IsWrapText;
            ws.Cells[address].Style.Numberformat.Format = format.DataFormat;
        }

        private void SetRowHeight(int startRow, int endRow, double height)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                ws.Row(i).Height = height;
            }
        }

        private List<Dictionary<string, object>> MakeDataToExport(IList<object> listObjects, List<PropertyInfo> propertiesSort)
        {
            var listData = new List<Dictionary<string, object>> { };
            var dataIndex = 1;
            foreach (var item in listObjects)
            {
                var dicCols = new Dictionary<string, object>();
                var count = 0;
                dicCols.Add("STT", dataIndex);
                foreach (var property in propertiesSort)
                {
                    count++;
                    if (property != null)
                    {
                        var propName = property.Name;
                        var value = property.GetValue(item, null);
                        if (dicCols.ContainsKey(propName)) { propName = propName + "_" + count; }
                        dicCols.Add(propName, value);
                    }
                }

                listData.Add(dicCols);
                dataIndex++;
            }

            return listData;
        }

        private List<PropertyInfo> MakePropertyList(Type modelType, List<ExcelGridColumn> columns)
        {
            int index = 1;
            PropertyInfo tmp = null;
            var properties = modelType.GetProperties();
            List<PropertyInfo> propertiesSort = new List<PropertyInfo> { };
            foreach (var item in columns)
            {
                var column = properties.FirstOrDefault(x => x.Name.ToLower() == item.ColumnName.ToLower());
                if (column != null)
                {
                    tmp = column;
                    propertiesSort.Add(column);
                }
                else
                {
                    propertiesSort.Add(tmp);
                }
                ws.Column(index).Width = item.Width;
                index = index + 1;
            }

            return propertiesSort;
        }

        private string MergeColumns(int rowIndex, int columnIndex, int step)
        {
            var keyEnd = LIST_EXCEL_COLUMN_NAME[columnIndex + (int)step - 1];
            var keyStart = LIST_EXCEL_COLUMN_NAME[columnIndex];
            string result = $"{keyStart}{rowIndex}:{keyEnd}{rowIndex}";

            if (step == 0 || step == 1)
            {
                return $"{keyStart}{rowIndex}:{keyStart}{rowIndex}";
            }
            else
            {
                ws.Cells[result].Merge = true;
                return result;
            }
        }

        private string MergeRows(int rowIndex, int columnIndex, int step)
        {
            var key = LIST_EXCEL_COLUMN_NAME[columnIndex];
            var rowEnd = rowIndex + step - 1;
            string result = $"{key}{rowIndex}:{key}{rowEnd}";

            if (step == 0 || step == 1)
            {
                return $"{key} {rowIndex} : {key} {rowIndex}";
            }
            else
            {
                ws.Cells[result].Merge = true;
                return result;
            }
        }

        public void SetBorder(string address, ExcelBorderStyle style = ExcelBorderStyle.Thin)
        {
            var modelTable = ws.Cells[address];
            modelTable.Style.Border.Top.Style = style;
            modelTable.Style.Border.Left.Style = style;
            modelTable.Style.Border.Right.Style = style;
            modelTable.Style.Border.Bottom.Style = style;
        }
        public void SetRangeBorder(string rangeBorder, Color color, ExcelBorderStyle style = ExcelBorderStyle.Thin)
        {
            ws.Cells[rangeBorder].Style.Border.BorderAround(style, color);
        }

        public void SetBorder(string address, ExcelBorderStyle top, ExcelBorderStyle right, ExcelBorderStyle bottom, ExcelBorderStyle left)
        {
            var modelTable = ws.Cells[address];
            modelTable.Style.Border.Top.Style = top;
            modelTable.Style.Border.Left.Style = left;
            modelTable.Style.Border.Right.Style = right;
            modelTable.Style.Border.Bottom.Style = bottom;
        }

        public byte[] GetImageFromUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    return httpClient.GetByteArrayAsync(url).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error downloading image from URL: " + url + ", error: " + ex.Message);
                    return new byte[0];
                }
            }
        }

        public void ImportImage(string url, int row, int col, int width, int height, string name, int marginLeft, int marginTop)
        {
            byte[] imageBytes = GetImageFromUrl(url);
            if (imageBytes.Length == 0)
            {
                imageBytes = Convert.FromBase64String(DEFAULT_IMAGE);
            }
            var memoryStream = new MemoryStream(imageBytes);
            var picture = ws.Drawings.AddPicture(name, memoryStream);
            picture.SetSize(width, height);
            picture.SetPosition(row, marginTop, col, marginLeft);
        }

        #endregion

    }
    #region NumberFormat Data
    //"General"
    //"0"
    //"0.00"
    //"#,##0"
    //"#,##0.00"
    //"0%"
    //"0.00%"
    //"0.00E+00"
    //"# ?/?"
    //"# ??/??"
    //"mm-dd-yy"
    //"d-mmm-yy"
    //"d-mmm"
    //"mmm-yy"
    //"h:mm AM/PM"
    //"h:mm:ss AM/PM"
    //"h:mm"
    //"h:mm:ss"
    //"m/d/yy h:mm"
    //"#,##0 ;(#,##0)"
    //"#,##0 ;[Red](#,##0)"
    //"#,##0.00;(#,##0.00)"
    //"#,##0.00;[Red](#,#)"
    //"mm:ss"
    //"[h]:mm:ss"
    //"mmss.0"
    //"##0.0"
    //"@"
    #endregion
}