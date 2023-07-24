using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Jwt
{
    public class AuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
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
        }

        #endregion Constructors
    }
}
