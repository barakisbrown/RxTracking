using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoAuthTest
{
    class Program
    {
        static void Main(string[] args)
        {
           MainAsyncAuth(args).GetAwaiter().GetResult();
           //MainAsync(args).GetAwaiter().GetResult();
           Console.ReadKey();
        }

        static async Task MainAsyncAuth(string[] args)
        {
            var conn = "mongodb://rxStoreUser:rxStorePasswd@192.168.1.6/rxstore";

            var Client = new MongoClient(conn);
            var Database = Client.GetDatabase("rxstore");

            var col = Database.GetCollection<rxstore>("rxstore");

            var list = await col.Find(new BsonDocument()).ToListAsync();

            foreach (rxstore x in list)
            {
                Console.WriteLine("id = {0} and item = {1}", x._id, x.item);
            }
        }

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient("mongodb://192.168.1.6/rxstore");
            var db = client.GetDatabase("rxstore");

            var col = db.GetCollection<rxstore>("rxstore");

            var list = await col.Find(new BsonDocument()).ToListAsync();

            foreach (rxstore x in list)
            {
                Console.WriteLine("id = {0} and item = {1}", x._id, x.item);
            }
        }
}

    class rxstore
    {
        public ObjectId _id { get; set; }
        public string item { get; set; }
    }
}
