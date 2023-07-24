using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Nobi.Jwt
{
    public static class HttpContextClaimsExtensions
    {
        #region Methods

        public static string? GetAccessToken(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.AccessToken)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string? GetOrgnizationId(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.OrgnizationId)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string? GetOrgnizationType(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.OrgnizationType)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string? GetEmail(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Email)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string? GetHeaderAuthorizationString(HttpContext httpContext)
        {
            return httpContext.Request.Headers.Where(x => x.Key == "Authorization")?.FirstOrDefault().Value;
        }

        public static string? GetRequestToken(this HttpContext httpContext)
        {
            return httpContext.GetTokenAsync("access_token")?.Result;
        }

        public static string? GetRole(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Role)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static Guid GetUserID(this HttpContext httpContext)
        {
            try
            {
                var strGuid = httpContext?.User?.Claims
                    .Where(x => x.Type == JwtClaimsTypes.UserId)
                    .Select(x => x.Value)
                    .FirstOrDefault();
                return new Guid(strGuid);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string? GetUserName(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.UserName)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static IDictionary<string, string> GetConfigs(this HttpContext httpContext)
        {
            var confStr = httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Configs)
                .Select(x => x.Value)
                .FirstOrDefault();
            if (string.IsNullOrEmpty(confStr))
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return JsonConvert.DeserializeObject<IDictionary<string, string>>(confStr);
            }
        }

        public static string? GetUserType(this HttpContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.UserType)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static bool HasPermission(this HttpContext httpContext, int[] listPermission)
        {
            var permissionFromContext = httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Permission)
                .Select(x => x.Value).ToList();
            var permissionFromInput = listPermission.Select(p => p)?.ToList();
            // Nếu có quyền -1 tức là User Admin BA
            if (permissionFromContext.Contains("-1")) return true;
            if (permissionFromInput == null || permissionFromContext == null)
            {
                return false;
            }
            else if (permissionFromInput.Any(x => permissionFromContext.Contains(x.ToString())))// Nếu có bất kỳ quyền trong Input(của hàm) có trong Context (của User)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasPermissionAll(this HttpContext httpContext, int[] listPermission)
        {
            var permissionFromContext = httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Permission)
                .Select(x => x.Value).ToList();
            var permissionFromInput = listPermission.Select(p => p)?.ToList();
            // Nếu có quyền -1 tức là User Admin BA
            if (permissionFromContext.Contains("-1")) return true;
            // 2 mảng không có thằng nào
            if (permissionFromInput == null || permissionFromContext == null)
            {
                return false;
            }
            else if (permissionFromInput.All(x => permissionFromContext.Contains(x.ToString()))) // Nếu mọi quyền trong Input (của hàm) đều có trong  context(của user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasUserType(this HttpContext httpContext, int[] listUserTypes)
        {
            var result = true;

            var value = httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.UserType)
                .Select(x => x.Value)
                .FirstOrDefault();

            if (listUserTypes == null || value == null
                || (listUserTypes.Any(x => !value.Contains(x.ToString()))))
            {
                result = false;
            }

            return result;
        }

        public static bool IsAuthenticated(this HttpContext httpContext) => httpContext?.User?.Identity?.IsAuthenticated ?? false;

        #endregion Methods
    }
}
