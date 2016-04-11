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
    public abstract class UserDetailsViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly User _user = new User();
        /// <summary>
        /// Initializes a new instance of the UserDetailsViewModel class.
        /// </summary>
        public UserDetailsViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public User Usr
        {
            get { return _user; }
        }       
    }
}