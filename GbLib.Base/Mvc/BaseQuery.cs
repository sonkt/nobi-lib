using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base.Mvc
{
    public class BaseQuery<TEntity, TResponse> : IRequest<PaginationSet<TResponse>>
        where TEntity : class
        where TResponse : class
    {
        #region Properties

        public Expression<Func<TEntity, bool>>? Condition { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public Dictionary<string, bool>? SortingColumnsList { get; set; }

        #endregion Properties
    }
}
