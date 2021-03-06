﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        private double _refillsLeft;
        private int _contactId;
        private int _storeId;


        public Orders()
        {
            Stores = new HashSet<Stores>();
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
        /// Foreign Key to UsersInfo
        /// </summary>
        [ForeignKey("UserInfo")]
        public int ContactId
        {
            get => _contactId;
            set => Set(ref _contactId, value);
        }

        /// <summary>
        /// Foreign Key to Stores
        /// </summary>
        [ForeignKey("Stores")]
        public int StoresId
        {
            get => _storeId;
            set => Set(ref _storeId, value);
        }

        /// <summary>
        /// Navigation Property for UserInfo Table
        /// Configured One to Many between UserInfo and Orders
        /// One Order can only have User
        /// </summary>
        public virtual UserInfo User { get; set; }

        /// <summary>
        /// Navigation Property for Stores Table
        /// This table have many Stores
        /// </summary>
        public virtual ICollection<Stores> Stores { get; set; }

        /// <summary>
        /// Navigation Property for Scripts Table
        /// 1 Order can have 1 Script
        /// </summary>
        public virtual Scripts Script { get; set; }
    }
}