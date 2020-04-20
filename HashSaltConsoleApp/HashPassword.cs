using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace HashSaltConsoleApp
{
    class HashPassword
    {
        public byte[] generateSalt()
        {
            byte[] salt = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            Convert.ToBase64String(salt);

            return salt;
        }

        public string HashPasswordHMACSHA1(string password, byte[] salt, int iterations)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: iterations,
            numBytesRequested: 32‬));

            return hashed;
        }
    }

}
