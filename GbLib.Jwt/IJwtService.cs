using System.Security.Claims;

namespace GbLib.Jwt
{
    public interface IJwtService
    {
        #region Methods
        public IEnumerable<string>? GetClaims(ClaimsPrincipal claimsPrincipal, string claimType);
        public IEnumerable<string>? GetClaims(string token, string claimType);
        string GenerateAccessToken(IEnumerable<Claim> claims, int expiredMinute = 0);
        string GenerateRefreshToken(); 
        public ClaimsPrincipal GetPrincipalFromToken(string token);
        #endregion Methods
    }
}