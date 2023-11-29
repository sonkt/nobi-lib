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
            // -1 là quyền của Root
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