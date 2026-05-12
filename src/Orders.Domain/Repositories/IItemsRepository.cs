using Orders.Domain.Entities;

namespace Orders.Domain.Repositories
{
    public interface IItemsRepository
    {
        Task AddAsync(Items items);
        Task<Items> GetByNameAsync(string itemName);
    }
}
