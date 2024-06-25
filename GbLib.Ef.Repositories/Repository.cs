using GbLib.Base;
using GbLib.Ef.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace GbLib.Ef.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        internal DbSet<TEntity> _dbSet;
        internal DbContext _context;

        public Repository(DbContext dbContext)
        {
            this._context = dbContext;
            this._dbSet = dbContext.Set<TEntity>();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.CountAsync();
        }

        public virtual void Delete(TKey Id)
        {
            TEntity? entityToDelete = _dbSet.Find(Id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var enties = _dbSet.Where(filter)?.ToList();
            if (enties != null)
            {
                foreach (var ent in enties)
                {
                    Delete(ent);
                }
            }
        }

        public virtual Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToListAsync();
            }
            else
            {
                return query.ToListAsync();
            }
        }

        public virtual Task<TEntity?> FindAsync(TKey id)
        {
            return _dbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Id.Equals(id));
        }

        public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter == null)
            {
                filter = m => m.IsDeleted != true;
            }
            return _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public virtual async Task<PaginationSet<TEntity>> FindPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            var items = new List<TEntity>();
            var skip = (pageNumber - 1) * pageSize;
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                items = await orderBy(query).Skip(skip).Take(pageSize).ToListAsync();
            }
            else
            {
                items = await query.Skip(skip).Take(pageSize).ToListAsync();
            }
            var totalRows = await query.CountAsync();
            return new PaginationSet<TEntity>
            {
                Items = items,
                TotalCount = totalRows
            };
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
    }
}