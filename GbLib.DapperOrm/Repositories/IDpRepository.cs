using MicroOrm.Dapper.Repositories;
using Microsoft.Data.SqlClient;
using GbLib.Base;
using GbLib.DapperOrm.Entities;
using System.Data;
using System.Linq.Expressions;

namespace GbLib.DapperOrm.Repositories
{
    public interface IDpRepository<TEntity, TId> : IDapperRepository<TEntity>
       where TEntity : class, IEntityBase<TId>
    {
        bool Add(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        Task<bool> AddAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        bool Add(TEntity entity, IDbTransaction? dbTransaction = null);
        Task<bool> AddAsync(TEntity entity, IDbTransaction? dbTransaction = null);

        bool Delete(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        Task<bool> DeleteAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        bool Delete(TEntity entity, IDbTransaction? dbTransaction = null);
        Task<bool> DeleteAsync(TEntity entity, IDbTransaction? dbTransaction = null);

        bool Update(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        Task<bool> UpdateAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null);
        bool Update(TEntity entity, IDbTransaction? dbTransaction = null);
        Task<bool> UpdateAsync(TEntity entity, IDbTransaction? dbTransaction = null);

        Task<int> ExecuteRawSql(string sql, IDbTransaction? dbTransaction = null);
        Task<int> ExecuteStoreProcedure(string storeProcedureName, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, IDbTransaction? dbTransaction = null);

        Task<List<SqlParameter>> ExecuteStoreProcedureWithOutput(string storeProcedureName, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null);
        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string sortColumnName, bool descending = false, IDbTransaction? dbTransaction = null);
        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool> sortList, IDbTransaction? dbTransaction = null);
        IEnumerable<TEntity> GetObjects(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);
        Task<TEntity> GetObject(TId id, IDbTransaction? dbTransaction = null);
        Task<TEntity> GetObject(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null);

        void Detach(TEntity entity);
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }
}
