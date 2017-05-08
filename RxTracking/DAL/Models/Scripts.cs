using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    public class Scripts : ObservableObject
    {
        private int _id;
        private string _doctorName;
        private string _name;
        private string _number;
        private string _type;
        private string _noc;
        private double _qty;
        private double _days;
        private double _refills;
        private DateTime _filledDateTime;
        private int _doctorId;
        private int _contactId;

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
        /// DoctorName that I will fill in later
        /// </summary>
        [NotMapped]
        public string DoctorName
        {
            get { return _doctorName; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Number
        {
            get { return _number;}
            set { Set(ref _number, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Type
        {
            get { return _type;}
            set { Set(ref _type, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Noc
        {
            get { return _noc; }
            set { Set(ref _noc, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public double Qty
        {
            get { return _qty; }
            set { Set(ref _qty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public double Days
        {
            get { return _days; }
            set { Set(ref _days, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public double Refills
        {
            get { return _refills;}
            set { Set(ref _refills, value); }
        }

        /// <summary>
        /// Date and Time Refilled
        /// </summary>
        public DateTime FilledDate
        {
            get { return _filledDateTime; }
            set { Set(ref _filledDateTime, value); }
        }

        /// <summary>
        /// Foreign Key to Doctors
        /// </summary>
        [ForeignKey("Doctors")]
        public int DoctorId
        {
            get { return _doctorId;}
            set { Set(ref _doctorId, value); }
        }

        /// <summary>
        /// Foreign Key to UsersInfo
        /// </summary>
        [ForeignKey("UserInfo")]
        public int ContactId
        {
            get { return _contactId; }
            set { Set(ref _contactId, value); }
        }
    }
}