using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using DAL.Models;
using DbContext = DAL.Context.DbContext;

namespace DAL.Services
{
    public class UserService : IDataService<UserInfo>
    {
        private ObservableCollection<UserInfo> _users;
        private static UserService _userService;
        private static object padlock = null;


        private UserService()
        {
            
        }

        public static UserService GetInstance()
        {
            if (padlock is null)
            {
                padlock = new object();
                _userService = new UserService();
            }

            return _userService;
        }

        public ObservableCollection<UserInfo> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public void Add(UserInfo newValue)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}