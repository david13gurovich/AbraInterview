using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Pets.Server.Data
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; }
        public string PetsCollectionName { get; }

        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
            PetsCollectionName = configuration.GetSection("DatabaseSettings:Collections:Pets").Value;

            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(databaseName);
        }
    }
}


