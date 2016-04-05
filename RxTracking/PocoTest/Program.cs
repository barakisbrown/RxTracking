using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PocoTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");

            var col = db.GetCollection<People>("People");

            var list = await col.Find(new BsonDocument()).ToListAsync();

            foreach (People P in list)
            {
               Console.WriteLine("Name = {0} /t City = {1} /t State = {2}",P.Name,P.City,P.State);
            }

            Console.ReadKey();
        }
    }

    public class People
    {
        public ObjectId id;
        public string Name;
        public string City;
        public string State;
    }
}
