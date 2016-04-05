namespace RxTracking.Services
{
    using RxTracking.Model;

    public interface IContactService
    {
        bool Save(Contact contact);
        bool Update(Contact contact);
        Contact LoadContact(string username);
    }
}
