using Dapper;
using GbLib.Base;
using GbLib.Base.Helpers;
using GbLib.Entities;
using GbLib.ExcelLib;
using GbLib.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator.Filters;
using Microsoft.Data.SqlClient;
using MoreLinq;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq.Expressions;

namespace GbLib.Services
{
    public abstract class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey>
             where TEntity : class, IAuditEntity<TKey>
    {
        #region Fields

        private readonly IDapperOrmRepository<TEntity, TKey> _repository;

        #endregion Fields

        #region Constructors

        protected BaseService(IDapperOrmRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        #endregion Constructors

        #region Methods

        public virtual Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, int? numberOfItems, IDbTransaction? dbTransaction = null)
        {
            if (sortList == null)
            {
                if (numberOfItems != null)
                {
                    return _repository.SetLimit((uint)numberOfItems.Value, 0u).FindAllAsync(predicate, dbTransaction);
                }
                else
                {
                    return _repository.FindAllAsync(predicate, dbTransaction);
                }
            }
            else
            {
                var sortingBuilder = new List<string> { };
                foreach (var item in sortList)
                {
                    var order = item.Value ? "DESC " : "ASC ";
                    sortingBuilder.Add($"{item.Key} {order}");
                }
                var strSort = string.Join(", ", sortingBuilder);

                if (numberOfItems != null)
                {
                    return _repository.SetOrderBy(strSort).SetLimit((uint)numberOfItems.Value, 0u).FindAllAsync(predicate, dbTransaction);
                }
                else
                {
                    return _repository.SetOrderBy(strSort).FindAllAsync(predicate, dbTransaction);
                }
            }
        }
        public virtual Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null)
        {
            return FindAllAsync(predicate, sortList, null, dbTransaction);
        }
        public virtual Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int? numberOfItems, IDbTransaction? dbTransaction = null)
        {
            return FindAllAsync(predicate, null, numberOfItems, dbTransaction);
        }
        public virtual Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return FindAllAsync(predicate, null, null, dbTransaction);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, int? numberOfItems, IDbTransaction? dbTransaction = null)
        {
            if (sortList == null)
            {
                if (numberOfItems != null)
                {
                    return _repository.SetLimit((uint)numberOfItems.Value, 0u).FindAll(predicate, dbTransaction);
                }
                else
                {
                    return _repository.FindAll(predicate, dbTransaction);
                }
            }
            else
            {
                var sortingBuilder = new List<string> { };
                foreach (var item in sortList)
                {
                    var order = item.Value ? "DESC " : "ASC ";
                    sortingBuilder.Add($"{item.Key} {order}");
                }
                var strSort = string.Join(", ", sortingBuilder);

                if (numberOfItems != null)
                {
                    return _repository.SetOrderBy(strSort).SetLimit((uint)numberOfItems.Value, 0u).FindAll(predicate, dbTransaction);
                }
                else
                {
                    return _repository.SetOrderBy(strSort).FindAll(predicate, dbTransaction);
                }
            }
        }
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null)
        {
            return FindAll(predicate, sortList, null, dbTransaction);
        }
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int? numberOfItems, IDbTransaction? dbTransaction = null)
        {
            return FindAll(predicate, null, numberOfItems, dbTransaction);
        }
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return FindAll(predicate, null, null, dbTransaction);
        }


        public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null)
        {
            if (sortList == null)
            {
                return _repository.FindAsync(predicate, dbTransaction);
            }
            else
            {
                var sortingBuilder = new List<string> { };
                foreach (var item in sortList)
                {
                    var order = item.Value ? "DESC " : "ASC ";
                    sortingBuilder.Add($"{item.Key} {order}");
                }
                var strSort = string.Join(", ", sortingBuilder);
                return _repository.SetOrderBy(strSort).SetLimit(1u, 0u).FindAsync(predicate, dbTransaction);
            }
        }
        public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return FindAsync(predicate, null, dbTransaction);
        }

        public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null)
        {
            if (sortList == null)
            {
                return _repository.Find(predicate, dbTransaction);
            }
            else
            {
                var sortingBuilder = new List<string> { };
                foreach (var item in sortList)
                {
                    var order = item.Value ? "DESC " : "ASC ";
                    sortingBuilder.Add($"{item.Key} {order}");
                }
                var strSort = string.Join(", ", sortingBuilder);
                return _repository.SetOrderBy(strSort).SetLimit(1u, 0u).Find(predicate, dbTransaction);
            }
        }
        public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return Find(predicate, null, dbTransaction);
        }

        public virtual Task<TEntity?> FindByIdAsync(TKey id, IDbTransaction? dbTransaction = null)
        {
            if (id == null)
            {
                return Task.FromResult<TEntity?>(null);
            }
            return _repository.FindByIdAsync(id, dbTransaction);
        }

        public virtual TEntity? FindById(TKey id, IDbTransaction? dbTransaction = null)
        {
            if (id == null)
            {
                return null;
            }
            return _repository.FindById(id, dbTransaction);
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return _repository.CountAsync(predicate, dbTransaction);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return _repository.Count(predicate, dbTransaction);
        }

        public IDbTransaction GetDbTransaction()
        {
            return _repository.Connection.BeginTransaction();
        }

        public virtual async Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string sortColumnName, bool descending = false, IDbTransaction? dbTransaction = null)
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            var offset = (pageNumber - 1) * pageSize;
            var totalRows = await _repository.CountAsync(predicate, dbTransaction);
            var items = await _repository.SetOrderBy(descending ? OrderInfo.SortDirection.DESC : OrderInfo.SortDirection.ASC, new string[] { sortColumnName }).SetLimit((uint)pageSize, (uint)offset).FindAllAsync(predicate, dbTransaction);
            return new PaginationSet<TEntity>
            {
                Items = items,
                TotalCount = totalRows
            };
        }

        public virtual async Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool> sortList, IDbTransaction? dbTransaction = null)
        {
            if (sortList == null || sortList.Count == 0)
            {
                sortList = new Dictionary<string, bool>();
                sortList.Add("CreatedDate", true);
            }
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            var sortingBuilder = new List<string> { };
            foreach (var item in sortList)
            {
                var order = item.Value ? "DESC " : "ASC ";
                sortingBuilder.Add($"{item.Key} {order}");
            }
            var offset = (pageNumber - 1) * pageSize;
            var strSort = string.Join(", ", sortingBuilder);
            var totalRows = await _repository.CountAsync(predicate, dbTransaction);
            var items = await _repository.SetOrderBy(strSort).SetLimit((uint)pageSize, (uint)offset).FindAllAsync(predicate, dbTransaction);

            return new PaginationSet<TEntity>
            {
                Items = items,
                TotalCount = totalRows
            };
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
                                TextAlignment = GetExcelAlign(header.HeaderTextAlign),
                                TextVerticalAlignment = ExcelVerticalAlignment.Center,
                                BackgroundColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(header.BgHeaderColor) ? header.BgHeaderColor : "#2d9cdb"),
                                TextColor = System.Drawing.ColorTranslator.FromHtml(!string.IsNullOrEmpty(header.TextHeaderColor) ? header.TextHeaderColor : "#FFF")
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
                var dicSort = new Dictionary<string, bool>();
                dicSort.Add("CreatedDate", true);
                var dataPaged = await FindPagedAsync(1, int.MaxValue, m => m.CreatedDate > DateTimeHelper.MinSystemDate, dicSort, dbTransaction);
                if (dataPaged.TotalCount > 0)
                {
                    listData = dataPaged.Items.ToList<object>();
                }
                else
                {
                    return "";
                }
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

        public bool Delete(TEntity instance)
        {
            return _repository.Delete(instance);
        }

        public bool Delete(TEntity instance, TimeSpan? timeout)
        {
            return _repository.Delete(instance, timeout);
        }

        public bool Delete(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout)
        {
            return _repository.Delete(instance, transaction, timeout);
        }

        public bool Delete(Expression<Func<TEntity, bool>>? predicate)
        {
            return _repository.Delete(predicate);
        }

        public bool Delete(Expression<Func<TEntity, bool>>? predicate, TimeSpan? timeout)
        {
            return _repository.Delete(predicate, timeout);
        }

        public bool Delete(Expression<Func<TEntity, bool>>? predicate, IDbTransaction? transaction, TimeSpan? timeout)
        {
            return _repository.Delete(predicate, transaction, timeout);
        }

        public Task<bool> DeleteAsync(TEntity instance, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(instance, cancellationToken);
        }

        public Task<bool> DeleteAsync(TEntity instance, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(instance, cancellationToken);
        }

        public Task<bool> DeleteAsync(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(instance,transaction, timeout, cancellationToken);
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(predicate, cancellationToken);
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(predicate, timeout, cancellationToken);
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, IDbTransaction? transaction, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(predicate, transaction, timeout, cancellationToken);
        }

        public bool Insert(TEntity instance)
        {
            return _repository.Insert(instance);
        }

        public Task<bool> InsertAsync(TEntity instance)
        {
            return _repository.InsertAsync(instance);
        }

        public Task<bool> InsertAsync(TEntity instance, CancellationToken cancellationToken)
        {
            return _repository.InsertAsync(instance, cancellationToken);
        }

        public bool Insert(TEntity instance, IDbTransaction? transaction)
        {
            return _repository.Insert(instance, transaction);
        }

        public Task<bool> InsertAsync(TEntity instance, IDbTransaction? transaction)
        {
            return _repository.InsertAsync(instance, transaction);
        }

        public Task<bool> InsertAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            return _repository.InsertAsync(instance, transaction, cancellationToken);
        }

        public int BulkInsert(IEnumerable<TEntity> instances)
        {
            return _repository.BulkInsert(instances);
        }

        public Task<int> BulkInsertAsync(IEnumerable<TEntity> instances)
        {
            return _repository.BulkInsertAsync(instances);
        }

        public Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken)
        {
            return _repository.BulkInsertAsync(instances, cancellationToken);
        }

        public int BulkInsert(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            return _repository.BulkInsert(instances, transaction);
        }

        public Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            return _repository.BulkInsertAsync(instances, transaction);
        }

        public Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            return _repository.BulkInsertAsync(instances, transaction, cancellationToken);
        }

        public bool Update(TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Update(instance, includes);
        }

        public Task<bool> UpdateAsync(TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(instance, includes);
        }

        public Task<bool> UpdateAsync(TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(instance, includes);
        }

        public bool Update(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Update(instance, transaction, includes);
        }

        public Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(instance,transaction, includes);
        }

        public Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(instance, transaction, includes);
        }

        public bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Update(predicate, instance, includes);
        }

        public Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(predicate, instance, includes);
        }

        public Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(predicate, instance, cancellationToken, includes);
        }

        public bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Update(predicate, instance, transaction, includes);
        }

        public Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(predicate, instance, transaction, includes);
        }

        public Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.UpdateAsync(predicate, instance, transaction, includes);
        }

        public bool BulkUpdate(IEnumerable<TEntity> instances)
        {
            return _repository.BulkUpdate(instances);
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances)
        {
            return _repository.BulkUpdateAsync(instances);
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken)
        {
            return _repository.BulkUpdateAsync(instances, cancellationToken);
        }

        public bool BulkUpdate(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            return _repository.BulkUpdate(instances, transaction);
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            return _repository.BulkUpdateAsync(instances, transaction);
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            return _repository.BulkUpdateAsync(instances, transaction, cancellationToken);
        }

        public Task<int> ExecuteAsync(string sql, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var dynParams = new DynamicParameters();
            foreach (var item in parammeters)
            {
                if (item.Direction == ParameterDirection.Output)
                {
                    dynParams.Add(item.ParameterName, dbType: item.DbType, direction: item.Direction);
                }
                else
                {
                    dynParams.Add(item.ParameterName, item.Value, item.DbType, item.Direction);
                }
            }
            var commandDefinition = new CommandDefinition(sql, dynParams, dbTransaction, commandTimeout, commandType);
            return _repository.Connection.ExecuteAsync(commandDefinition);
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var dynParams = new DynamicParameters();
            foreach (var item in parammeters)
            {
                if (item.Direction == ParameterDirection.Output)
                {
                    dynParams.Add(item.ParameterName, dbType: item.DbType, direction: item.Direction);
                }
                else
                {
                    dynParams.Add(item.ParameterName, item.Value, item.DbType, item.Direction);
                }
            }
            var commandDefinition = new CommandDefinition(sql, dynParams, dbTransaction, commandTimeout, commandType);
            return _repository.Connection.QueryAsync<T>(commandDefinition);
        }

        #endregion Methods
    }
}