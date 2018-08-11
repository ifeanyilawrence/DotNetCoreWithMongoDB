using MongoDB.Driver;
using DotNetCoreMongoDB.Classes;

namespace DotNetCoreMongoDB.Data
{
    public interface IMongoDbContext
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
        bool PluralizeDocumentName { get; set; }
        IMongoCollection<T> Collection<T>() where T : MongoEntity;
    }
}