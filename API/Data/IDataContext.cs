using MongoDB.Driver;

namespace API.Data
{
    public interface IDataContext
    {
        IMongoDatabase DataDb { get; }
    }
}
