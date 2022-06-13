using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Data
{
    public class DataContext : IDataContext
    {
        public IMongoDatabase DataDb { get; set; }

        public DataContext(IOptions<AppSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            DataDb = mongoClient.GetDatabase(options.Value.DatabaseName);
        }
    }
}
