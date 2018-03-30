using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using DAL.Context;
using DAL.Models;
using MySql.Data.MySqlClient;

namespace DAL.Services
{
    public class ScriptService : IDataService<Script>
    {
        private const string ConnectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";
        private ObservableCollection<Script> _collection;
        private static object _padlock = null;
        private static ScriptService _service;

        private ScriptService()
        {
            LoadCollection();
        }

        /// <summary>
        /// Gets 1 Instance of this class
        /// </summary>
        /// <returns>returns a brand new instance unless it exist</returns>
        public static ScriptService GetInstance()
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new ScriptService();
            }

            return _service;
        }

        /// <summary>
        /// Simply reloads the internal collection. Only used when a delete is called.
        /// </summary>
        private void LoadCollection()
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(conn, false))
                {
                    db.Scripts.Load();
                    _collection = db.Scripts.Local;
                }
            }
        }

        /// <summary>
        /// Adds a new script to the database
        /// </summary>
        /// <param name="script">Script in Question to be added</param>
        /// <param name="phoneNumber">Used to search for the user that needs it added</param>
        /// <param name="doctorName">Name of the doctor who prescribed it</param>
        public void Add(Script script, string phoneNumber, string doctorName)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(con, false))
                {
                    // search for the user who needs it
                    var U = db.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
                    // search for the doctor who prescribed it
                    var D = db.Doctors.FirstOrDefault(d => d.Name == doctorName);
                    // link the script to the user and the doctor
                    script.Users = U;
                    script.Doctors = D;
                    // add the script to the collection
                    db.Scripts.Add(script);
                    // Save to the database
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds a new Script 
        /// </summary>
        /// <param name="newScript">Script that needs to be added</param>
        public void Add(Script newScript)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(conn, false))
                {
                    if (newScript.Doctors == null) throw new NullReferenceException("Currently Script has 0 doctor. Please add one");
                    if (newScript.Users == null) throw new NullReferenceException("Currently Script has 0 user. Please Add one");
                    db.Scripts.Add(newScript);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Gets number of scripts
        /// </summary>
        /// <returns>Number of scripts</returns>
        public int Count => _collection.Count;

        /// <summary>
        /// Searches the collection for the id. If exist then returns the whole script otherwise returns null
        /// </summary>
        /// <param name="id">The id field that I am searhing for</param>
        /// <returns>Either returns null if id exist otherwise it returns script that I am looking to find</returns>
        public Script Get(int id)
        {
            foreach (var s in _collection)
            {
                if (s.ScriptId == id) return s;
            }

            return null;
        }

        /// <summary>
        /// returns a subset of the collection based on result of name being returned
        /// </summary>
        /// <param name="name">Name of the Prescription that I am looking for in my collection</param>
        /// <returns>An Collection of scripts that have the same name</returns>
        public ObservableCollection<Script> GetAll(string name)
        {
            return new ObservableCollection<Script>(_collection.Where(s => s.Name == name).ToList());
        }
        
        /// <summary>
        /// Returns the whole collection
        /// </summary>
        /// <returns>The whole collection contained in a Observable Collection</returns>
        public ObservableCollection<Script> GetAll()
        {
            return _collection;
        }

        /// <summary>
        /// Delete the script from the database but first determining
        /// if the script actually exist in the db.
        /// </summary>
        /// <param name="deletedScript">Script that needs deleted</param>
        /// <returns>boolean value weather script was deleted</returns>
        public bool Remove(Script deletedScript)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(con, false))
                {
                    // determine if deletedScript actually exist
                    bool exist = _collection.Contains(deletedScript);
                    if (!exist)
                        return false;
                    // Since it does exist, then delete it
                    db.Scripts.Attach(deletedScript);
                    db.Scripts.Remove(deletedScript);
                    // Was the deletion successful?
                    var result = db.SaveChanges();
                    // Lets update the local collection
                    LoadCollection();
                    // Return the result weather it was deleted correctly or not
                    // Result should be non zero
                    return result > 0;
                }
            }
        }
    }
}
