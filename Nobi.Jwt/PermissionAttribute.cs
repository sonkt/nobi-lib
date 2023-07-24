using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Jwt
{
    public class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        // Kiểu thực hiện API
        public int[] Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // -1 là quyền của BA Admin
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
        public int[] Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // -1 là quyền của BA Admin
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
