using System.Data;

namespace GbLib.Entities.Context
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();

        IDbTransaction GetDbTransaction();
    }
}