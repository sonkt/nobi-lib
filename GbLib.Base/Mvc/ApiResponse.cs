using System.Net;

namespace GbLib.Base.Mvc
{
    public class ApiResponse<TData> where TData : class
    {
        #region Constructors

        public ApiResponse()
        {
        }

        public ApiResponse(HttpStatusCode statusCode)
        {
            Code = statusCode;
        }

        public ApiResponse(HttpStatusCode statusCode, string message)
        {
            Messages = message;
            Code = statusCode;
        }

        public ApiResponse(HttpStatusCode statusCode, TData data)
        {
            Data = data;
            Code = statusCode;
        }

        public ApiResponse(HttpStatusCode statusCode, TData data, string message)
        {
            Data = data;
            Messages = message;
            Code = statusCode;
        }

        public ApiResponse(TData data)
        {
            Data = data;
        }

        #endregion Constructors

        #region Properties

        public string Messages { get; set; }
        public HttpStatusCode Code { get; set; }
        public TData Data { get; set; }

        #endregion Properties
    }
}