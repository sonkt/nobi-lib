using Newtonsoft.Json;
using System.Net;

namespace GbLib.Base.Mvc
{
    public class BaseApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Messages { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public BaseApiResponse()
        {
        }

        public BaseApiResponse(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }

        public BaseApiResponse(HttpStatusCode httpStatusCode, string message)
        {
            StatusCode = httpStatusCode;
            Messages = message;
        }

        public BaseApiResponse(HttpStatusCode httpStatusCode, string message, string dataId)
        {
            StatusCode = httpStatusCode;
            Messages = message;
            DataId = dataId;
        }

        public string DataId { get; set; }
    }
}