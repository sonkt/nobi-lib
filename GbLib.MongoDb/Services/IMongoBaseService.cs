using GbLib.Base;
using GbLib.ExcelLib;
using GbLib.MongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace GbLib.MongoDb.Services
{
    public interface IMongoBaseService<TEntity> where TEntity : MongoEntityBase
    {
        #region Methods

        Task<bool> DeleteAsync(TEntity data, string collectionName = "");

        Task<bool> DeleteListAsync(List<TEntity> listData, string collectionName = "");

        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "");

        Task<ObjectId> InsertAsync(TEntity data, string collectionName = "");

        Task<List<ObjectId>> InsertListAsync(List<TEntity> listData, string collectionName = "");

        Task<bool> UpdateAsync(TEntity data, string collectionName = "");

        Task<bool> UpdateListAsync(List<TEntity> listData, string collectionName = "");

        Task<TEntity> GetById(ObjectId id, string collectionName = "");

        Task<TEntity> GetByCondition(FilterDefinition<TEntity> predicate, string collectionName = "");

        IMongoCollection<TEntity> GetCollection(string collectionName = "");

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, IDbTransaction? dbTransaction, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle);

        List<ExcelGridColumn> GetExcelGridColumn(List<ExcelColumnModel> listColumns, bool listHasIndexColumn = false);

        List<ExcelGridColumn> GetExcelGridColumn(object entity, bool listHasIndexColumn = false);

        #endregion Methods
    }
}