using System;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    /// <summary>
    /// Representation of a SINGLE user Login
    /// </summary>
    public class Login : ObservableObject
    {
        // BACKING FIELDS
        private int _loginId;
        private string _name;
        private DateTime _firstLogged;
        private DateTime _lastLogged;
        private byte[] _hash;
        private byte[] _salt;

        // PROPERTIES

        /// <summary>
        /// Primary Key
        /// </summary>
        public int LoginId
        {
            get => _loginId;
            set => Set(ref _loginId, value);
        }

        /// <summary>
        /// Username
        /// </summary>
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// First Time the User Logged into the application
        /// </summary>
        public DateTime FirstLogged
        {
            get => _firstLogged;
            set => Set(ref _firstLogged, value);
        }

        /// <summary>
        /// Last Time the User Logged into the application
        /// </summary>
        public DateTime LastLogged
        {
            get => _lastLogged;
            set => Set(ref _lastLogged, value);
        }

        /// <summary>
        /// Hash of the password
        /// </summary>
        public byte[] Hash
        {
            get => _hash;
            set => Set(ref _hash, value);
        }

        /// <summary>
        /// Salt of the password
        /// </summary>
        public byte[] Salt
        {
            get => _salt;
            set => Set(ref _salt, value);
        }

        // NAVIGATION PROPERTIES
        public User User { get; set; }

    }
}