using System;
using DAL.Context;
using DAL.Models;

namespace DAL.Services
{
    public class UserService
    {
        private readonly DbContext _context;
        private static UserService _service;
        private static object _padlock = null;

        private UserService(DbContext context)
        {
            _context = context;
        }

        public static UserService GetInstance(DbContext context)
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new UserService(context);
            }

            return _service;
        }

        public bool Add(Login login)
        {
            if (login.User == null)
                throw new NullReferenceException("User has not been created yet");
            _context.Login.Add(login);
            var changes = _context.SaveChanges();
            return changes > 0;
        }
    }
}