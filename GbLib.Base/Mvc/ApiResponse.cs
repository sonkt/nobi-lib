using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base.Mvc
{
    public class ApiResponse<TData> : BaseApiResponse where TData : class
    {
        #region Constructors

        public ApiResponse() : base()
        {
        }

        public ApiResponse(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public ApiResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }

        public ApiResponse(HttpStatusCode statusCode, TData data) : base(statusCode)
        {
            Data = data;
        }

        public ApiResponse(HttpStatusCode statusCode, TData data, string message) : base(statusCode, message)
        {
            Data = data;
        }

        public ApiResponse(HttpStatusCode statusCode, TData data, string message, string dataId) : base(statusCode, message, dataId)
        {
            Data = data;
        }

        public ApiResponse(TData data)
        {
            Data = data;
        }

        #endregion Constructors

        #region Properties

        public TData Data { get; set; }

        #endregion Properties
    }
}
