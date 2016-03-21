namespace RxTracking.Model
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class LoginService : ILoginService
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _db;

        public LoginService()
        {
            _client = new MongoClient(Properties.Settings.Default._dbUrl);
            _db = _client.GetDatabase(Properties.Settings.Default._dbName);
        }

        public bool UserExist(string username)
        {
            if (username.Equals(""))
            {
                throw new ArgumentException("username has invalid data");
            }
            else
            {                              
                var col = _db.GetCollection<BsonDocument>(Properties.Settings.Default._loginCollectionName);

                // SEE IF THE USERNAME HAS BEEN TAKEN
                var filter = Builders<BsonDocument>.Filter.Eq("username", username);
                var count = col.Find(filter).Count();

                return count == 1;
            }

        }

        public bool CreateUser(Logins usr)
        {
            if (UserExist(usr.UserName))
            {
                try
                {
                    string crypted = global::BCrypt.Net.BCrypt.HashPassword(usr.Password);
                    var col = _db.GetCollection<BsonDocument>(Properties.Settings.Default._loginCollectionName);
                    var doc = new BsonDocument();
                    doc.Add("username", usr.UserName);
                    doc.Add("password", crypted);
                    col.InsertOne(doc);
                }
                catch (MongoWriteConcernException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                return true;

            }

            return false;
        }

        public bool LoginOkay(Logins usr)
        {
            if (usr == null)
            {
                throw new NullReferenceException("usr parameter is null");
            }
            else
            {
                var col = _db.GetCollection<BsonDocument>(Properties.Settings.Default._loginCollectionName);
                var filter = Builders<BsonDocument>.Filter.Eq("username", usr.UserName);
                var result = col.Find(filter).ToList();

                var match = global::BCrypt.Net.BCrypt.Verify(usr.Password, result[0].GetElement("password").Value.AsString);
                return match;
            }
        }
    }
}
