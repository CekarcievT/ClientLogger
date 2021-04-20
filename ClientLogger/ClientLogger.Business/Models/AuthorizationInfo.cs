namespace ClientLogger.Business.Models
{
    public class AuthorizationInfo
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool TokenIsValid { get; set; }
        public string ErrorMessage { get; set; }

    }
}
