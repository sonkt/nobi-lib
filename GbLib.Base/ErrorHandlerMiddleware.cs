using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;

namespace GbLib.Base
{
    public class ErrorHandlerMiddleware
    {
        #region Fields

        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        private readonly RequestDelegate _next;

        private readonly ISelfInfoService _selfInfoServiceId;

        #endregion Fields

        #region Constructors

        public ErrorHandlerMiddleware(RequestDelegate next,
            ISelfInfoService selfInfoServiceId,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _selfInfoServiceId = selfInfoServiceId;
            _logger = logger;
            _next = next;
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = $"{_selfInfoServiceId.Name}:{_selfInfoServiceId.Id}"
            };

            switch (exception.InnerException)
            {
                case ArgumentNullException argumentNullException:
                    problemDetails.Title = nameof(argumentNullException);
                    problemDetails.Status = 400;
                    problemDetails.Detail = argumentNullException.Message;
                    break;

                case ArgumentException argumentException:
                    problemDetails.Title = nameof(argumentException);
                    problemDetails.Status = 400;
                    problemDetails.Detail = argumentException.Message;
                    break;

                case DuplicateNameException duplicateNameException:
                    problemDetails.Title = nameof(duplicateNameException);
                    problemDetails.Status = 400;
                    problemDetails.Detail = duplicateNameException.Message;
                    break;

                case FormatException formatException:
                    problemDetails.Title = nameof(formatException);
                    problemDetails.Status = 400;
                    problemDetails.Detail = formatException.Message;
                    break;

                case InvalidOperationException invalidOperationException:
                    problemDetails.Title = nameof(invalidOperationException);
                    problemDetails.Status = 400;
                    problemDetails.Detail = invalidOperationException.Message;
                    break;

                default:
                    problemDetails.Title = "An unexpected error occurred!";
                    problemDetails.Status = 500;
                    problemDetails.Detail = exception.StackTrace;
                    break;
            }

            if (problemDetails.Status.Value >= 500)
                _logger.LogError(exception, exception.Message);
            else
                _logger.LogDebug(exception, exception.Message);

            context.Response.StatusCode = problemDetails.Status.Value;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }

        #endregion Methods
    }
}