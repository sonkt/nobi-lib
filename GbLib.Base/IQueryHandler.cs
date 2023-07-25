using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        #region Methods

        Task<TResult> HandleAsync(TQuery query);

        #endregion Methods
    }
}
