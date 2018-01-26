using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.Model
{
    public class PasswordTool
    {
        private static byte[] GenerateSalt()
        {
            int saltLength = 32;
            byte[] salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }


    }
}
