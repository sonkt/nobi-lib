using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GbLib.Jwt
{
    public class JwtService : IJwtService
    {
        #region Fields
        private readonly JwtOptions _options;
        private readonly SigningCredentials _signingCredentials;
        private readonly TokenValidationParameters _tokenValidationParameters;
        #endregion Fields

        #region Constructors
        public JwtService(JwtOptions options)
        {
            _options = options;
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey??""));
            _signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
            _tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = issuerSigningKey,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.ValidAudience,
                ValidateAudience = _options.ValidateAudience,
                ValidateLifetime = _options.ValidateLifetime
            };
        }
        #endregion Constructors

        #region Methods
        public string? GetClaim(ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal.Claims
               .Where(x => x.Type == claimType)
               .Select(x => x.Value)
               .FirstOrDefault();
        }



        public string GenerateAccessToken(IEnumerable<Claim> claims, int expiredMinute = 0)
        {
            var now = DateTime.Now;
            var expires = expiredMinute != 0 ? now.AddMinutes(expiredMinute) : now.AddMinutes(_options.ExpiredMinutes);
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.ValidAudience,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: _signingCredentials
            );
            var token = new JwtSecurityTokenHandler();
            token.InboundClaimTypeMap.Clear();
            var jwtToken = token.WriteToken(jwt);
            return jwtToken;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {           
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            _tokenValidationParameters.ValidateLifetime = false;
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            _tokenValidationParameters.ValidateLifetime = _options.ValidateLifetime;
            return principal;
        }

        #endregion Methods
    }
}