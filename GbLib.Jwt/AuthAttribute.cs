using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GbLib.Jwt
{
    public class AuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Danh sách các quyền cẩn kiểm tra.
        /// </summary>
        public int[]? Permissions { get; set; }

        /// <summary>
        /// Chỉ định là phải có toàn bộ các quyền.
        /// </summary>
        public bool All { get; set; } = false;

        #region Constructors

        public AuthAttribute() : base()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.IsAuthenticated())
            {
                context.Result = new UnauthorizedResult();
            }
            if (Permissions != null && Permissions.Length > 0)
            {
                if (All)
                {
                    var permission = (context.HttpContext.HasPermissionAll(Permissions));
                    if (!permission)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
                else
                {
                    var permission = (context.HttpContext.HasPermission(Permissions));
                    if (!permission)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
            }
            return;
        }

        #endregion Constructors
    }

    #region Chuyển từ file PermissionAttribute sang đây rồi sau này xóa đi

    [Obsolete("Không khuyến khích sử dụng. Nên chuyển sang AuthAttribute")]
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

    [Obsolete("Không khuyến khích sử dụng. Nên chuyển sang AuthAttribute")]
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

    #endregion Chuyển từ file PermissionAttribute sang đây rồi sau này xóa đi
}