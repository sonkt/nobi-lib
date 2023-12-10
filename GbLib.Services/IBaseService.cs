using GbLib.Base;
using GbLib.Entities;
using GbLib.ExcelLib;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace GbLib.Services
{
    public interface IBaseService<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
    {
        #region Methods

        Task<int> ExecuteAsync(string sql, SqlParameter[]? parammeters=null, IDbTransaction? dbTransaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, SqlParameter[]? parammeters=null, IDbTransaction? dbTransaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, int? numberOfItems, IDbTransaction? dbTransaction = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int? numberOfItems, IDbTransaction? dbTransaction = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, int? numberOfItems, IDbTransaction? dbTransaction = null);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int? numberOfItems, IDbTransaction? dbTransaction = null);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        Task<TEntity?> FindByIdAsync(TKey id, IDbTransaction? dbTransaction = null);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        TEntity? Find(Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool>? sortList, IDbTransaction? dbTransaction = null);

        TEntity? Find(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        TEntity? FindById(TKey id, IDbTransaction? dbTransaction = null);

        int Count(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string sortColumnName, bool descending = false, IDbTransaction? dbTransaction = null);

        Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool> sortList, IDbTransaction? dbTransaction = null);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, IDbTransaction? dbTransaction, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight, IDbTransaction? dbTransaction);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, bool hasIndexColumn);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle);

        List<ExcelGridColumn> GetExcelGridColumn(List<ExcelColumnModel> listColumns, bool listHasIndexColumn = false);

        List<ExcelGridColumn> GetExcelGridColumn(object entity, bool listHasIndexColumn = false);

        IDbTransaction GetDbTransaction();

        bool Delete(TEntity instance);

        bool Delete(TEntity instance, TimeSpan? timeout);

        bool Delete(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout);

        bool Delete(Expression<Func<TEntity, bool>>? predicate);

        bool Delete(Expression<Func<TEntity, bool>>? predicate, TimeSpan? timeout);

        bool Delete(Expression<Func<TEntity, bool>>? predicate, IDbTransaction? transaction, TimeSpan? timeout);

        Task<bool> DeleteAsync(TEntity instance, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(TEntity instance, TimeSpan? timeout, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, TimeSpan? timeout, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>>? predicate, IDbTransaction? transaction, TimeSpan? timeout, CancellationToken cancellationToken = default);

        bool Insert(TEntity instance);

        Task<bool> InsertAsync(TEntity instance);

        Task<bool> InsertAsync(TEntity instance, CancellationToken cancellationToken);

        bool Insert(TEntity instance, IDbTransaction? transaction);

        Task<bool> InsertAsync(TEntity instance, IDbTransaction? transaction);

        Task<bool> InsertAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken);

        int BulkInsert(IEnumerable<TEntity> instances);

        Task<int> BulkInsertAsync(IEnumerable<TEntity> instances);

        Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken);

        int BulkInsert(IEnumerable<TEntity> instances, IDbTransaction? transaction);

        Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction);

        Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken);

        bool Update(TEntity instance, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(TEntity instance, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);

        bool Update(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);

        bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);

        bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes);

        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);

        bool BulkUpdate(IEnumerable<TEntity> instances);

        Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances);

        Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken);

        bool BulkUpdate(IEnumerable<TEntity> instances, IDbTransaction? transaction);

        Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction);

        Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken);

        #endregion Methods
    }
}