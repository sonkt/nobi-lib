using GbLib.Base;
using System.Linq.Expressions;

namespace GbLib.Ef.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

        Task<TEntity?> FindAsync(TKey id);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

        void Delete(TKey Id);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> filter);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);
    }
}