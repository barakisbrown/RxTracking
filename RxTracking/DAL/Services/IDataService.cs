using System.Collections.ObjectModel;

namespace DAL.Services
{
    public interface IDataService<T> where T : class
    {
        ObservableCollection<T> GetAll();
        T Get(int id);
        void Add(T newValue);
        int Count { get; }
        bool Remove(T t);
    }
}