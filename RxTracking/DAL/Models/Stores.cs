using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

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
            get { return _id;}
            set { Set(ref _id, value); }
        }

        /// <summary>
        /// Name of the Drug Store
        /// </summary>
        [Required]
        public string Name
        {
            get { return _storeName;}
            set { Set(ref _storeName, value); }
        }
    }
}