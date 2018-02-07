using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;

namespace PasswordDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "boobsiebo";
            byte[] hash;
            byte[] salt;

            Console.WriteLine("Password = {0}",password);
            PasswordService.SaltedHash(password,out hash,out salt);
            Console.ReadKey();
            Console.WriteLine("Now lets see if these two are the same");
            var hashStr = Convert.ToBase64String(hash);
            var saltStr = Convert.ToBase64String(salt);
            Console.WriteLine("Are they the same? {0} ",PasswordService.Verify(saltStr,hashStr,password));
            Console.ReadKey();
        }
    }
}
