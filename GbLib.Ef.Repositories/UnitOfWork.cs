using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Runtime.CompilerServices;

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
            var result = (T)Activator.CreateInstance(typeof(T), context);
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

        public Task<List<T>> FromSql<T>(string sql) where T : class
        {
            return context.Database.SqlQuery<T>(FormattableStringFactory.Create(sql)).ToListAsync();
        }

        public Task<int> FromNonQuerySql(string sql, CancellationToken cancellationToken = default)
        {
            return context.Database.ExecuteSqlAsync(FormattableStringFactory.Create(sql), cancellationToken);
        }

        public List<T> FromStoreProcedure<T>(string storeName, SqlParameter[] sqlParameters) where T : class
        {
            var paramString = $"EXECUTE {storeName} ";
            var listParams = new List<string> { };
            foreach (var param in sqlParameters)
            {
                switch (param.Direction)
                {
                    case ParameterDirection.Output:
                        listParams.Add($" @{param.ParameterName} OUTPUT");
                        break;
                    case ParameterDirection.Input:
                    case ParameterDirection.InputOutput:
                    case ParameterDirection.ReturnValue:
                    default:
                        listParams.Add($" @{param.ParameterName}");
                        break;
                }
            }
            if (listParams.Count > 0)
            {
                paramString += string.Join(",", listParams);
            }
            return context.Database.SqlQueryRaw<T>(paramString,sqlParameters).ToList();
        }
    }
}