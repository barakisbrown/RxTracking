using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DAL.Models;
using MySql.Data.MySqlClient;

namespace DAL.Services
{
    public class UserService : IDataService<User>
    {
        private const string ConnectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";
        private ObservableCollection<User> _collection;
        private static UserService _service;
        private static object _padlock = null;

        private UserService()
        {
            LoadCollection();
        }

        /// <summary>
        /// Get 1 instance of this class
        /// </summary>
        /// <returns>Keeps 1 instance active only if that instance has never existed.</returns>
        public static UserService GetInstance()
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new UserService();
            }

            return _service;
        }

        public bool Add(Login login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a collection that has all the users
        /// stored in it.
        /// </summary>
        /// <returns>ObservableCollection of Users</returns>
        public ObservableCollection<User> GetAll()
        {
            return _collection;
        }

        /// <summary>
        /// Searches collection for the id and then returns the user 
        /// that the id belongs to if it exist.
        /// </summary>
        /// <param name="id">Id of the user need to be returned</param>
        /// <returns>The user that the id belongs too else returns null if it could not find it</returns>
        public User Get(int id)
        {
            foreach (var user in _collection)
            {
                if (user.UserId == id) return user;
            }

            return null;
        }

        /// <summary>
        /// Adds a new user to the collection and the database
        /// </summary>
        /// <param name="newUser">user being added</param>
        public void Add(User newUser)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var db = new Context.DbContext(conn,false))
                {
                    // need to check some endpoints to make sure they exist
                    if (newUser.Login == null) throw new NullReferenceException("User does not have a Login");
                    if (newUser.Doctors == null) throw new NullReferenceException("User does not have any Doctors");
                    if (newUser.Scripts == null) throw new NullReferenceException("User does not have any Scripts");
                    // Add this user to the collection
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get number of users
        /// </summary>
        /// <returns>Number of Users</returns>
        public int Count => _collection.Count;

        /// <summary>
        /// Removes the user from the database
        /// WARNING : Since the user is central to the whole database, once removed it will
        /// then delete other tables where this user did exist.
        /// </summary>
        /// <param name="deletedUser">User that needs to be deleted</param>
        /// <returns>true if successful / false otherwise</returns>
        public bool Remove(User deletedUser)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var db = new Context.DbContext(con, false))
                {
                    // Does deltedUser exist
                    bool exist = _collection.Contains(deletedUser);
                    if (!exist) return false;
                    // since user exist, delete it
                    db.Users.Attach(deletedUser);
                    db.Users.Remove(deletedUser);
                    // was the deletion successful
                    var result = db.SaveChanges();
                    // Lets update the local collection
                    LoadCollection();
                    // return the result
                    return result > 0;
                }
            }
        }


        /// <summary>
        /// Loads the collection from the database so that the class then can use it
        /// when needed.
        /// </summary>
        private void LoadCollection()
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var db = new Context.DbContext(conn, false))
                {
                    db.Scripts.Load();
                    _collection = db.Users.Local;
                }
            }
        }
    }
}