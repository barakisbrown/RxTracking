using GalaSoft.MvvmLight;

namespace RxTracking.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel()
        {
            TEMP = "HELLO WORLD";
        }

        private string _temp;
        public const string tempPropertyString = "TEMP";

        public string TEMP
        {
            get { return _temp; }
            set { Set(tempPropertyString, ref _temp, value); }
        }
    }
}