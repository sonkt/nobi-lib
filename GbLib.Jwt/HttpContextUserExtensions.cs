using Microsoft.AspNetCore.Http;

namespace GbLib.Jwt
{
    public static class HttpContextClaimsExtensions
    {
        #region Methods

        public static string? GetClaim(this HttpContext httpContext, string claimType)
        {
            return httpContext?.User?.Claims
               .Where(x => x.Type == claimType)
               .Select(x => x.Value)
               .FirstOrDefault();
        }

        public static bool HasPermission(this HttpContext httpContext, int[]? listPermission, string excerpt = "-1")
        {
            var permissionFromContext = httpContext?.User?.Claims?
                .Where(x => x.Type == JwtClaimsTypes.Permissions)?
                .Select(x => x.Value)?.ToList() ?? new List<string> { };
            var permissionFromInput = listPermission?.Select(p => p)?.ToList() ?? new List<int> { };
            if (permissionFromContext.Contains(excerpt)) return true;
            if (permissionFromInput == null || permissionFromContext == null)
            {
                return false;
            }
            else if (permissionFromInput.Any(x => permissionFromContext.Contains(x.ToString()))) // Nếu có bất kỳ quyền trong Input(của hàm) có trong Context (của User)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasPermissionAll(this HttpContext httpContext, int[]? listPermission, string excerpt = "-1")
        {
            var permissionFromContext = httpContext?.User?.Claims?
                .Where(x => x.Type == JwtClaimsTypes.Permissions)?
                .Select(x => x.Value)?.ToList() ?? new List<string> { };
            var permissionFromInput = listPermission?.Select(p => p)?.ToList()?? new List<int> { };
            // Nếu có quyền -1 tức là User Admin BA
            if (permissionFromContext.Contains(excerpt)) return true;
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

        public static bool IsAuthenticated(this HttpContext httpContext) => httpContext?.User?.Identity?.IsAuthenticated ?? false;

        #endregion Methods
    }
}