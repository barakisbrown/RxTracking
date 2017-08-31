using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    public class Scripts : ObservableObject
    {
        private int _id;
        private string _name;
        private string _number;
        private string _type;
        private string _noc;
        private double _qty;
        private double _days;
        private double _maxRefills;
        private DateTime _filledDateTime;
        private int _doctorId;
        private int _contactId;
        private int _orderId;

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
        /// DoctorName that I will fill in later
        /// </summary>
        [NotMapped]
        public string DoctorName { get; }

        /// <summary>
        /// Name of the Prescription
        /// Ex: Fenofibrate
        /// </summary>
        [Required]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// Prescription Number
        /// Ex: 655727
        /// </summary>
        [Required]
        public string Number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        /// <summary>
        /// Type of does taken
        /// Ex: Cap / TAB
        /// </summary>
        [Required]
        public string Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        /// <summary>
        /// The NOC number on the prescription
        /// Ex: 00074-9642-90
        /// </summary>
        [Required]
        public string Noc
        {
            get => _noc;
            set => Set(ref _noc, value);
        }

        /// <summary>
        /// Number Pills Given
        /// Ex: 30.0
        /// </summary>
        [Required]
        public double Qty
        {
            get => _qty;
            set => Set(ref _qty, value);
        }

        /// <summary>
        /// How many days of supply
        /// Ex: 30.0
        /// </summary>
        [Required]
        public double Days
        {
            get => _days;
            set => Set(ref _days, value);
        }

        /// <summary>
        /// Current number of refills left
        /// Ex: 2.0
        /// </summary>
        [Required]
        public double MaxRefills
        {
            get => _maxRefills;
            set => Set(ref _maxRefills, value);
        }

        /// <summary>
        /// Date and Time Refilled
        /// </summary>
        public DateTime FilledDate
        {
            get => _filledDateTime;
            set => Set(ref _filledDateTime, value);
        }

        /// <summary>
        /// Foreign Key to Doctors
        /// </summary>
        [ForeignKey("Doctors")]
        public int DoctorId
        {
            get => _doctorId;
            set => Set(ref _doctorId, value);
        }

        /// <summary>
        /// Foreign Key to UsersInfo
        /// </summary>
        [ForeignKey("UserInfo")]
        public int ContactId
        {
            get => _contactId;
            set => Set(ref _contactId, value);
        }

        /// <summary>
        /// Foreign Key for Orders
        /// </summary>
        [ForeignKey("Orders")]
        public int OrderId
        {
            get => _orderId;
            set => Set(ref _orderId, value);
        }

        /// <summary>
        /// Navigation Property for Table Order
        /// Script belongs to 1 Order
        /// </summary>
        public virtual Orders Order { get; set; }

        /// <summary>
        /// Navigation Property for Table Doctor
        /// A script can only have 1 doctor
        /// </summary>
        public virtual Doctors Doctor { get; set; }

        /// <summary>
        /// Navigation Property for Table UserInfo
        /// A script can only have 1 User
        /// </summary>
        public virtual UserInfo User { get; set; }
    }
}
