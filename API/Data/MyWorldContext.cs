using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Data
{
    public class MyWorldContext : IMyWorldContext
    {
        public IMongoDatabase MyWorldDb { get; set; }

        public MyWorldContext(IOptions<AppSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            MyWorldDb = mongoClient.GetDatabase(options.Value.DatabaseName);
        }
    }
}
