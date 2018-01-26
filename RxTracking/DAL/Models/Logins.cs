using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    public class Logins : ObservableObject
    {
        private int _id;
        private string _name;
        private byte[] _password;
        private byte[] _saltValue;

        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }


        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// Hashvalue of the password
        /// </summary>
        [Required]
        public byte[] Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        
        [Required]
        public byte[] Hash
        {
            get => _hash;
            set => Set(ref _hash, value);
        }

        public byte[] SaltValue
        {
            get => _saltValue;
            set => Set(ref _saltValue, value);
        }

        /// <summary>
        /// Navigation Property
        /// Logins to UserInfo will be 1 -> 0,1
        /// </summary>
        public virtual UserInfo User { get; set; }
    }
}
