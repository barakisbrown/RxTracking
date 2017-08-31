using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    /// <summary>
    /// Single Doctor that the user has a prescription created by
    /// </summary>
    public class Doctors : ObservableObject
    {
        private int _id;
        private string _name;
        private char[] _phoneNumber;
        private string _notes;
        private bool _primary;

        /// <summary>
        /// Inits Scripts and User Collections
        /// </summary>
        public Doctors()
        {
            Scripts = new HashSet<Scripts>();
            Users = new HashSet<UserInfo>();
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

        /// <summary>
        /// Name of the Doctor
        /// </summary>
        [Required]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// PhoneNumber 000-000-0000
        /// </summary>
        [Required, MaxLength(13)]
        public char[] PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        /// <summary>
        /// Any notes by the user for this doctor
        /// </summary>
        public string Notes
        {
            get => _notes;
            set => Set(ref _notes, value);
        }

        /// <summary>
        /// Is he/she your primary care physician
        /// </summary>
        [Required]
        public bool Primary
        {
            get => _primary;
            set => Set(ref _primary, value);
        }

        /// <summary>
        /// Navigation Property to Scripts
        /// A doctor can have many scripts
        /// </summary>
        public virtual ICollection<Scripts> Scripts { get; set; }

        /// <summary>
        /// Navigation Property to UserInfo
        /// A doctor can have many UserInfo
        /// </summary>
        public virtual ICollection<UserInfo> Users { get; set; }
    }
}