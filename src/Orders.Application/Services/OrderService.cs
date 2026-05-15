using Orders.Application.InputModels;
using Orders.Application.ViewModels;
using Orders.Domain.Repositories;

namespace Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Add(AddOrderInputModel model)
        {
            var order = model.ToEntity();
            await _repository.AddAsync(order);

            return order.TrackingCode;
        }

        public async Task<OrderViewModel> GetByCode(string code)
        {
            var order = await _repository.GetByCodeAsync(code);
            return OrderViewModel.FromEntity(order);
        }
    }
}
