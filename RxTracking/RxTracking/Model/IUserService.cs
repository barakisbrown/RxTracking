namespace RxTracking.Model
{
    public interface IUserService
    {
        bool UserExist(string usrname);
        bool CreateUser(User usr);
        bool LoginOkay(User usr);
        bool LoginOkay(Logins login);
    }
}