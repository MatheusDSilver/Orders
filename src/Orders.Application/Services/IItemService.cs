using Orders.Application.InputModels;
using Orders.Application.ViewModels;

namespace Orders.Application.Services
{
    public interface IItemService
    {
        Task<string> Add(AddItemInputModel model);

        Task<ItemViewModel> GetByName(string itemName);

        Task<ItemViewModel> GetAll();
    }
}
