using ClientLogger.Business.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ClientLogger.Business.Interfaces
{
    public interface ITokenService
    {
        public AuthorizationInfo ValidateToken(AuthorizationFilterContext filterContext);
        public string CreateToken(string username, DateTime expirationDate);
        public AuthorizationInfo ValidateToken(string token);
        public void InvalidateToken(string userName);

    }
}
