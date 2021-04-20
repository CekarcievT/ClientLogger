using ClientLogger.Business.Models;

namespace ClientLogger.Business.Interfaces
{
    public interface IAuthenticationService
    {
        public AuthorizationInfo Login(LoginUser user);
        public void Logout(LoginUser user);
    }
}
