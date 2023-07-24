using System.Data;

namespace Nobi.DapperOrm.Context
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();
        IDbTransaction GetDbTransaction();

    }
}
