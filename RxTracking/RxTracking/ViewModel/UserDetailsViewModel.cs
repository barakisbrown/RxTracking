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
    public class UserDetailsViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private User _user = new User();
        private string _title;
        /// <summary>
        /// Initializes a new instance of the UserDetailsViewModel class.
        /// </summary>
        public UserDetailsViewModel(IUserService userService)
        {
            _userService = userService;
            Title = "RxTracking User Details Form";
        }

        public const string TitlePropertyName = "Title";
        public const string UserPropertyName = "User";

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
    }
}