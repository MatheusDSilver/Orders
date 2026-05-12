using Orders.Application.InputModels;
using Orders.Application.ViewModels;
using Orders.Domain.Repositories;

namespace Orders.Application.Services
{
    public class ItemService
    {
        private readonly IItemsRepository _repository;

        public ItemService(IItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Add(AddItemInputModel model)
        {
            var item = model.ToEntity();

            await _repository.AddAsync(item);

            return model.ItemName;
        }

        public async Task<ItemViewModel> GetByName(string itemName)
        {
            var item = await _repository.GetByNameAsync(itemName);

            return ItemViewModel.FromEntity(item);
        }
    }
}
