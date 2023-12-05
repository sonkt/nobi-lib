using System.Security.Claims;

namespace GbLib.Jwt
{
    public interface IJwtService
    {
        #region Methods
        public string? GetClaim(ClaimsPrincipal claimsPrincipal, string claimType);
        string GenerateAccessToken(IEnumerable<Claim> claims, int expiredMinute = 0);
        string GenerateRefreshToken(); 
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        #endregion Methods
    }
}