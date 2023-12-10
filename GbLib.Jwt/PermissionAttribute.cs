using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GbLib.Jwt
{
    public class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        // Kiểu thực hiện API
        public int[]? Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Nếu call từ localhost hoặc đằng sau KONG thì bỏ qua check permission
            if (context.HttpContext.Request.Host.Host == "localhost" || context.HttpContext.Request.Host.Host == "kong" || !context.HttpContext.Request.Headers.ContainsKey("x-via-kong"))
            {
                return;
            }
            var permission = (context.HttpContext.HasPermission(Permissions));
            if (!permission)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            return;
        }
    }

    public class PermissionAllAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        // Kiểu thực hiện API
        public int[]? Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Host.Host == "localhost" || context.HttpContext.Request.Host.Host == "kong" || !context.HttpContext.Request.Headers.ContainsKey("x-via-kong"))
            {
                return;
            }
            var permission = (context.HttpContext.HasPermissionAll(Permissions));
            if (!permission)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            return;
        }
    }
}