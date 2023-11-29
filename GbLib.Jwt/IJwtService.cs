using System.Security.Claims;

namespace GbLib.Jwt
{
    public interface IJwtService
    {
        #region Methods

        string GenerateAccessToken(IEnumerable<Claim> claims, int expiredMinute = 0);
        string GenerateRefreshToken(); 
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        #endregion Methods
    }
}