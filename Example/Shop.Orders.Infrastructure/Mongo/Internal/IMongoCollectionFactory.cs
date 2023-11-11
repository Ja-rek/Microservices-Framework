using MongoDB.Driver;

namespace Shop.Orders.Infrastructure.Mongo.Internal
{
    public interface IMongoCollectionFactory
    {
        IMongoCollection<TDataModel> Collection<TDataModel>(string? collectionName) where TDataModel : IDocument;
    }
}