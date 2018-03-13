using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace DAL.Models
{
    /// <summary>
    /// Representation of one doctor that a user 
    /// would be visiting and issuing scripts.
    /// </summary>
    public class Doctor : ObservableObject
    {
        #region BACKING FIELDS
        private int _doctorId;
        private string _name;
        private string _phoneNumber;
        private string _notes;
        private bool _specialist;
        private bool _primary;
        #endregion

        public Doctor()
        {
            Users = new HashSet<User>();
            Scripts = new HashSet<Script>();
        }

        #region Properties
        /// <summary>
        /// Primary Key
        /// </summary>
        public int DoctorId
        {
            get => _doctorId;
            set => Set(ref _doctorId, value);
        }

        /// <summary>
        /// Name of the Doctor
        /// </summary>
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// The Doctors Phone Number
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        /// <summary>
        /// Any notes
        /// </summary>
        public string Notes
        {
            get => _notes;
            set => Set(ref _notes, value);
        }

        /// <summary>
        /// True if specialist and false otherwise
        /// </summary>
        public bool Specialist
        {
            get => _specialist;
            set => Set(ref _specialist, value);
        }

        /// <summary>
        /// Is this doctor the user primary care physican
        /// </summary>
        public bool Primary
        {
            get => _primary;
            set => Set(ref _primary, value);
        }

        #endregion

        #region NAVIGATION PROPERTIES

        /// <summary>
        /// A doctor can have many users[Patients]
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// A doctor can write multiple RxScripts
        /// </summary>
        public virtual ICollection<Script> Scripts { get; set; }

        #endregion

    }
}