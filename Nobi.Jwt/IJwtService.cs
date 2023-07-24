using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Jwt
{
    public interface IJwtService
    {
        #region Methods

        JsonWebToken CreateToken(string userId, string role = null, IList<Claim> claims = null);

        JsonWebToken CreateToken(string userId, string[] role = null, IList<Claim> claims = null, string version = "1");

        Task DeactivateAsync(string token);

        Task DeactivateCurrentAsync();

        JsonWebTokenPayload GetTokenCurrentPayload();

        JsonWebTokenPayload GetTokenPayload(string accessToken);

        Task<bool> IsActiveAsync(string token);

        Task<bool> IsActiveOnCacheAsync(string token);

        Task<bool> IsCurrentActiveToken();

        Task<bool> IsCurrentActiveTokenOnCache();

        #endregion Methods
    }
}
