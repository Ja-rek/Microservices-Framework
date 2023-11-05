using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Shop.Orders.Infrastructure.Mongo.Internal;

public class MongoCollectionFactory : IMongoCollectionFactory
{
    private readonly IOptions<DatabaseSetting> databaseSettings;

    public MongoCollectionFactory(IOptions<DatabaseSetting> databaseSettings)
    {
        this.databaseSettings = databaseSettings;
    }

    public IMongoCollection<TDataModel> Collection<TDataModel>(string? collectionName) where TDataModel : IDocument
    {
        if (databaseSettings.Value.ConnectionString is null)
        {
            throw new ArgumentNullException("No connection string to MonogDb.");
        }

        if (databaseSettings.Value.Database is null)
        {
            throw new ArgumentNullException("No database name of MonogDb.");
        }

        var client = new MongoClient(databaseSettings.Value.ConnectionString);
        var database = client.GetDatabase(databaseSettings.Value.Database);

        if (database is null)
        {
            throw new ArgumentNullException("No database in MonogDb.");
        }

        if (string.IsNullOrEmpty(collectionName))
        {
            throw new ArgumentException("No database name of MonogDb.");
        }

        return database.GetCollection<TDataModel>(collectionName);
    }
}
