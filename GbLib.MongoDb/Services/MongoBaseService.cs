using GbLib.Base;
using GbLib.ExcelLib;
using GbLib.MongoDb.Entities;
using GbLib.MongoDb.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;

namespace GbLib.MongoDb.Services
{
    public class MongoBaseService<TEntity> : IMongoBaseService<TEntity> where TEntity : MongoEntityBase
    {
        private readonly IMongoRepository<TEntity> _repository;

        public MongoBaseService(IMongoRepository<TEntity> repository, string collectionName = "")
        {
            _repository = repository;
        }

        public virtual async Task<bool> DeleteAsync(TEntity data, string collectionName = "")
        {
            return await _repository.DeleteAsync(data, collectionName);
        }

        public virtual async Task<bool> DeleteListAsync(List<TEntity> listData, string collectionName = "")
        {
            return await _repository.DeleteAsync(listData, collectionName);
        }

        public virtual async Task<TEntity> GetByCondition(FilterDefinition<TEntity> predicate, string collectionName = "")
        {
            return await _repository.GetObjectAsync(predicate, collectionName);
        }

        public virtual async Task<TEntity> GetById(ObjectId id, string collectionName = "")
        {
            return await _repository.GetObjectByIdAsync(id, collectionName);
        }

        public IMongoCollection<TEntity> GetCollection(string collectionName = "")
        {
           return _repository.GetCollection(collectionName);
        }

        public virtual async Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "")
        {
            return await _repository.GetListPagedAsync(pageNumber, rowsPerPage, predicate, sortColumn, collectionName);
        }

        public virtual async Task<ObjectId> InsertAsync(TEntity data, string collectionName = "")
        {
            var result = await _repository.AddAsync(data, collectionName);
            return result.Id;
        }

        public virtual async Task<List<ObjectId>> InsertListAsync(List<TEntity> listData, string collectionName = "")
        {
            var result = await _repository.AddAsync(listData, collectionName);
            return result?.Select(m => m.Id)?.ToList();
        }

        public virtual async Task<bool> UpdateAsync(TEntity data, string collectionName = "")
        {
            var result = await _repository.UpdateAsync(data, collectionName);
            return result.Id != ObjectId.Empty;
        }

        public virtual async Task<bool> UpdateListAsync(List<TEntity> listData, string collectionName = "")
        {
            var result = await _repository.UpdateAsync(listData, collectionName);
            return result.Count > 0;
        }

