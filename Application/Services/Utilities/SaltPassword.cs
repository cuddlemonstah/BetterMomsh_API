
using System.Security.Cryptography;

namespace Application.Services.Utilities
{
    public class SaltPassword
    {
        public static byte[] GetRandomSalt(int length) {

            var rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            rng.GetNonZeroBytes(salt);
            return salt;
        }

        public static byte[] SaltHashPassword(byte[] password, byte[] salt) { 
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSalthBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++) {
                plainTextWithSalthBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSalthBytes[password.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSalthBytes);
        }
    }
}
