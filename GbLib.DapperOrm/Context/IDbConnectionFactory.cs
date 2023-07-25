using System.Data;

namespace GbLib.DapperOrm.Context
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();
        IDbTransaction GetDbTransaction();

    }
}
