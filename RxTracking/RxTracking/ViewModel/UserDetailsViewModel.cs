namespace RxTracking.ViewModel
{
    using System.Windows;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using Model;
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserDetailsViewModel : ViewModelBase
    {
        // PRIVATE FIELDS
        private readonly IUserService _userService;
        private User _user = new User();
        private Doctor _doc = new Doctor();
        private Logins _logins = new Logins();        
        private string _title;
        private string _submitCreateBtn;
        private string _cancelResetBtn;
        private string _password;
        private string _confirmPassword;
        private string _state;
        private string _username;

        // PUBLIC FIELDS
        // PROPERTY NAMES LISTING
        public const string TitlePropertyName = "Title";
        public const string UserPropertyName = "User";
        public const string LoginsPropertyName = "LOGINS";
        public const string UsernamePropertyName = "USERNAME";
        public const string StatePropertyName = "STATE";
        public const string VerifyPasswordPropertyName = "VERIFY PASSWORD";
        public const string PasswordPropertyName = "PASSWORD";
        public const string SubmitCreatePropertyName = "SubmitCreateProperty";
        // END PROPERTY NAMES LISTING
        public RelayCommand SubmitCancelCommand { get; set; }
        public RelayCommand CancelResetCommand { get; set; }
        public ObservableCollection<US_STATES> _US_STATES { get; set; }
        /// <summary>
        /// Initializes a new instance of the UserDetailsViewModel class.
        /// </summary>
        public UserDetailsViewModel(IUserService userService)
        {
            _userService = userService;
            Title = Properties.Settings.Default._userDetailsTItle;
            SubmitCreateBtn = "Create User";
            CancelResetBtn = "Cancel";
            SubmitCancelCommand = new RelayCommand(SubmitUser);
            CancelResetCommand = new RelayCommand(CancelUser);
            _US_STATES = new ObservableCollection<US_STATES>();
            LoadStates();
        }

        private void LoadStates()
        {
            _US_STATES = US_STATES.GetAllStates();
        }

        public string Title
        {
            get { return _title; }
            set { Set(TitlePropertyName, ref _title, value); }
        }

        public User User
        {
            get { return _user;}
            set { Set(UserPropertyName, ref _user, value); }
        }

        public Doctor Doc
        {
            get { return _doc; }
            set { Set(DoctorPropertyName, ref _doc, value); }
        }

        public string UserName
        {
            get { return _username; }
            set { Set(UserPropertyName, ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { Set(PasswordPropertyName, ref _password, value); }
        }

        public string VerifyPassword
        {
            get { return _confirmPassword; }
            set { Set(VerifyPasswordPropertyName, ref _confirmPassword, value); } 
        }

        public string SelectedState
        {
            get { return _state; }
            set { Set(StatePropertyName, ref _state, value); }
        }
        
        /// <summary>
        /// Gets or sets the value of the <see cref="SubmitCreateBtn" />
        /// property.
        /// </summary>
        public string SubmitCreateBtn
        {
            get { return _submitCreateBtn; }
            set { Set(SubmitCreatePropertyName, ref _submitCreateBtn, value); }
        }

        /// <summary>
        /// The <see cref="CancelResetPropertyName" /> property name.
        /// </summary>
        public const string CancelResetPropertyName = "CANCELRESET";
        public const string DoctorPropertyName = "DOCTOR";

        /// <summary>
        /// Gets or sets the value of the <see cref="CancelResetBtn" />
        /// property.
        /// </summary>
        public string CancelResetBtn
        {
            get { return _cancelResetBtn; }
            set { Set(CancelResetPropertyName, ref _cancelResetBtn, value); }
        }       

        private void CancelUser()
        {
            Messenger.Default.Send(new NotificationMessage("CANCEL"));
        }

        private void SubmitUser()
        {
            if (!_userService.UserExist(_logins.UserName))
            {
                if (_password.Equals(_confirmPassword))
                {
                    // PASSWORD MATCH CRITERIA PASSED
                    // LOGIN INFORMATION
                    _logins.UserName = _username;
                    _logins.Password = _password;

                    // EXTRA USER INFORMATION
                    _user.State = _state;
                    
                    // EXTRA DOCTOR INFORMATION
                    _doc.Primary = true;
                    // Create the User
                    _user.Doctors.Add(_doc);
                    _user.Logins = _logins;
                    _userService.CreateUser(_user);
                    // USER CREATED .. CLOSING FORM AND RETURNING BACK TO LOGIN FOR THE USER TO LOGIN
                    Messenger.Default.Send(new NotificationMessage("SUBMIT"));
                }
                else
                {
                    // PASSWORD DOES NOT MATCH..LET THE USER KNOW
                    MessageBox.Show(Properties.Settings.Default._passwordNotMatch, Properties.Settings.Default._appName, MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default._usernameExists, Properties.Settings.Default._appName, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}