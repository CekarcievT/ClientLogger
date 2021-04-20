using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientLogger.Infrastructure
{
    public class CustomAuthorizationFilter : TypeFilterAttribute
    {
        public CustomAuthorizationFilter() : base(typeof(AuthorizationFilter))
        {
        }
    }
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ITokenService _tokenS;

        public AuthorizationFilter(ITokenService tokenS)
        {
            _tokenS = tokenS;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            AuthorizationInfo authorizationInfo;

            authorizationInfo = _tokenS.ValidateToken(filterContext);

            if (authorizationInfo == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (!authorizationInfo.TokenIsValid)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
