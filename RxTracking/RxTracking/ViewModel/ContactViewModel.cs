using GalaSoft.MvvmLight;
using RxTracking.Model;
using RxTracking.Services;

namespace RxTracking.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ContactViewModel : ViewModelBase
    {
        private ILoginService _loginService;
        private IContactService _contactService;
        private string _title;
        /// <summary>
        /// Initializes a new instance of the ContactViewModel class.
        /// </summary>
        public ContactViewModel(ILoginService loginService,IContactService contactService)
        {
            _loginService = loginService;
            _contactService = contactService;
            Title = "RxTracking Contact Creation Form";
        }

        public const string TitleProperty = "TITLE";

        public string Title
        {
            get { return _title; }
            set { Set(TitleProperty, ref _title, value); }
        }
    }
}