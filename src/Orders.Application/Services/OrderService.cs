using Orders.Application.InputModels;
using Orders.Application.ViewModels;
using Orders.Domain.Events;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Messaging;

namespace Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMessageBusService _messageBus;

        public OrderService(IOrderRepository repository, IMessageBusService messageBus)
        {
            _repository = repository;
            _messageBus = messageBus;
        }

        public async Task<string> Add(AddOrderInputModel model)
        {
            var order = model.ToEntity();
            await _repository.AddAsync(order);

            var orderCompletedEvent = new OrderUpdatedEvent(order.TrackingCode, order.Status, order.Items);

            _messageBus.Publish(orderCompletedEvent, "order-updated");

            return order.TrackingCode;
        }

        public async Task<OrderViewModel> GetByCode(string code)
        {
            var order = await _repository.GetByCodeAsync(code);
            return OrderViewModel.FromEntity(order);
        }
    }
}
