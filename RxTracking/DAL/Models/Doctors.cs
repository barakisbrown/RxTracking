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
        /// Primary Key
        /// </summary>
        [Key]
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        /// <summary>
        /// Name of the Doctor
        /// </summary>
        [Required]
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        /// <summary>
        /// PhoneNumber 000-000-0000
        /// </summary>
        [Required, MaxLength(13)]
        public char[] PhoneNumber
        {
            get { return _phoneNumber; }
            set { Set(ref _phoneNumber, value); }
        }

        /// <summary>
        /// Any notes by the user for this doctor
        /// </summary>
        public string Notes
        {
            get { return _notes; }
            set { Set(ref _notes, value); }
        }

        /// <summary>
        /// Is he/she your primary care physician
        /// </summary>
        [Required]
        public bool Primary
        {
            get { return _primary; }
            set { Set(ref _primary, value); }
        }
    }
}