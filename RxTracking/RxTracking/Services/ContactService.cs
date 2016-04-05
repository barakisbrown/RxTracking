using MongoDB.Bson;
using MongoDB.Driver;
using RxTracking.Model; 

namespace RxTracking.Services
{
    public class ContactService : IContactService
    {
        private IMongoClient _client;
        private const string CollectionName = "Contacts";
        private IMongoDatabase _db; 
        private IMongoCollection<BsonDocument> _col;

        public bool Save(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Contact LoadContact(string username)
        {
            _client = new MongoClient(Properties.Settings.Default._dbUrl);
            _db = _client.GetDatabase(Properties.Settings.Default._dbName);            
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            var list = _col.Find(filter).ToList();
            var contact = new Contact();

            foreach (var doc in list)
            {
                // contact document
                contact.FirstName = doc.GetElement("last").Value.AsString;
                contact.Address = doc.GetElement("address").Value.AsString;
                contact.City = doc.GetElement("address").Value.AsString;
                contact.State = doc.GetElement("address").Value.AsString;
                contact.ZipCode = doc.GetElement("address").Value.AsString;
                contact.PhoneNumber = doc.GetElement("address").Value.AsString;
            }

            return contact;            
        }
    }
}