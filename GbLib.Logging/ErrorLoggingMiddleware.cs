using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GbLib.Logging
{
    public class ErrorLoggingMiddleware
    {
        #region Fields

        private readonly ILogger<ErrorLoggingMiddleware> _logger;

        private readonly RequestDelegate _next;

        #endregion Fields

        #region Constructors

        public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled api exception!");
                throw;
            }
        }

        #endregion Methods
    }
}
