using Orders.Domain.Enum;

namespace Orders.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime PostedAt { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalValue { get; private set; }

        public List<OrderItems> Items { get; private set; }

        public Order()
        {
            Id = Guid.NewGuid();
            PostedAt = DateTime.Now;
            Status = OrderStatus.Pending;
            Items = new List<OrderItems>();

            SumValues();
        }

        private void SumValues()
        {
            foreach(var itens in Items)
            {
                TotalValue += itens.Value * itens.Quantity;
            }
        }
    }

    public class OrderItems
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
