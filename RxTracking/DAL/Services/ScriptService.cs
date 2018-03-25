using System;
using System.Collections.ObjectModel;
using DAL.Models;

namespace DAL.Services
{
    public class ScriptService : IDataService<Script>
    {
        private static string connectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";

        public void Add(Script newValue)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Script Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Script> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Script t)
        {
            throw new NotImplementedException();
        }
    }
}
