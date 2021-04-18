using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ClientLogger.Business.Helpers
{
    public class CryptographyHelper
    {
        private static byte[] key = new byte[8] { 1, 6, 3, 7, 5, 9, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string SimpleEncrypt(string plainToken)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(plainToken);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            var outputString = Convert.ToBase64String(outputBuffer);

            return outputString;
        }

        public static string SimpleDecrypt(string encryptedToken)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(encryptedToken);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            var outputString = Encoding.Unicode.GetString(outputBuffer);

            return outputString;
        }
    }
}
