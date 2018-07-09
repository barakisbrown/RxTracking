using System;
using System.Security.Cryptography;

namespace Service
{
    /// <summary>
    /// This class will be used to help create and verify login passwords
    /// Borrowd from the following url:
    /// http://http://geekswithblogs.net/Nettuce/archive/2012/06/14/salt-and-hash-a-password-in.net.aspx
    /// </summary>
    public class PasswordService
    {
        /// <summary>
        /// Given a password, it will generate a Salt/Hash Pair so that it can be stored
        /// in a DB. Much better implementation than plain text passwords
        /// </summary>
        /// <param name="password">Password that needs a salt and hash computed</param>
        /// <param name="hash">Hashed value of the password given</param>
        /// <param name="salt">Salted value of the password given</param>
        public static void SaltedHash(string password, out byte[] hash, out byte[] salt)
        {
            var saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetNonZeroBytes(saltBytes);
            string Salt = Convert.ToBase64String(saltBytes);
            string Hash = ComputeHash(Salt, password);
            salt = Convert.FromBase64String(Salt);
            hash = Convert.FromBase64String(Hash);
        }

        /// <summary>
        /// Given a password and a salt, compute a hash for it
        /// </summary>
        /// <param name="salt">Salt of the password that needs a hash generated</param>
        /// <param name="password">password that needs a hash computed</param>
        /// <returns></returns>
        private static string ComputeHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1000))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            }
        }

        /// <summary>
        /// Verifies that the password in question is the same password stored in the database
        /// by comparing the salt/hash to it.
        /// </summary>
        /// <param name="salt">Salted Value of password from Database</param>
        /// <param name="hash">Hashed Value of password from Database</param>
        /// <param name="password">The password that we are verifying</param>
        /// <returns></returns>
        public static bool Verify(string salt, string hash, string password)
        {
            return hash == ComputeHash(salt, password);
        }
    }

}
}