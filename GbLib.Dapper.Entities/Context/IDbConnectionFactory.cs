using System.Data;

namespace GbLib.Dapper.Entities.Context
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();

        IDbTransaction GetDbTransaction();
    }
}