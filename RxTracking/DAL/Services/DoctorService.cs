using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DAL.Models;
using MySql.Data.MySqlClient;

namespace DAL.Services
{
    public class DoctorService : IDataService<Doctor>
    {
        private const string ConnectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";

        private static Object _padlock = null;
        private static DoctorService _service;
        private ObservableCollection<Doctor> _collection;

        private DoctorService()
        {
            LoadCollection();
        }

        /// <summary>
        /// Returns a single instance of the DoctorService even if one exist already
        /// </summary>
        /// <returns>DoctorService Instance</returns>
        public static DoctorService GetInstance()
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _service = new DoctorService();
            }

            return _service;
        }

        /// <summary>
        /// Helper function that loads all the rows from the database into a collection
        /// so that class methods can access that need to instead of calling the database
        /// each time.
        /// </summary>
        private void LoadCollection()
        {
            using (var myConn = new MySqlConnection(ConnectionString))
            {
                using (var db = new Context.DbContext(myConn, false))
                {
                    db.Doctors.Load();
                    _collection = db.Doctors.Local;

                }
            }
        }

        /// <summary>
        /// Returns the number of Doctors that exist in the Database
        /// </summary>
        public int Count => _collection.Count;

        public void Add(Doctor newDcotor)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a collection of doctors
        /// </summary>
        /// <returns>ObservableCollection of Doctors</returns>
        public ObservableCollection<Doctor> GetAll()
        {
            return _collection;
        }

        /// <summary>
        /// Removes Doctor from the Database and all scripts associated with the doctor
        /// </summary>
        /// <param name="deletedDoctor">The doctor that is beign removed from the database</param>
        /// <returns>True/False depending if successful or not</returns>
        public bool Remove(Doctor deletedDoctor)
        {
            throw new NotImplementedException();
        }
    }
}
