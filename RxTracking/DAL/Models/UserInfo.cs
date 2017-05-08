using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Models
{
    public class UserInfo : ObservableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private char[] _state;
        private char[] _zipCode;
        private char[] _phoneNumber;
        private string _email;        
        private int _loginId;

        public UserInfo()
        {
            _state = new char[2];
            _zipCode = new char[10];
            _phoneNumber = new char[13];
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        [Required]
        public string FirstName
        {
            get {return _firstName;}
            set { Set(ref _firstName, value); }
        }

        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        [Required]
        public string Address
        {
            get { return _address; }
            set { Set(ref _address, value); }
        }

        [Required]
        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }

        [Required, MaxLength(2)]
        public char[] State
        {
            get { return _state; }
            set { Set(ref _state, value); }
        }
        
        [Required, MaxLength(10)]
        public char[] ZipCode
        {
            get { return _zipCode;}
            set { Set(ref _zipCode, value); }
        }

        [Required, MaxLength(13)]
        public char[] PhoneNumber
        {
            get { return _phoneNumber;}
            set { Set(ref _phoneNumber, value); }
        }
        
        [Required]
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        /// <summary>
        /// Foreign Key to Logins Table
        /// </summary>
        [ForeignKey("Logins")]
        public int LoginId
        {
            get { return _loginId; }
            set { Set(ref _loginId, value); }
        }
    }
}