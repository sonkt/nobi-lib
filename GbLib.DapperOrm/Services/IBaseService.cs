using GbLib.Base;
using GbLib.DapperOrm.Entities;
using GbLib.ExcelLib;
using System.Data;
using System.Linq.Expressions;

namespace GbLib.DapperOrm.Services
{
    public interface IBaseService<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
    {
        #region Methods

        Task<bool> DeleteAsync(List<TEntity> listData, IDbTransaction? dbTransaction = null);

        Task<bool> DeleteAsync(TEntity data, IDbTransaction? dbTransaction = null);

        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string sortColumnName, bool descending = false, IDbTransaction? dbTransaction = null);

        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool> sortList, IDbTransaction? dbTransaction = null);

        Task<TEntity> GetObjectById(TKey id, IDbTransaction? dbTransaction = null);
        Task<TEntity> GetObjectByCondition(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        Task<bool> InsertAsync(List<TEntity> listData, IDbTransaction? dbTransaction = null);

        Task<bool> InsertAsync(TEntity data, IDbTransaction? dbTransaction = null);

        Task<bool> UpdateAsync(List<TEntity> listData, IDbTransaction? dbTransaction = null);

        Task<bool> UpdateAsync(TEntity data, IDbTransaction? dbTransaction = null);

        Task<string> ExportExcel(List<object> listData, List<ExcelColumnModel> listColumns, string reportTitle, int titleRowHeight = 40, IDbTransaction? dbTransaction = null);
        List<ExcelGridColumn> GetExcelGridColumn(List<ExcelColumnModel> listColumns, bool listHasIndexColumn = false);
        List<ExcelGridColumn> GetExcelGridColumn(object entity, bool listHasIndexColumn = false);

        IDbTransaction GetDbTransaction();

        #endregion Methods
    }
}
