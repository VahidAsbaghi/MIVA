using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Login.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Login.Infrastructure.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MivaAuthorizeAttribute:Attribute,IAuthorizationFilter
    {
        public IConfiguration Configuration { get; }

        public MivaAuthorizeAttribute(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenService= (TokenService)context.HttpContext.RequestServices.GetService(typeof(ITokenService));
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenResult = new JwtSecurityTokenHandler().ReadJwtToken(token);
            
            if (!tokenService.IsTokenValid(Configuration["Jwt:Key"], tokenResult.Issuer, token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
