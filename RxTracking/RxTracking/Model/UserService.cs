using System;
using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Driver;
using RxTracking.ViewModel;

namespace RxTracking.Model
{
    public class UserService : IUserService
    {
        public bool UserExist(string usrname)
        {
            if (usrname.Equals(""))
            {
                throw new ArgumentException("username is empty.");
            }
            else
            {
                var col = ViewModelLocator.Users;
                // SEE IF THE USERNAME EXIST
                var filter = Builders<User>.Filter.Eq("login.username", usrname);
                var count = col.CountAsync(filter);

                return (count.Result == 1);
            }
        }

        public bool CreateUser(User usr)
        {
            try
            {
                string crypted = global::BCrypt.Net.BCrypt.HashPassword(usr.Logins.Password);
                var col = ViewModelLocator.Users;
                usr.Logins.Password = crypted;
                col.InsertOne(usr);
            }
            catch (MongoWriteConcernException e)
            {
                return false;
            }

            return true;
        }

        public bool LoginOkay(User usr)
        {
            if (usr == null)
            {
                throw new NullReferenceException("usr is null");
            }
            else
            {
                var col = ViewModelLocator.Users;
                var filter = Builders<User>.Filter.Eq("login.username", usr.Logins.UserName);
                var result = col.Find(filter).FirstOrDefaultAsync();

                if (result == null)
                {
                    return false;
                }
                else
                {
                    var pass = result.Result.Logins.Password;
                    var match = global::BCrypt.Net.BCrypt.Verify(usr.Logins.Password, pass);
                    return match;
                }
            }
        }

        public bool LoginOkay(Logins login)
        {
            if (login == null)
            {
                throw new NullReferenceException("Login is null");
            }
            else
            {
                var filter = Builders<User>.Filter.Eq("logins.username", login.UserName);
                var col = ViewModelLocator.Users;
                var result = col.Find(filter).FirstOrDefaultAsync();

                if (result == null)
                {
                    return false;
                }
                else
                {
                    var pass = result.Result.Logins.Password;
                    var match = global::BCrypt.Net.BCrypt.Verify(login.Password, pass);
                    return match;
                }

            }
        }
    }
}