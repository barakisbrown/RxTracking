namespace RxTracking.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using GalaSoft.MvvmLight;

    public class Logins : ObservableObject 
    {
        #region private properties

        private ObjectId _id;
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
        [BsonElement("_id")]
        public ObjectId ID
        {
            get { return _id; }
            set { Set(IdProperyName, ref _id, value); }
        }

        [BsonElement("username")]
        public string UserName
        {
            get { return _username;}
            set { Set(UserNamePropName, ref _username, value); }
        }

        [BsonElement("password")]
        public string Password
        {
            get { return _password; }
            set { Set(PasswordProperty, ref _password, value); }
        }

        #endregion Public Properties
    }
}
