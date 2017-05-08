using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    public class Logins : ObservableObject
    {
        private int _id;
        private string _name;
        private byte[] _password;

        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id
        {
            get { return _id;;}
            set { Set(ref _id, value); }
        }


        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Name
        {
            get { return _name;}
            set { Set(ref _name, value); }
        }

        /// <summary>
        /// Hashvalue of the password
        /// </summary>
        [Required]
        public byte[] Password
        {
            get { return _password;}
            set { Set(ref _password, value); }
        }
    }
}