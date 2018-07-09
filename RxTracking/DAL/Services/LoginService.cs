using System;
using System.Collections.ObjectModel;
using System.Linq;
using DAL;
using DAL.Models;

namespace DAL.Services
{
    public class LoginService : IDataService<Logins>
    {
        private readonly MyDbContext _context;
        private static LoginService _service;
        private static object _padlock = null;

        /// <summary>
        /// Assign internal context to one passed to this class
        /// </summary>
        /// <param name="context">DbContext passed to this class</param>
        private LoginService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Created only 1 instance of this object.
        /// </summary>
        /// <param name="context">Context created by DbContext Class</param>
        /// <returns>Returns A LoginService Class</returns>
        public static LoginService GetInstance(MyDbContext context)
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new LoginService(context);
            }

            return _service;
        }

        /// <summary>
        /// Returns all Logins
        /// </summary>
        /// <returns>Collection of Logins</returns>
        public ObservableCollection<Logins> GetAll() => _context.Logins.Local;

        /// <summary>
        /// Based on the Id, return the Login
        /// </summary>
        /// <param name="id">the Login that is needed to be returned</param>
        /// <returns>Login that is returned</returns>
        public Logins Get(int id) => _context.Logins.Find(id);
        
        /// <summary>
        /// Adds a new Login since a User has also been added
        /// </summary>
        /// <param name="newLogin">The new Login to be added</param>
        public void Add(Logins newLogin)
        {
            if (newLogin.User == null)
                throw new NullReferenceException("User has not been created yet.");
            _context.Logins.Add(newLogin);
            _context.SaveChanges();
        }

        /// <summary>
        /// Returns number of logins 
        /// </summary>
        /// <returns>Number of Logins</returns>
        public int Count() => _context.Logins.Local.Count;

        /// <summary>
        /// Remove a login from the backend. Note, this will also remove the User.
        /// Once done, this removes ALL info for the User too.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Remove(Logins t)
        {
            throw new System.NotImplementedException();
        }
    }
}