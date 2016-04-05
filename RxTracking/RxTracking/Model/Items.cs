using MongoDB.Bson.Serialization.Attributes;

namespace RxTracking.Model
{
    using System.Collections.Generic;
    using MongoDB.Bson;
    using System;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Model of how an item is described
    /// </summary>
    public class Items : ObservableObject
    {
        #region Private Fields
        private ObjectId _itemId;
        private string _doctorName;
        private string _rxNumber;
        private string _name;
        private string _typeName;
        private List<double> _strengths;
        private string _ndc;
        private double _qty;
        private double _days;
        private double _maxRefills;
        private DateTime _fillDate;
        #endregion

        #region Property Names
        private const string ItemIdProperty = "ID";
        private const string DoctorNameProperty = "DOCTOR";
        private const string RxNumberProperty = "RXNUMBER";
        private const string NameProperty = "NAME";
        private const string TypeProperty = "TYPE";
        private const string StrengthProperty = "STRENGTH";
        private const string NdcProperty = "NDC";
        private const string QtyProperty = "QTY";
        private const string DaysProperty = "DAYS";
        private const string MaxRefillsProperty = "MAX_REFILLS";
        private const string FillDateProperty = "FILLDATE";
        #endregion

        # region Public Properties
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id
        {
            get { return _itemId;}
            set { Set(ItemIdProperty, ref _itemId, value); }
        }

        [BsonElement("doctorName")]
        public string DoctorName
        {
            get { return _doctorName;}
            set { Set(DoctorNameProperty, ref _doctorName, value); }
        }

        [BsonElement("rxNumber")]
        public string RxNumber
        {
            get { return _rxNumber; }
            set { Set(RxNumberProperty, ref _rxNumber, value); }
        }

        [BsonElement("name")]
        public string Name
        {
            get
            {
                return _name;
            }

            set { Set(NameProperty, ref _name, value); }
        }

        [BsonElement("type")]
        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set { Set(TypeProperty, ref _typeName, value); }
        }

        [BsonElement("strength")]
        public List<double> Strengths
        {
            get
            {
                return _strengths;
            }

            set { Set(StrengthProperty, ref _strengths, value); }
        }

        [BsonElement("ndc")]
        public string Ndc
        {
            get
            {
                return _ndc;
            }

            set { Set(NdcProperty, ref _ndc, value); }
        }

        [BsonElement("qty")]
        public double Qty
        {
            get
            {
                return _qty;
            }

            set
            {
                Set(QtyProperty, ref _qty, value);
            }
        }

        [BsonElement("days")]
        public double Days
        {
            get { return _days; }
            set { Set(DaysProperty, ref _days, value);}
        }

        [BsonElement("maxrefills")]
        public double MaxRefills
        {
            get { return _maxRefills; }

            set { Set(MaxRefillsProperty, ref _maxRefills, value); }
        }

        [BsonElement("filldate")]
        public DateTime FillDate
        {
            get { return _fillDate; }
            set { Set(FillDateProperty, ref _fillDate, value); }
        }
        #endregion
    }
}