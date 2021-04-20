using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System;

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
            _tokenService.InvalidateToken(user.UserName);
        }
    }
}
