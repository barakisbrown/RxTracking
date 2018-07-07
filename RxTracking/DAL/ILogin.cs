using DAL.Models;

namespace DAL
{
    /// <summary>
    /// Interface for my Login Object. I am using it to check the following:
    /// A. Given a username, does it exist
    /// B. Given a usename and password, does it exist
    /// C. Fetch the Userinfo Info based on those valid credentials
    /// </summary>
    public interface ILogin
    {
        bool CheckUser(string usrName);
        bool CheckCredentials(string userName, string userPassword);
        UserInfo FetchUser(string userName);
    }
}