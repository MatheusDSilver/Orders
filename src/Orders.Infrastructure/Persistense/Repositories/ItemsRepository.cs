using MongoDB.Driver;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace Orders.Infrastructure.Persistense.Repositories
{
    public class ItemsRepository : IItemsRepository
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

        public async Task<List<Items>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public async Task<Items> GetByNameAsync(string itemName)
        {
            return await _collection.Find(i => i.ItemName == itemName).SingleAsync();
        }
    }
}
