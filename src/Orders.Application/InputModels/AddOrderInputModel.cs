using Orders.Domain.Entities;

namespace Orders.Application.InputModels
{
    public class AddOrderInputModel
    {
        public List<OrderItems> Items { get; set; }

        public AddOrderInputModel()
        {
            Items = new List<OrderItems>();
        }

        public Order ToEntity()
        {
            return new Order(Items);
        }
    }
}
