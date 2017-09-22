using System.Collections.ObjectModel;
using System.Linq;
using DAL.Context;
using DAL.Models;

namespace DAL.Services
{
    /// <summary>
    /// StoreService is a DAL for the Store Table.
    /// Stores is just a list of drug stores where the user
    /// has prescriptions purchased from.
    /// </summary>
    public class StoreService : IDataService<Stores>
    {
        private readonly DbContext _context;
        private static StoreService _storeService;
        private static object _padlock;

        private StoreService(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a single instance of this Object for use
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns>StoreService Object</returns>
        public static StoreService GetInstance(DbContext context)
        {
            if (_padlock == null)
            {
                _padlock = new object();
                _storeService = new StoreService(context);
            }

            return _storeService;
        }

        /// <summary>
        /// Get All stores for this user
        /// </summary>
        /// <returns>Collection of stores for this user</returns>
        public ObservableCollection<Stores> GetAll() => _context.Stores.Local;

        /// <summary>
        /// Get a store based on an id
        /// </summary>
        /// <param name="id">Id of the store needed</param>
        /// <returns>Store requested by the user</returns>
        public Stores Get(int id) => _context.Stores.Find(id);


        /// <summary>
        /// TODO: TO BE IMPLEMENTED LATER
        /// Add a store to the list
        /// </summary>
        /// <param name="newValue">Store to be added</param>
        public void Add(Stores newValue)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Number of stores listed
        /// </summary>
        /// <returns>Count of Stores</returns>
        public int Count() => _context.Stores.Count();

        /// <summary>
        /// TODO: TO BE IMPLEMENTED LATER
        /// Remove a store from thee list based on a paticular store object
        /// </summary>
        /// <param name="t">store being removed</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool Remove(Stores t)
        {
            throw new System.NotImplementedException();
        }
    }
}