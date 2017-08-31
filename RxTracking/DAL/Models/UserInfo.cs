namespace DAL.Models
{
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// UserInfo Object to Table Representation
    /// </summary>
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

        public UserInfo()
        {
            _state = new char[2];
            _zipCode = new char[10];
            _phoneNumber = new char[13];
            Orders = new HashSet<Orders>();
            Scripts = new HashSet<Scripts>();
            Doctors = new HashSet<Doctors>();
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        [Required]
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        [Required]
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        [Required]
        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        [Required]
        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }

        [Required, MaxLength(2)]
        public char[] State
        {
            get => _state;
            set => Set(ref _state, value);
        }
        
        [Required, MaxLength(10)]
        public char[] ZipCode
        {
            get => _zipCode;
            set => Set(ref _zipCode, value);
        }

        [Required, MaxLength(13)]
        public char[] PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }
        
        [Required]
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }  
        
        /// <summary>
        /// Navigation Property for Logins
        /// UserInfo to Logins is 1 to 1
        /// </summary>
        public virtual Logins Login { get; set; }

        /// <summary>
        /// Navigation Property for Orders
        /// UserInfo can have many Orders
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }

        /// <summary>
        /// Navigation Property for Scripts
        /// UserInfo can have many Scripts
        /// </summary>
        public virtual ICollection<Scripts> Scripts { get; set; }

        /// <summary>
        /// Navigation Property for Doctors
        /// UserInfo can have many Doctors
        /// </summary>
        public virtual ICollection<Doctors> Doctors { get; set; }
    }
}