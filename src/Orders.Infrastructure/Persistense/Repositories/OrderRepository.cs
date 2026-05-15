using MongoDB.Driver;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace Orders.Infrastructure.Persistense.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Order>("Orders");
        }

        public async Task AddAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }

        public async Task<Order> GetByCodeAsync(string code)
        {
            return await _collection.Find(o => o.TrackingCode == code).SingleOrDefaultAsync();
        }
    }
}
