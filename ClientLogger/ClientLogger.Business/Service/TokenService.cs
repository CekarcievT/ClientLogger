using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace ClientLogger.Business.Service
{
    public class TokenService : ITokenService
    {
        private IMemoryCache _cache;
        private readonly string _issuer = "ClientLogger";

        public TokenService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public virtual AuthorizationInfo ValidateToken(AuthorizationFilterContext filterContext)
        {
            string authorizationHeader = filterContext.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader == null)
            {
                return null;
            }

            string token = authorizationHeader.Split(' ').Last();

            var auhorizationInfo = this.ValidateToken(token);
            auhorizationInfo.Token = token;

            return auhorizationInfo;
        }


        public virtual string CreateToken(string userName, DateTime expirationDate)
        {
            AccessTokenInfo tokenInfo = new AccessTokenInfo();
            tokenInfo.Username = userName;
            tokenInfo.DateCreated = DateTime.UtcNow;
            tokenInfo.DateExpires = expirationDate;
            tokenInfo.Issuer = _issuer;

            string token = tokenInfo.Encrypt();
            var cacheOption = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(2));

            _cache.Set(userName, token, cacheOption);

            return token;
        }

        public virtual AuthorizationInfo ValidateToken(string token)
        {
            AuthorizationInfo resultAuthorizationInfo = new AuthorizationInfo();
            resultAuthorizationInfo.TokenIsValid = false;

            try
            {
                AccessTokenInfo tokenItem = AccessTokenInfo.Decrypt(token);

                string tokenCached;
                _cache.TryGetValue(tokenItem.Username, out tokenCached);

                if (tokenCached == token)
                {
                    if (tokenItem.Issuer != _issuer)
                    {
                        resultAuthorizationInfo.ErrorMessage = "Not Valid Token";
                        return resultAuthorizationInfo;
                    }
                }

                else
                {
                    resultAuthorizationInfo.ErrorMessage = "Not Valid Token";
                    return resultAuthorizationInfo;
                }

                resultAuthorizationInfo.TokenIsValid = true;
                resultAuthorizationInfo.UserName = tokenItem.Username;

            }
            catch
            {
                return resultAuthorizationInfo;
            }

            return resultAuthorizationInfo;

        }

        public void InvalidateToken(string userName)
        {
            // remove Token from Cache by key == UserName
            _cache.Remove(userName);
        }
    }
}
