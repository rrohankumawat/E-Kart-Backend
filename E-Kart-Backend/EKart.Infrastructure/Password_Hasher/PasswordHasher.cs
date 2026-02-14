using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EKart.Infrastructure.Password_Hasher
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            const int saltSize = 16;
            const int hashSize = 32;
            const int iterations = 100_000;

            var salt = new byte[saltSize];
            RandomNumberGenerator.Fill(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(hashSize);

            // Store as: iterations.saltBase64.hashBase64
            return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public  static bool VerifyPassword(string stored, string providedPassword)
        {
            if (string.IsNullOrEmpty(stored))
            {
                return false;
            }

            var parts = stored.Split('.', 3);
            if (parts.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out var iterations))
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[1]);
            var storedHash = Convert.FromBase64String(parts[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, iterations, HashAlgorithmName.SHA256);
            var computedHash = pbkdf2.GetBytes(storedHash.Length);

            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }
    }
}
