using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using CryptSharp;

namespace RxStoreTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new User() {username = "matthew", password = "Joebob"};
            var u1 = new User() {username = "barakis", password = "matthew"};

            testPassword(u);
            testPassword(u1);
            Console.ReadKey();
        }

        static void CreateUsers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("RxStore");
            var col = db.GetCollection<BsonDocument>("Logins");

            var usr1 = new User() {username = "matthew", password = "Garroth45"};
            var usr2 = new User() {username = "barakis",password = "matthew"};

            usr1.crtypedPassword = Crypter.Blowfish.Crypt(usr1.password);
            usr2.crtypedPassword = Crypter.Blowfish.Crypt(usr2.password);

            BsonDocument doc = new BsonDocument
            {
                {"username", usr1.username}, {"password", usr1.crtypedPassword},
            };

            BsonDocument doc2 = new BsonDocument
            {
                  {"username", usr2.username}, {"password", usr2.crtypedPassword},
            };

            col.InsertOne(doc);
            col.InsertOne(doc2);
            

        }

        static void testPassword(User test)
        {
            Console.WriteLine("Testing User with username {0}",test.username);
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("RxStore");
            var col = db.GetCollection<BsonDocument>("Logins");
            var filter = Builders<BsonDocument>.Filter.Eq("username", test.username);
            var result = col.Find(filter).ToList();

            bool match = Crypter.CheckPassword(test.password, result[0].GetElement("password").Value.AsString);
            if (match)
            {
                Console.WriteLine("Password Matched");
            }
            else
            {
                Console.WriteLine("Password did not Match");
            }
        }
    }

    public class User
    {        
        public string username { get; set; }
        public string password { get; set; }
        public string crtypedPassword { get; set; }
    }
}
