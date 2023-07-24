using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.DapperOrm.Context
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();
        IDbTransaction GetDbTransaction();

    }
}
