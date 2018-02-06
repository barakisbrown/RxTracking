using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// This represents a singal Prescription that anyone has puchased at a store.
    /// Also, an order comprises of the following even they are elsewhere:
    ///     1. UserInfo
    ///     2. Doctor Information
    ///     3. Script
    /// 
    /// </summary>
    public class Orders : ObservableObject
    {
        private int _id;
        private string _number;
        private string _name;
        private decimal _cost;
        private DateTime _purchaseDateTime;
        private bool _insurance;
        private double _refillsLeft;
        
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
        /// Number of the Script that I will fill in later
        /// This will be pulled from a list of scripts I have stored
        /// ex. 655727
        /// </summary>
        [NotMapped]
        public string Number => _number;

        /// <summary>
        /// Name of the scipt that I will fill in later
        /// This will be pulled from a list of scripts I have stored
        /// ex. Fenobirate
        /// </summary>
        [NotMapped]
        public string Name { get { return _name; } }

        /// <summary>
        /// Cost of the script that I purchaed in this order
        /// </summary>
        public decimal Cost
        {
            get => _cost;
            set => Set(ref _cost, value);
        }

        /// <summary>
        /// Date and Time purchased
        /// </summary>
        public DateTime PurchaseDate
        {
            get => _purchaseDateTime;
            set => Set(ref _purchaseDateTime, value);
        }

        /// <summary>
        /// Insurance used or not
        /// </summary>
        public bool Insurance
        {
            get => _insurance;
            set => Set(ref _insurance, value);
        }

        /// <summary>
        /// Current number of refills left
        /// </summary>
        public double RefillsLeft
        {
            get => _refillsLeft;
            set => Set(ref _refillsLeft, value);
        }
       
        /// <summary>
        /// Navigation Property for UserInfo Table
        /// Configured One to Many between UserInfo and Orders
        /// One Order can only have User
        /// </summary>
        public virtual UserInfo User { get; set; }

        /// <summary>
        /// Navigation Property for Stores Table
        /// Each order can have 0..1 stores
        /// </summary>
        public Stores Store { get; set; }

        /// <summary>
        /// Navigation Property for Scripts Table
        /// 1 Order can have 1 Script
        /// </summary>
        public virtual Scripts Script { get; set; }
    }
}