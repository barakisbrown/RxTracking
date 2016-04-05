using GalaSoft.MvvmLight;

namespace RxTracking.Model
{
    public class Contact : ObservableObject
    {
        #region Private Fields

        private string _username = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _address = "";
        private string _city = "";
        private string _state = "";
        private string _zipCode = "";
        private string _phoneNumber = "";
        private Logins _login = new Logins();

        #endregion

        public Contact()
        {

        }

        #region PropertyNames 

        public const string UserNameProperty = "Username";
        public const string FirstNameProperty = "FirstName";
        public const string LastNameProperty = "LastName";
        public const string AddressProperty = "Address";
        public const string CityProperty = "City";
        public const string StateProperty = "State";
        public const string ZipCodeProperty = "ZipCode";
        public const string PhoneNumberProperty = "PhoneNumber";



        public string Username
        {
            get { return _username; }
            set { Set(UserNameProperty, ref _username, value); }
        }

        public string FirstName
        {
            get { return _firstName; }

            set { Set(FirstNameProperty, ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }

            set { Set(LastNameProperty, ref _lastName, value); }
        }

        public string Address
        {
            get { return _address; }

            set { Set(AddressProperty, ref _address, value); }
        }

        public string City
        {
            get { return _city; }

            set { Set(CityProperty, ref _city, value); }
        }

        public string State
        {
            get { return _state; }

            set { Set(StateProperty, ref _state, value); }
        }

        public string ZipCode
        {
            get { return _zipCode; }

            set { Set(ZipCodeProperty, ref _zipCode, value); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }

            set { Set(PhoneNumberProperty, ref _phoneNumber, value); }
        }

        #endregion
    }
}