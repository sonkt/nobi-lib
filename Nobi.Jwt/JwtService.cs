using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Jwt
{
    public class JwtService : IJwtService
    {
        #region Fields

        private static readonly ISet<string> DefaultClaims = new HashSet<string>
        {
            JwtClaimsTypes.Sub,
            JwtClaimsTypes.UniqueName,
            JwtClaimsTypes.Jti,
            JwtClaimsTypes.Iat,
            JwtClaimsTypes.Role
        };

        private readonly IWebHostEnvironment _env;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        private readonly JwtOptions _options;

        private readonly SigningCredentials _signingCredentials;

        private readonly TokenValidationParameters _tokenValidationParameters;

        #endregion Fields

        #region Constructors

        public JwtService(JwtOptions options,
            IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _options = options;
            _httpContextAccessor = httpContextAccessor;
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
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

        public JsonWebToken CreateToken(string userId, string role = null, IList<Claim> claims = null)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User id claim can not be empty.", nameof(userId));
            }

            var now = DateTime.Now;
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtClaimsTypes.Sub, userId),
                new Claim(JwtClaimsTypes.UniqueName, userId),
                new Claim(JwtClaimsTypes.Name, userId),
                new Claim(JwtClaimsTypes.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtClaimsTypes.Iat, now.ToTimestamp().ToString()),
                new Claim(JwtClaimsTypes.Version,"1")
            };
            if (!string.IsNullOrWhiteSpace(role))
            {
                jwtClaims.Add(new Claim(JwtClaimsTypes.Role, role));
            }

            var customClaims = claims?.ToList() ?? new List<Claim>();

            jwtClaims.AddRange(customClaims);
            var expires = now.AddMinutes(_options.ExpiredMinutes);
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: _signingCredentials
            );
            var token = new JwtSecurityTokenHandler();
            token.InboundClaimTypeMap.Clear();
            var jwtToken = token.WriteToken(jwt);

            customClaims.Add(new Claim(JwtClaimsTypes.AccessToken, jwtToken));

            return new JsonWebToken
            {
                AccessToken = jwtToken
                //RefreshToken = string.Empty,
                //Expires = expires,
                //Id = userId,
                //Role = role ?? string.Empty,
                //Claims = customClaims.ToDictionary(c => c.Type, c => c.Value)
            };
        }

        public JsonWebToken CreateToken(string userId, string[] permission = null, IList<Claim> claims = null, string version = "1")
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User id claim can not be empty.", nameof(userId));
            }

            var now = DateTime.Now;
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtClaimsTypes.Jti, $"{Guid.NewGuid()}"),
                new Claim(JwtClaimsTypes.UserId, userId),
                new Claim(JwtClaimsTypes.ClientIP,_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()),
                new Claim(JwtClaimsTypes.Version,version)
            };
            if (permission != null && permission.Length > 0)
            {
                foreach (var item in permission)
                {
                    jwtClaims.Add(new Claim(JwtClaimsTypes.Role, item));
                }
            }

            var customClaims = claims?.ToList() ?? new List<Claim>();

            jwtClaims.AddRange(customClaims);
            var expires = now.AddMinutes(_options.ExpiredMinutes);
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: _signingCredentials
            );
            var token = new JwtSecurityTokenHandler();
            token.InboundClaimTypeMap.Clear();
            var jwtToken = token.WriteToken(jwt);

            //customClaims.Add(new Claim(JwtClaimsTypes.AccessToken, jwtToken));

            return new JsonWebToken
            {
                AccessToken = jwtToken
                //RefreshToken = string.Empty,
                //Expires = expires,
                //Id = userId,
                //Role = (permission != null && permission.Length > 0) ? string.Join(",", permission) : "",
                //Claims = customClaims.ToDictionary(c => c.Type, c => c.Value)
            };
        }

        public async Task DeactivateAsync(string token)
        {
            await Task.Delay(0);
        }

        public async Task DeactivateCurrentAsync() => await DeactivateAsync(GetCurrentAsync());

        public JsonWebTokenPayload GetTokenCurrentPayload()
        {
            return GetTokenPayload(GetCurrentAsync());
        }

        public JsonWebTokenPayload GetTokenPayload(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }
            _jwtSecurityTokenHandler.ValidateToken(
                accessToken,
                _tokenValidationParameters,
                out var validatedSecurityToken);

            if (!(validatedSecurityToken is JwtSecurityToken jwt))
            {
                return null;
            }

            return new JsonWebTokenPayload
            {
                Subject = jwt.Subject,
                Roles = jwt.Claims.Where(x => x.Type == JwtClaimsTypes.Role)?.Select(m => m.Value.ToString()).ToArray(),
                Expires = jwt.ValidTo,
                Claims = jwt.Claims.Where(x => !DefaultClaims.Contains(x.Type))
                    .ToDictionary(k => k.Type, v => v.Value)
            };
        }

        public Task<bool> IsActiveAsync(string token)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> IsActiveOnCacheAsync(string token)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            //foreach (var item in _options.ExceptPattern)
            //{
            //    if (httpContext.Request.Path.Value.Contains(item))
            //    {
            //        return true;
            //    }
            //}

            await Task.Delay(0);

            var currentPayload = GetTokenPayload(token);
            if (currentPayload == null)
            {
                return false;
            }
            string userName = currentPayload.Claims.FirstOrDefault(x => x.Key == "UserName").Value;

            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            string version = currentPayload.Claims.FirstOrDefault(x => x.Key == "ver").Value;

            if (!"1".Equals(version))
            {
                string cachedTokens = "";
                try
                {
                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "BAJWTService");
                    //cachedTokens = await httpClient.GetStringAsync($"{_options.TokenUri}{userName}");
                }
                catch
                {
                }

                if (string.IsNullOrEmpty(cachedTokens))
                {
                    return false;
                }

                cachedTokens = cachedTokens.Replace("[", "").Replace("]", "").Replace("\"", "");
                if (string.IsNullOrEmpty(cachedTokens)) return false;

                string[] listToken = cachedTokens.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (listToken.Length == 0) return false;

                string cachedToken = "";

                for (int i = 0; i < listToken.Length; i++)
                {
                    if (listToken[i] == token)
                    {
                        cachedToken = listToken[i];
                        break;
                    }
                }

                if (string.IsNullOrEmpty(cachedToken))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsCurrentActiveToken() => await IsActiveAsync(GetCurrentAsync());

        public async Task<bool> IsCurrentActiveTokenOnCache() => await IsActiveOnCacheAsync(GetCurrentAsync());

        private static string GetKey(string token) => $"tokens:{token}".ToUpper();

        private string GetCurrentAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext.Request.Path.StartsWithSegments("/vehicleOnlineHub"))
            {
                var accessToken = httpContext.Request.Query["access_token"];

                return accessToken;
            }

            var authorizationHeader = httpContext.Request.Headers["authorization"];

            return string.IsNullOrEmpty(authorizationHeader)
                ? string.Empty
                : authorizationHeader.Single().Split(' ').Last();
        }

        #endregion Methods
    }
}
