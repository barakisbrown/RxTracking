using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    /// <summary>
    /// Table of all the stores where prescriptions where purchased
    /// </summary>
    public class Stores : ObservableObject
    {
        // primary key
        private int _id;
        // Name of the drug store
        private string _storeName;

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
        /// Name of the Drug Store
        /// </summary>
        [Required]
        public string Name
        {
            get => _storeName;
            set => Set(ref _storeName, value);
        }

        /// <summary>
        /// Navigation Property for Order Table
        /// This table can only have 1 Order
        /// </summary>
        public virtual Orders Order { get; set; }
    }
}