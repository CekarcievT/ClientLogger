using ClientLogger.Business.Infrastructure;
using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System;
using System.Collections.Generic;

namespace ClientLogger.Business.Service
{
    public class AuthenticationService: IAuthenticationService
    {
        private static string _userName = "Administrator";
        private static string _password = "Naloga12#";

        readonly ITokenService _tokenService;
        public AuthenticationService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public AuthorizationInfo Login(LoginUser user)
        {
            AuthorizationInfo authorizationInfo = new AuthorizationInfo();
            if(user.UserName == _userName && user.Password == _password)
            {
                DateTime expirationDate = DateTime.Now.AddHours(2);
                string token = _tokenService.CreateToken(user.UserName, expirationDate);

                authorizationInfo.UserName = user.UserName;
                authorizationInfo.Token = token;
                authorizationInfo.TokenIsValid = true;
            }
            return authorizationInfo;
        }

        public void Logout(LoginUser user)
        {
            List<RuleViolation> ruleViolations = new List<RuleViolation>();
            if (String.IsNullOrEmpty(user.UserName))
            {
                ruleViolations.Add(new RuleViolation("Username cannot be null"));
            }
            if (ruleViolations.Count > 0)
            {
                throw new RuleViolationException(ruleViolations);
            }
            try
            {
                _tokenService.InvalidateToken(user.UserName);
            } catch (Exception ex)
            {
                ruleViolations.Add(new RuleViolation(ex));
                throw new RuleViolationException(ruleViolations);
            }
        }
    }
}
