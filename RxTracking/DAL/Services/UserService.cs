using DAL.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using DAL;

namespace DAL.Services
{
    public class UserService : IDataService<UserInfo>
    {
        private readonly MyDbContext _context;
        private static UserService _userService;
        private static object _padlock = null;

        /// <summary>
        /// Assign internal context to one passed to this class
        /// </summary>
        /// <param name="context"></param>
        private UserService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Created only 1 instance of this object.
        /// </summary>
        /// <param name="context">Context created by DbContext Class</param>
        /// <returns>Returns A UserService Class</returns>
        public static UserService GetInstance(MyDbContext context)
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _userService = new UserService(context);
            }

            return _userService;
        }

        /// <summary>
        /// Returns all the Users Stored
        /// </summary>
        /// <returns>Returns all the Users</returns>
        public ObservableCollection<UserInfo> GetAll() => _context.Users.Local;

        /// <summary>
        /// Adds User to the backend. Checks to make sure it has to proper relationships setup to potentially
        /// check for database errors.
        /// </summary>
        /// <param name="newUser">User being added</param>
        public void Add(UserInfo newUser)
        {
            // REQUIRED SINCE Logins <=> UserInfo are 1 to 1
            if (newUser.Login == null)
                throw new NullReferenceException("No login created for this user");
            if (newUser.Doctors.Count < 1 || newUser.Doctors == null)
                throw new NullReferenceException("No Doctor Information Stored");
            else
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Returns the number of Users Exist
        /// </summary>
        /// <returns>Number of Users Returned</returns>
        public int Count() => _context.Users.Count();

        /// <summary>
        /// Returns the User from the context but if not found, contacts the backend for it.
        /// </summary>
        /// <param name="id">User trying to find</param>
        /// <returns>UserInfo for the User in question</returns>
        public UserInfo Get(int id) => _context.Users.Local.First(x => x.Id == id);

        /// <summary>
        /// Removes User from the backend
        /// </summary>
        /// <param name="user">The user that needs to be removed</param>
        /// <returns>True/False depending on the success of the removal</returns>
        public bool Remove(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }
}