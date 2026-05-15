using Orders.Domain.Entities;

namespace Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order);
        public Task<Order> GetByCodeAsync(string code);
    }
}
