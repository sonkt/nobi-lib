using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public static class OptionsMiddlewareExtensions
    {
        #region Methods

        public static IApplicationBuilder UseOptionsMethod(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsMethodMiddleware>();
        }

        #endregion Methods
    }
    public class OptionsMethodMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        #endregion Fields

        #region Constructors

        public OptionsMethodMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion Constructors

        #region Methods

        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        private Task BeginInvoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] ?? "*" });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Authorization" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }

            return _next.Invoke(context);
        }

        #endregion Methods
    }

}
