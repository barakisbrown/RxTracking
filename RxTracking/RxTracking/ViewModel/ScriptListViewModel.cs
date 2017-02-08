using System;
using GalaSoft.MvvmLight;
using RxTracking.Model;

namespace RxTracking.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ScriptListViewModel : ViewModelBase
    {
        private string _title;
        private string _fullName;
        private User _userLogged = new User();

        /// <summary>
        /// Initializes a new instance of the ScriptListViewModel class.
        /// </summary>
        public ScriptListViewModel()
        {
            MessengerInstance.Register<User>(this, "LoggedInUser", user => GetUser(user));
            Title = "RxTracking Order List";
            FullName = Properties.Settings.Default._userName;
        }

        public void GetUser(User _user)
        {
            _userLogged = _user;
            FullName = _userLogged.FullName;
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                Console.WriteLine("The FullName is {0}", value);
                Set("FULLNAME", ref _fullName, value);
            }
        }

        public string Title
        {
            get { return _title; }
            set { Set("TITLE", ref _title, value); }
        }
    }
}