        public virtual Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction)
        {
            return ExportExcel(listData, listColumns, reportTitle, titleRowHeight, dbTransaction, false);
        }

        public List<ExcelGridColumn> GetExcelGridColumn(List<ExcelColumnModel> listColumns, bool listHasIndexColumn = false)
        {
            var listGridColumns = new List<ExcelGridColumn>();
            if (listColumns == null) return listGridColumns;

            var firstBgHeaderColor = "#2d9cdb";
            var firstBgBodyColor = "#fff";
            var firstBgFooterColor = "#fff";
            var firstTextHeaderColor = "#fff";
            var firstTextBodyColor = "#000";
            var firstTextFooterColor = "#fff";
            var firstColum = listColumns.FirstOrDefault();

            if (firstColum != null)
            {
                firstBgHeaderColor = firstColum.Headers?.First().BgHeaderColor;
                firstBgBodyColor = firstColum.BgBodyColor;
                firstBgFooterColor = firstColum.Footers?.First().BgFooterColor;
                firstTextHeaderColor = firstColum.Headers?.First().TextHeaderColor;
                firstTextBodyColor = firstColum.TextBodyColor;
                firstTextFooterColor = firstColum.Footers?.First().TextFooterColor;
            }
            var offsetOrder = listHasIndexColumn ? 0 : 1;
            var checkHasFooter = listColumns.Find(m => m.Footers != null && m.Footers.Count > 0) != null;
            foreach (var column in listColumns)
            {
                var headers = new List<ExcelColumnHeader>();
                if (column.Headers != null)
                {
                    foreach (var header in column.Headers)
                    {
                        headers.Add(new ExcelColumnHeader
                        {
                            ColumnSpan = header.HeaderColSpan,
                            RowSpan = header.HeaderRowSpan,
                            Title = header.HeaderText,
                            Format = new ExcelCellFormat
                            {
                                IsBold = true,
                                IsWrapText = true,
                                DataFormat = header.DataFormat,
                                TextAlignment = GetExcelAlign(header.HeaderTextAlign),
                                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                                BackgroundColor = ColorTranslator.FromHtml(!string.IsNullOrEmpty(header.BgHeaderColor) ? header.BgHeaderColor : "#2d9cdb"),
                                TextColor = ColorTranslator.FromHtml(!string.IsNullOrEmpty(header.TextHeaderColor) ? header.TextHeaderColor : "#FFF")
                            }
                        });
                    }
                }
                var footers = new List<ExcelColumnFooter>();
                if (column.Footers != null)
                {
                    foreach (var footer in column.Footers)
                    {
                        footers.Add(new ExcelColumnFooter
                        {
                            ColumnSpan = footer.FooterColSpan,
                            RowSpan = footer.FooterRowSpan,
                            Content = footer.FooterText,
                            Format = new ExcelCellFormat
                            {
                                IsBold = true,
                                IsWrapText = true,
                                TextAlignment = GetExcelAlign(footer.FooterTextAlign),
                                DataFormat = footer.DataFormat,
                                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                                BackgroundColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(footer.BgFooterColor) ? footer.BgFooterColor : "#2d9cdb"),
                                TextColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(footer.TextFooterColor) ? footer.TextFooterColor : "#FFF")
                            }
                        });
                    }
                }

                var gridColumn = new ExcelGridColumn
                {
                    ColumnName = column.ColumnName,
                    ColumnSpan = column.BodyColSpan,
                    BodyFormat = new ExcelCellFormat
                    {
                        TextVerticalAlignment = ExcelVerticalAlignment.Center,
                        TextAlignment = GetExcelAlign(column.BodyTextAlign),
                        DataFormat = column.DataFormat,
                        BackgroundColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(column.BgBodyColor) ? column.BgBodyColor : "#fff"),
                        TextColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(column.TextBodyColor) ? column.TextBodyColor : "#000")
                    },
                    Order = column.Order + offsetOrder,
                    Header = headers,
                    Footer = footers,
                    Width = column.Width
                };
                listGridColumns.Add(gridColumn);
            }
            if (!listHasIndexColumn)
            {
                var indexColumn = new ExcelGridColumn
                {
                    ColumnName = "STT",
                    ColumnSpan = 1,
                    BodyFormat = new ExcelCellFormat
                    {
                        TextAlignment = ExcelHorizontalAlignment.Center,
                        TextColor = System.Drawing.ColorTranslator.FromHtml(firstTextBodyColor),
                        BackgroundColor = System.Drawing.ColorTranslator.FromHtml(firstBgBodyColor),
                        TextVerticalAlignment = ExcelVerticalAlignment.Center
                    },
                    Order = 1,
                    Header = new List<ExcelColumnHeader>{
                        new ExcelColumnHeader
                        {
                            ColumnSpan = 1,
                            RowSpan = 1,
                            Title = "STT",
                            Format = new ExcelCellFormat
                            {
                                BackgroundColor = System.Drawing.ColorTranslator.FromHtml(firstBgHeaderColor),
                                IsBold = true,
                                IsWrapText = true,
                                TextAlignment = ExcelHorizontalAlignment.Center,
                                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                                TextColor = System.Drawing.ColorTranslator.FromHtml(firstTextHeaderColor)
                            }
                        }
                    },
                    Footer = checkHasFooter ? new List<ExcelColumnFooter>{
                        new ExcelColumnFooter
                        {
                            ColumnSpan = 1,
                            Content = "",
                            Format = new ExcelCellFormat
                            {
                                BackgroundColor = System.Drawing.ColorTranslator.FromHtml(firstBgFooterColor),
                                IsWrapText = true,
                                TextAlignment = ExcelHorizontalAlignment.Center,
                                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                                TextColor = System.Drawing.ColorTranslator.FromHtml(firstTextFooterColor),
                            }
                        }
                    } : null,
                    Width = 6,
                };
                listGridColumns.Add(indexColumn);
            }
            return listGridColumns;
        }

        public List<ExcelGridColumn> GetExcelGridColumn(object entity, bool listHasIndexColumn = false)
        {
            if (entity == null) return new List<ExcelGridColumn> { };
            var properties = entity.GetType().GetProperties();
            var listGridColumns = new List<ExcelGridColumn>();
            var totalColumns = properties.Length;
            foreach (var property in properties)
            {
                var gridColumn = new ExcelGridColumn
                {
                    ColumnName = property.Name,
                    ColumnSpan = 1,
                    BodyFormat = new ExcelCellFormat { },
                    Order = totalColumns
                };
                var attributes = property.GetCustomAttributes(false);
                var attribute = attributes.FirstOrDefault(m => m is Base.Attributes.DisplayNameAttribute);
                if (attribute != null)
                {
                    var att = (Base.Attributes.DisplayNameAttribute)attribute;
                    gridColumn.Order = att.Order + 1;
                    gridColumn.Header = new List<ExcelColumnHeader> { new ExcelColumnHeader { ColumnSpan = 1, Title = att.DisplayName, Format = new ExcelCellFormat { BackgroundColor = Color.Gray, IsBold = true, IsWrapText = true, TextAlignment = ExcelHorizontalAlignment.Center, TextVerticalAlignment = ExcelVerticalAlignment.Center, TextColor = Color.White, } } };
                    gridColumn.Footer = new List<ExcelColumnFooter> { new ExcelColumnFooter { ColumnSpan = 1, Content = "", Format = new ExcelCellFormat { BackgroundColor = Color.WhiteSmoke, IsWrapText = true, TextAlignment = ExcelHorizontalAlignment.Center, TextVerticalAlignment = ExcelVerticalAlignment.Center, TextColor = Color.Black } } };
                    gridColumn.BodyFormat = new ExcelCellFormat
                    {
                        RowHeight = 25,
                        TextVerticalAlignment = ExcelVerticalAlignment.Center,
                        DataFormat = (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) ? "mm-dd-yy" : "General"
                    };
                    listGridColumns.Add(gridColumn);
                }
            }
            if (!listHasIndexColumn)
            {
                var indexColumn = new ExcelGridColumn
                {
                    ColumnName = "STT",
                    ColumnSpan = 1,
                    BodyFormat = new ExcelCellFormat
                    {
                        RowHeight = 25,
                        TextVerticalAlignment = ExcelVerticalAlignment.Center,
                        TextAlignment = ExcelHorizontalAlignment.Center
                    },
                    Order = 1,
                    Header = new List<ExcelColumnHeader> { new ExcelColumnHeader { ColumnSpan = 1, Title = "STT", Format = new ExcelCellFormat { BackgroundColor = Color.Gray, IsBold = true, IsWrapText = true, TextAlignment = ExcelHorizontalAlignment.Center, TextVerticalAlignment = ExcelVerticalAlignment.Center, TextColor = Color.White } } },
                    Footer = new List<ExcelColumnFooter> { new ExcelColumnFooter { ColumnSpan = 1, Content = "", Format = new ExcelCellFormat { BackgroundColor = Color.WhiteSmoke, IsWrapText = true, TextAlignment = ExcelHorizontalAlignment.Center, TextVerticalAlignment = ExcelVerticalAlignment.Center, TextColor = Color.Black } } }
                };
                listGridColumns.Add(indexColumn);
            }
            return listGridColumns;
        }

        private ExcelHorizontalAlignment GetExcelAlign(string align)
        {
            if (!string.IsNullOrEmpty(align))
            {
                align = align.ToLower();
                switch (align)
                {
                    case "center":
                        return ExcelHorizontalAlignment.Center;

                    case "left":
                        return ExcelHorizontalAlignment.Left;

                    case "right":
                        return ExcelHorizontalAlignment.Right;

                    case "justify":
                        return ExcelHorizontalAlignment.Justify;
                }
            }
            return ExcelHorizontalAlignment.Left;
        }

        public virtual async Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction, bool hasIndexColumn)
        {
            if (listData == null)
            {
                return "";
            };
            var listGridColumns = new List<ExcelGridColumn>();
            if (listColumns == null || listColumns.Count == 0)
            {
                listGridColumns = GetExcelGridColumn(listData.FirstOrDefault(), hasIndexColumn);
            }
            else
            {
                listGridColumns = GetExcelGridColumn(listColumns, hasIndexColumn);
            }

            ExportExcelConfiguration option = new ExportExcelConfiguration();

            var titleContent = (IExcelTextSection)(new ExcelSectionBuilder<IExcelTextSection>())
               .SetStartColumn(1)
               .SetCollection(new List<object> { reportTitle })
               .Build;
            titleContent.SetColumnSpan((int)listGridColumns.Count);
            titleContent.SetDataFormat(new ExcelCellFormat
            {
                FontName = "Times New Roman",
                TextAlignment = ExcelHorizontalAlignment.CenterContinuous,
                FontSize = 20,
                IsBold = true,
                TextColor = Color.Black,
                RowHeight = titleRowHeight
            });

            var subTitleContent = (IExcelTextSection)(new ExcelSectionBuilder<IExcelTextSection>())
                .SetStartColumn(1)
                .SetCollection(new List<object> { $"Ngày báo cáo:{DateTime.Now.ToString("dd/MM/yyyy")}" })
                .Build;
            subTitleContent.SetColumnSpan((int)listGridColumns.Count);
            subTitleContent.SetDataFormat(new ExcelCellFormat
            {
                FontSize = 12,
                IsItalic = true,
                TextAlignment = ExcelHorizontalAlignment.CenterContinuous,
                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                IsWrapText = true
            });

            var bodyContent = (IExcelGridSection)(new ExcelSectionBuilder<IExcelGridSection>())
               .SetStartColumn(1)
               .SetMarginTop(2)
               .SetCollection(listData.ToList()).Build;
            bodyContent.SetColumns(listGridColumns);

            option.Sections.Add((ExcelTextSection)titleContent);
            option.Sections.Add((ExcelTextSection)subTitleContent);
            option.Sections.Add((ExcelGridSection)bodyContent);

            ExcelService extension = new ExcelService(option);
            var fileUrl = await extension.ExportExcel();
            return fileUrl;
        }

        public virtual Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, IDbTransaction? dbTransaction, bool hasIndexColumn)
        {
            return ExportExcel(listData, listColumns, reportTitle, 40, dbTransaction, hasIndexColumn);
        }

        public virtual Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, bool hasIndexColumn)
        {
            return ExportExcel(listData, listColumns, reportTitle, titleRowHeight, null, hasIndexColumn);
        }

        public virtual Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, bool hasIndexColumn)
        {
            return ExportExcel(listData, listColumns, reportTitle, 40, null, hasIndexColumn);
        }

        public Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle)
        {
            return ExportExcel(listData, listColumns, reportTitle, 40, null, false);
        }
    }
}