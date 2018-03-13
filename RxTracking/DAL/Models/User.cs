using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    /// <summary>
    /// Object represnting a single user
    /// Table Name => User
    /// </summary>
    public class User : ObservableObject
    {        
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Scripts = new HashSet<Script>();
        }

        #region BACKING FIELDS
        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _phoneNumber;
        private string _email;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Primary Key
        /// </summary>
        public int UserId
        {
            get => _userId;
            set => Set(ref _userId, value);
        }

        /// <summary>
        /// User First Name
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        /// <summary>
        /// User Last Name
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        /// <summary>
        /// User Full Name
        /// Note : Not mapped to the backend
        /// </summary>
        public string FullName => (_firstName + " " + _lastName);

        /// <summary>
        /// User Address
        /// </summary>
        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        /// <summary>
        /// User City
        /// </summary>
        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }

        /// <summary>
        /// User State of Resident
        /// Note : US Only
        /// </summary>
        public string State
        {
            get => _state;
            set => Set(ref _state, value);
        }

        /// <summary>
        /// User ZipCode
        /// </summary>
        public string ZipCode
        {
            get => _zipCode;
            set => Set(ref _zipCode, value);
        }

        /// <summary>
        /// User Phone Number
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        /// <summary>
        /// The user email
        /// </summary>
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }
        #endregion

        #region NAVIGATION PROPERTIES
        /// <summary>
        /// User is a 1..1 to Login
        /// </summary>
        public virtual Login Login { get; set; }

        /// <summary>
        /// User can have multiple doctors
        /// </summary>
        public virtual ICollection<Doctor> Doctors { get; set; }

        /// <summary>
        /// Multiple Scripts
        /// </summary>
        public virtual ICollection<Script> Scripts { get; set; }

        #endregion
    }
}