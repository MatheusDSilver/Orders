using Orders.Application.InputModels;
using Orders.Application.ViewModels;

namespace Orders.Application.Services
{
    public interface IOrderService
    {
        public Task<String> Add(AddOrderInputModel model);
        public Task<OrderViewModel> GetByCode(string code);
    }
}
