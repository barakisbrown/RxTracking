using System.Collections.ObjectModel;

namespace DAL.Services
{
    public interface IDataService<T> where T : class
    {
        ObservableCollection<T> GetAll();
        void Add(T newValue);
        int Count();
    }
}