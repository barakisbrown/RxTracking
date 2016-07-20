namespace RxTracking.ViewModel
{
    using System.Windows;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using Model;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// LoginViewModem for the LoginView
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region Private Fields
        private readonly IUserService _userService;
        private readonly Logins _logins;
        #endregion
        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
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
            if ((string.IsNullOrEmpty(_logins.UserName)) || (string.IsNullOrEmpty(_logins.Password)))
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
            if (_userService.LoginOkay(_logins))
            {                
                Properties.Settings.Default._userName = _logins.UserName;
                Properties.Settings.Default.Save();
                Messenger.Default.Send(new NotificationMessage("OrderView"));
                Messenger.Default.Send(new NotificationMessage("Exit"));
            }
            else
            {
                // USER DOES NOT EXIST
                MessageBox.Show(Properties.Settings.Default._LoginErrorMsg, Properties.Settings.Default._appName,MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Launches the Contact View and ViewModel
        /// </summary>
        private void Contact()
        {           
            Messenger.Default.Send(new NotificationMessage("ContactView"));
        }

        #region Public Properties
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ContactCommand { get; set; }

        public const string UserNameProperty = "USER";

        public string User
        {
            get { return _logins.UserName; }
            set { _logins.UserName = value; }
        }

        public const string PasswordProperty = "PASS";

        public string Pass
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