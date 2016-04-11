﻿using System.Collections.Generic;
using GalaSoft.MvvmLight;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RxTracking.Model
{
    public class User : ObservableObject
    {
        #region Private Fields
        private ObjectId _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _state;
        private string _zipCode;
        private Logins _logins;
        private List<Doctor> _doctors;
        #endregion

        #region Property Names
        private const string IdProperty = "ID";
        private const string FirstProperty = "FIRST";
        private const string MiddleProperty = "MIDDLE";
        private const string LastProperty = "LAST";
        private const string AddressProperty = "ADDRESS";
        private const string CityProperty = "CITY";
        private const string StateProperty = "STATE";
        private const string ZipCodeProperty = "ZIPCODE";
        private const string LoginsProperty = "LOGINS";
        private const string DoctorProperty = "DOCTORS";
        #endregion

        public User()
        {
            _firstName = "";
            _middleName = "";
            _lastName = "";
            _address = "";
            _city = "";
            _state = "";
            _zipCode = "";
            _logins = new Logins();
            _doctors = new List<Doctor>();
        }

        #region Public Properties

        [BsonElement("_id")]
        public ObjectId Id
        {
            get { return _id; }
            set { Set(IdProperty, ref _id, value); }
        }

        [BsonElement("first")]
        public string FirstName
        {
            get { return _firstName; }
            set { Set(FirstProperty, ref _firstName, value); }
        }

        [BsonElement("middle")]
        public string MiddleName
        {
            get { return _middleName; }
            set { Set(MiddleProperty, ref _middleName, value); }
        }

        [BsonElement("last")]
        public string LastName
        {
            get { return _lastName; }
            set { Set(LastProperty, ref _lastName, value); }
        }

        [BsonElement("address")]
        public string Address
        {
            get { return _address; }
            set { Set(AddressProperty, ref _address, value); }
        }

        [BsonElement("city")]
        public string City
        {
            get { return _city;}
            set { Set(CityProperty, ref _city, value); }
        }

        [BsonElement("state")]
        public string State
        {
            get { return _state; }
            set { Set(StateProperty, ref _state, value); }
        }

        [BsonElement("zipcode")]
        public string ZipCode
        {
            get { return _zipCode; }
            set { Set(ZipCodeProperty, ref _zipCode, value); }
        }

        [BsonElement("login")]
        public Logins Logins
        {
            get { return _logins;}
            set { Set(LoginsProperty, ref _logins, value); }
        }

        [BsonElement("doctors")]
        public List<Doctor> Doctors
        {
            get { return _doctors;}
            set { Set(DoctorProperty,ref _doctors, value); }
        }

        [BsonIgnore]
        public string FullName => FirstName + " " + MiddleName + " " + LastName;

        #endregion
    }
}