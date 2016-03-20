using System;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Practices.ServiceLocation;

namespace RxTracking.ViewModel
{
    using System.Windows;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using Model;


    /// <summary>
    /// LoginViewModem for the LoginView
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region Private Fields
        private readonly ILoginService _loginService;
        private readonly Logins _logins;
        #endregion
        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            _logins = new Logins();
            LoginCommand = new RelayCommand(Login,CheckLogin);
            ContactCommand = new RelayCommand(Contact);                       
        }

        /// <summary>
        /// checks UserName and Password to see if they are empty. If so returns false otherwise true.
        /// False will keep the login button greyed out while true makes it clickable
        /// </summary>
        /// <returns>True or False depending if they are both empty</returns>
        private bool CheckLogin()
        {
            if ((_logins.UserName.Equals("")) || (_logins.Password.Equals(""))) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Login into the Application if the user credentials are okay.
        /// Might need to add some more login later on for someone trying to login into this multiple times.
        /// </summary>
        private void Login()
        {
            // Just testing to make sure I am getting the right values
            if (_loginService.loginOkay(_logins))
            {
                var msg = Properties.Settings.Default._LoginSuccessMsg + USER;
                MessageBox.Show(msg, Properties.Settings.Default._appName, MessageBoxButton.OK);
                // LAUNCH THE APP -- 
                Messenger.Default.Send(new NotificationMessage("Open OrderView"));
                return;
                // CHANGE THE RETURN TO THE VIEWMODEL of the Order Class once this is committed to github
            }
            // USER DOES NOT EXIST
            MessageBox.Show(Properties.Settings.Default._LoginErrorMsg,Properties.Settings.Default._appName, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Launches the Contact View and ViewModel
        /// </summary>
        private void Contact()
        {
            // Remove the following line after I have merged this since this will be the next thing I am working on
            Messenger.Default.Send(new NotificationMessage("Open ContactView"));

        }

        #region Public Properties
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ContactCommand { get; set; }

        public const string UserNameProperty = "USER";

        public string USER
        {
            get { return _logins.UserName; }
            set { _logins.UserName = value; }
        }

        public const string PasswordProperty = "PASS";

        public string PASS
        {
            get { return _logins.Password; }
            set { _logins.Password = value; }
        }

        // Header Msg Public Property
        public const string LoginHeaderMsg = "HEADER";

        public string HeaderMsg
        {
            get { return Properties.Settings.Default._LoginViewHeaderMsg; }            
        }
        #endregion
    }
}