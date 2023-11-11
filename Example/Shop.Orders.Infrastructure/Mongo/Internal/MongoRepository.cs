using MicroFusion.Domain.AbstractCore;
using MongoDB.Driver;

namespace Shop.Orders.Infrastructure.Mongo.Internal
{
    public abstract class MongoRepository<TDataModel, TEntity, TIdentity> : IRepository<TEntity, TIdentity, Guid>
        where TDataModel : IDocument
        where TIdentity : Identity<Guid>
        where TEntity : IEntity<TIdentity, Guid>
    {
        private IMongoCollection<TDataModel> collection;

        public MongoRepository(IMongoCollectionFactory collectionFactory, string? collectionName)
        {
            collection = collectionFactory.Collection<TDataModel>(collectionName);
        }

        public abstract TDataModel MapToDocument(TEntity entity);
        public abstract TEntity MapToEntity(TDataModel data);

        public async Task<TEntity> GetAsync(TIdentity id)
        {
            var filter = Builders<TDataModel>.Filter.Eq(r => r.Id, id);
            var document = await collection.Find(filter).FirstOrDefaultAsync();

            return MapToEntity(document);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var filter = Builders<TDataModel>.Filter.Eq(r => r.Id, entity.Id.Value);
            await collection.DeleteOneAsync(filter);
        }

        public async Task SaveAsync(TEntity vehicle)
        {
            var filter = Builders<TDataModel>.Filter.Eq(r => r.Id, vehicle.Id.Value);
            var document = await collection.Find(filter).FirstOrDefaultAsync();
            var newDocument = MapToDocument(vehicle);

            if (document == null)
                await collection.InsertOneAsync(newDocument);
            else
                await collection.ReplaceOneAsync(filter, newDocument);
        }
    }
}