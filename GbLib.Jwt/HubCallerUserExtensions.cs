using Microsoft.AspNetCore.SignalR;

namespace GbLib.Jwt
{
    public static class HubCallerUserExtensions
    {
        #region Methods

        public static string GetAccessToken(this HubCallerContext httpContext)
        {
            return httpContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.AccessToken)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string GetEmail(this HubCallerContext callerContext)
        {
            return callerContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Email)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string GetId(this HubCallerContext callerContext)
        {
            return callerContext.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Id)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string GetNickname(this HubCallerContext callerContext)
        {
            return callerContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Nickname)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static string GetRole(this HubCallerContext callerContext)
        {
            return callerContext?.User?.Claims
                .Where(x => x.Type == JwtClaimsTypes.Role)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public static bool IsAdmin(this HubCallerContext callerContext) =>
            callerContext?.User?.IsInRole("admin") ?? false;

        public static bool IsAuthenticated(this HubCallerContext callerContext) =>
            callerContext?.User?.Identity?.IsAuthenticated ?? false;

        #endregion Methods
    }
}
