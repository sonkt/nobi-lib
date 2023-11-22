using Dapper;
using GbLib.Entities;
using GbLib.Entities.Context;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;

namespace GbLib.Repositories
{
    public class DapperOrmRepository<TEntity, TId> : DapperRepository<TEntity>, IDapperOrmRepository<TEntity, TId>
         where TEntity : class, IAuditEntity<TId>
    {
        public DapperOrmRepository(IDbConnectionFactory dbConnectionFactory, ISqlGenerator<TEntity> sqlGenerator) : base(dbConnectionFactory.OpenDbConnection(), sqlGenerator)
        {
        }
    }
}