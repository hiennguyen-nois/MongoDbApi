using MongoDB.Driver;

namespace API.Data
{
    public interface IMyWorldContext
    {
        IMongoDatabase MyWorldDb { get; }
    }
}
