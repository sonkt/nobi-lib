using GbLib.Entities;
using MicroOrm.Dapper.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GbLib.Repositories
{
    public interface IDapperOrmRepository<TEntity, TId> : IDapperRepository<TEntity>
        where TEntity : class, IEntityBase<TId>
    { }
}