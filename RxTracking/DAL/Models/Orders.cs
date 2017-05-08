using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;

namespace DAL.Models
{
    public class Orders : ObservableObject
    {
        private int _id;
        private string _number;
        private string _name;
        private decimal _cost;
        private DateTime _purchaseDateTime;
        private bool _insurance;
        private int _contactId;
        private int _storeId;

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
        /// Number of the Script that I will fill in later
        /// ex. 655727
        /// </summary>
        [NotMapped]
        public string Number { get {return _number;} }

        /// <summary>
        /// Name of the scipt that I will fill in later
        /// ex. Fenobirate
        /// </summary>
        [NotMapped]
        public string Name { get { return _name; } }

        /// <summary>
        /// Cost of the script that I purchaed in this order
        /// </summary>
        [Required]
        public decimal Cost
        {
            get { return _cost;}
            set { Set(ref _cost, value); }
        }

        /// <summary>
        /// Date and Time purchased
        /// </summary>
        public DateTime PurchaseDate
        {
            get { return _purchaseDateTime;;}
            set { Set(ref _purchaseDateTime, value); }
        }

        /// <summary>
        /// Insurance used or not
        /// </summary>
        public bool Insurance
        {
            get { return _insurance;}
            set { Set(ref _insurance, value); }
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

        /// <summary>
        /// Foreign Key to Stores
        /// </summary>
        [ForeignKey("Stores")]
        public int StoresId
        {
            get { return _storeId; }
            set { Set(ref _storeId, value); }
        }
    }
}