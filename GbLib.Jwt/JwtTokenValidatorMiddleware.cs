using Microsoft.AspNetCore.Http;
using System.Net;

namespace GbLib.Jwt
{
    public class JwtTokenValidatorMiddleware : IMiddleware
    {
        #region Fields

        private readonly IJwtService _jwtService;

        #endregion Fields

        #region Constructors

        public JwtTokenValidatorMiddleware(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        #endregion Constructors

        #region Methods

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _jwtService.IsCurrentActiveToken())
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }

        #endregion Methods
    }
}
