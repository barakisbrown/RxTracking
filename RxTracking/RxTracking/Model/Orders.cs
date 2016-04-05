namespace RxTracking.Model
{
    using System;
    using GalaSoft.MvvmLight;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Model of an Order from a Rx Receipt
    /// </summary>
    public class Orders : ObservableObject
    {
        #region Private_Fields
        private ObjectId _id;
        private ObjectId _userId;
        private Items _item;
        private DateTime _purchaseDate;
        private double _refillsLeft;
        private double _cost;
        private bool _insurance;
        #endregion

        #region property names
        private const string IdPropertyName = "ID";
        private const string UserIdPropertyName = "UID";
        private const string ItemPropertName = "ITEMS";
        private const string PurchasePropertyName = "PURCHASE_DATE";
        private const string RefillPropertyName = "REFILLS";
        private const string CostPropertyName = "COST";
        private const string InsurancePropertyName = "INSURANCE";
        #endregion

        #region Public Properties
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id
        {
            get { return _id;}
            set { Set(IdPropertyName, ref _id, value); }
        }

        [BsonElement("_userID")]
        public ObjectId UserId
        {
            get { return _userId;}
            set { Set(UserIdPropertyName, ref _userId, value); }
        }

        [BsonElement("item")]
        public Items Item
        {
            get { return _item;}
            set { Set(ItemPropertName, ref _item, value); }
        }

        [BsonElement("purchaseDate")]
        public DateTime PurchaseDate
        {
            get { return _purchaseDate;}
            set { Set(PurchasePropertyName, ref _purchaseDate, value); }
        }

        [BsonElement("refillLeft")]
        public double RefillsLeft
        {
            get { return _refillsLeft; }
            set { Set(RefillPropertyName, ref _refillsLeft, value); }
        }

        [BsonElement("cost")]
        public double Cost
        {
            get { return _cost;}
            set { Set(CostPropertyName, ref _cost, value); }
        }

        [BsonElement("insurance")]
        public bool Insurance
        {
            get { return _insurance;}
            set { Set(InsurancePropertyName, ref _insurance, value); }
        }
        #endregion
    }
}