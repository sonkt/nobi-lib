using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace GbLib.Ef.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private TContext context;
        private bool disposed = false;

        public UnitOfWork(TContext dbContext)
        {
            context = dbContext;
        }      

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T GetRepository<T>() where T : class
        {
            var result = (T)Activator.CreateInstance(typeof(T),context);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public virtual int CommitChange()
        {
            return context.SaveChanges();
        }

        public IDbContextTransaction GetDbTransaction()
        {
            return context.Database.BeginTransaction();
        }
    }
}