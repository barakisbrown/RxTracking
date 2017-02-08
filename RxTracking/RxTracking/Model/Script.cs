namespace RxTracking.Model
{
    using GalaSoft.MvvmLight;
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Script : ObservableObject
    {
        #region PrivateFields
        private ObjectId _id;
        private DateTime _purchaseDate;
        private DateTime _refillDate;
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
        private const string RefillDatePropertName = "REFILLDATE";
        #endregion


        public Script()
        {
            _purchaseDate = DateTime.Now;
            _refillDate = DateTime.Now;
            _refillsLeft = 0;
            _cost = 0;
            _insurance = false;
        }

        #region Public Properties
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id
        {
            get { return _id; }
            set { Set(IdPropertyName, ref _id, value); }
        }

        [BsonElement("purchaseDate")]
        public DateTime PurchaseDate
        {
            get { return _purchaseDate; }
            set { Set(PurchasePropertyName, ref _purchaseDate, value); }
        }

        [BsonElement("refillDate")]
        public DateTime RefillDate
        {
            get { return _refillDate; }
            set { Set(RefillDatePropertName, ref _refillDate, value); }
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
            get { return _cost; }
            set { Set(CostPropertyName, ref _cost, value); }
        }

        [BsonElement("insurance")]
        public bool Insurance
        {
            get { return _insurance; }
            set { Set(InsurancePropertyName, ref _insurance, value); }
        }
        #endregion

    }
}
