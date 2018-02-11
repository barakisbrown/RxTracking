using System;
using System.Collections.Generic;
using System.Security.Policy;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    /// <summary>
    /// Representation of a single Rx Ordered by the Doctor
    /// </summary>
    public class Script : ObservableObject
    {
        public Script()
        {
            Users = new HashSet<User>();
            Doctors = new HashSet<Doctor>();
        }

        #region BACKING_FIELDS       
        private int _scriptId;
        private string _rxNumber;
        private string _rxName;
        private string _doseType;
        private string _doseAmount;
        private string _ndc;
        private double _qty;
        private double _supply;
        private double _refillsLeft;
        private DateTime _fillDate;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// PRIMARY KEY
        /// </summary>
        public int ScriptId
        {
            get => _scriptId;
            set => Set(ref _scriptId, value);
        }

        /// <summary>
        /// The RxNumber used by the store when filling the script
        /// Ex => 410448
        /// </summary>
        public string Number
        {
            get => _rxNumber;
            set => Set(ref _rxNumber, value);
        }

        /// <summary>
        /// Name of the script being filled
        /// Ex => LISINOPRIL
        /// </summary>
        public string Name
        {
            get => _rxName;
            set => Set(ref _rxName, value);
        }

        /// <summary>
        /// Dose of the script being filled
        /// Ex => TAB
        /// </summary>
        public string DoseType
        {
            get => _doseType;
            set => Set(ref _doseType, value);
        }

        /// <summary>
        /// Amount of the Dose
        /// Ex => 40MG
        /// </summary>
        public string DoseAmount
        {
            get => _doseAmount;
            set => Set(ref _doseAmount, value);
        }

        /// <summary>
        /// NDC of the Script filled
        /// Ex => 68180-0517-01
        /// </summary>
        public string Ndc
        {
            get => _ndc;
            set => Set(ref _ndc, value);
        }

        /// <summary>
        /// The quantity of pills filled
        /// Ex => 30.0
        /// </summary>
        public double Qty
        {
            get => _qty;
            set => Set(ref _qty, value);
        }

        /// <summary>
        /// Days Supply Filled
        /// Ex => 30.0
        /// </summary>
        public double Supply
        {
            get => _supply;
            set => Set(ref _supply,value);
        }

        /// <summary>
        /// How many refills left
        /// Ex => 4.0
        /// </summary>
        public double RefillsLeft
        {
            get => _refillsLeft;
            set => Set(ref _refillsLeft, value);
        }

        /// <summary>
        /// Date which script was filled
        /// Ex. => 01/28/2013
        /// </summary>
        public DateTime FillDate
        {
            get => _fillDate;
            set => Set(ref _fillDate, value);
        }

        #endregion

        #region NAVIGATION PROPERTIES

        /// <summary>
        /// Each script belongs to 1 Doctor
        /// </summary>
        public virtual ICollection<Doctor> Doctors { get; set; }

        /// <summary>
        /// Each script belong to 1 User
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
            
        #endregion
    }
}