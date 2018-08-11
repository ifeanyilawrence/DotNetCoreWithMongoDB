using MongoDB.Driver;
using System;
using DotNetCoreMongoDB.Data;
//using System.Data.Entity.Design.PluralizationServices;

namespace DotNetCoreMongoDB.Classes
{
    public class MongoDbContext : IMongoDbContext
    {
        /// <summary>
        /// Get connection string from Mongo Client
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Get database name from Mongo Client
        /// </summary>
        public string DatabaseName { get; private set; }

        /// <summary>
        /// Pluralize document name on server
        /// Default value = false
        /// </summary>
        public bool PluralizeDocumentName { get; set; }

        private IMongoClient client;
        private IMongoDatabase database;

        public MongoDbContext()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException(nameof(ConnectionString), "Cannot be null or empty !");
        }

        public MongoDbContext(string connectionString, string databaseName, bool pluralize)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            client = new MongoClient(ConnectionString);
            database = client.GetDatabase(DatabaseName);
            PluralizeDocumentName = pluralize;
        }

        public IMongoCollection<T> Collection<T>() where T : MongoEntity
        {
            PluralizationServiceInstance pluralizeService = new PluralizationServiceInstance();
            string tableName = PluralizeDocumentName ? pluralizeService.Pluralize(typeof(T).Name) : typeof(T).Name;

            return database.GetCollection<T>(tableName);
        }
    }
}