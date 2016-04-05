using System.Collections.Generic;
using GalaSoft.MvvmLight;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RxTracking.Model
{
    public class User : ObservableObject
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        
        [BsonElement("first")]
        public string FirstName { get; set; }

        [BsonElement("middle")]
        public string MiddleName { get; set; }

        [BsonElement("last")]
        public string LastName { get; set; }
           
        [BsonElement("address")] 
        public string Address { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("zipcode")]
        public string ZipCode { get; set; }

        [BsonElement("login")]
        public Logins Logins { get; set; }

        [BsonElement("doctors")]
        public List<Doctor> Doctors { get; set; }

        [BsonIgnore]
        public string FullName => FirstName + " " + MiddleName + " " + LastName;
    }
}