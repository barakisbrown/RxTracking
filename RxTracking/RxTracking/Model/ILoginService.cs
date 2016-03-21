namespace RxTracking.Model
{
    public interface ILoginService
    {
        bool UserExist(string usrname );
        bool CreateUser(Logins usr);
        bool LoginOkay(Logins usr);

    }

}
