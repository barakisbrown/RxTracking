using DAL;
using DAL.Models;
using System;

namespace Service
{
    public class LoginService : ILogin
    {
        public bool CheckCredentials(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string usrName)
        {
            throw new NotImplementedException();
        }

        public UserInfo FetchUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
