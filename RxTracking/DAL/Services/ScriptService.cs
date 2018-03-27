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
        private readonly ObservableCollection<Script> _collection;
        private static object _padlock = null;
        private static ScriptService _service;

        private ScriptService()
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(conn,false))
                {
                    db.Scripts.Load();
                    _collection = db.Scripts.Local;
                }
            }
        }

        public static ScriptService GetInstance()
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new ScriptService();
            }

            return _service;
        }


        public void Add(Script script, string phoneNumber, string doctorName)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(con, false))
                {
                    var U = db.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
                    var D = db.Doctors.FirstOrDefault(d => d.Name == doctorName);
                    script.Users = U;
                    script.Doctors = D;
                    db.Scripts.Add(script);
                    db.SaveChanges();
                }
            }
        }

        public void Add(Script newValue)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _collection.Count;
        }

        public Script Get(int id)
        {
            return _collection.FirstOrDefault(s => s.ScriptId == id);
        }

        public ObservableCollection<Script> GetAll()
        {
            return _collection;
        }

        public bool Remove(Script t)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var db = new DAL.Context.DbContext(con, false))
                {
                    var count = db.Scripts.Count();
                    db.Scripts.Attach(t);
                    db.Scripts.Remove(t);
                    db.SaveChanges();
                    return count > db.Scripts.Count();
                }
            }
        }
    }
}
