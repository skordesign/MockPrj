using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MockPrj.Data
{
    public static class Protector
    {
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                 password: password,
                 salt: Encoding.UTF8.GetBytes("SIMSencrypt_a28efsd0h2"),
                 prf: KeyDerivationPrf.HMACSHA1,
                 iterationCount: 10000,
                 numBytesRequested: 256 / 8
                 ));
        }
    }
}
