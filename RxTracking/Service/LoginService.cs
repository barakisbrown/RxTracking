using DAL;
using DAL.Models;
using System;
using System.Linq;

namespace Service
{
    public class LoginService : ILogin
    {
        private MyDbContext _context;

        public LoginService(MyDbContext context)
        {
            _context = context;
        }

        public bool CheckCredentials(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string usrName)
        {
           var result = _context.Logins.FirstOrDefault(usr => usr.Name == usrName);

            return (result == null);
        }

        public UserInfo FetchUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
