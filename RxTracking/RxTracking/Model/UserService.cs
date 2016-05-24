using System;
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
                if (CollectionExist())
                {
                    var col = ViewModelLocator.Users;
                    // SEE IF THE USERNAME EXIST
                    var count = col.CountAsync(x => x.Logins.UserName == usrname);

                    return (count.Result == 1);
                }
                return false;
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
                var result = col.Find(x => x.Logins.UserName == usr.Logins.UserName).FirstOrDefaultAsync();
                if (CollectionExist())
                {
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
                return false;
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
                var col = ViewModelLocator.Users;
                // DETERMINE IF THE THIS START OF THE APPLICATION SINCE LOGIN WILL NOT EXIST AT THIS POINT
                if (CollectionExist())
                {
                    var result = col.Find(x => x.Logins.UserName == login.UserName).FirstOrDefaultAsync();

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
                return false;
            }
        }

        public User GetUserInfo(Logins login)
        {
            if (login == null)
            {
                throw new NullReferenceException("Login is null");
            }
            else
            {
                var col = ViewModelLocator.Users;
                var result = col.Find(x => x.Logins.UserName == login.UserName).FirstOrDefaultAsync();

                return result?.Result;
            }
        }

        private bool CollectionExist()
        {
            var col = ViewModelLocator.Users;
            // DETERMINE IF THE THIS START OF THE APPLICATION SINCE LOGIN WILL NOT EXIST AT THIS POINT
            FilterDefinitionBuilder<User> user = new FilterDefinitionBuilder<User>();
            long count = col.Find<User>(user.Empty).Count();
            return (count > 0);

        }
    }
}