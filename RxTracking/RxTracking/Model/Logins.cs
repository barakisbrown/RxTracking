using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RxTracking.Model
{
    using GalaSoft.MvvmLight;

    public class Logins : ObservableObject 
    {
        #region private properties

        private string _id;
        private string _username;
        private string _password;

        #endregion
        public Logins()
        {
            UserName = "";
            Password = "";
        }
        #region Public Properties
        // CONST PROPERTY NAMES FOR EACH OF MY PROPERTIES
        public const string IdProperyName = "ID";
        public const string UserNamePropName = "Username";
        public const string PasswordProperty = "Password";

        [BsonId]
        public string ID
        {
            get { return _id; }
            set { Set(IdProperyName, ref _id, value); }
        }

        [BsonElement]
        public string UserName
        {
            get { return _username;}
            set { Set(UserNamePropName, ref _username, value); }
        }

        [BsonElement]
        public string Password
        {
            get { return _password; }
            set { Set(PasswordProperty, ref _password, value); }
        }

        #endregion Public Properties
    }
}
