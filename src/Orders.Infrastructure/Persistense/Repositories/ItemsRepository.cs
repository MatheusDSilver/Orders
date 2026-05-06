using MongoDB.Driver;
using Orders.Domain.Entities;

namespace Orders.Infrastructure.Persistense.Repositories
{
    public class ItemsRepository
    {
        private readonly IMongoCollection<Items> _collection;

        public ItemsRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Items>("Items");
        }
        public async Task AddAsync(Items items)
        {
            await _collection.InsertOneAsync(items);
        }

        public async Task<Items> GetByCodeAsync(string itemName)
        {
            return await _collection.Find(c => c.ItemName == itemName).SingleOrDefaultAsync();
        }
    }
}
