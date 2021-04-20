using ClientLogger.Business.Helpers;
using Newtonsoft.Json;
using System;

namespace ClientLogger.Business.Models
{
    public class AccessTokenInfo
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateExpires { get; set; }
        public string Username { get; set; }
        public string Issuer { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string Encrypt()
        {
            string tokenAsString = this.ToString();

            return CryptographyHelper.SimpleEncrypt(tokenAsString);
        }

        public static AccessTokenInfo Decrypt(string encryptedToken)
        {
            string decrypted = CryptographyHelper.SimpleDecrypt(encryptedToken);

            AccessTokenInfo token = JsonConvert.DeserializeObject<AccessTokenInfo>(decrypted);

            return token;
        }
    }
}
