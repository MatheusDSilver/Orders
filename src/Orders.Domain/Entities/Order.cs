using Orders.Domain.Enum;

namespace Orders.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string TrackingCode { get; private set; }
        public DateTime PostedAt { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalValue { get; private set; }

        public List<OrderItems> Items { get; private set; }

        public Order(List<OrderItems> items)
        {
            Id = Guid.NewGuid();
            TrackingCode = GenerateTrackingCode();
            PostedAt = DateTime.Now;
            Status = OrderStatus.Pending;

            Items = items;

            SumValues();
        }

        private void SumValues()
        {
            foreach(var itens in Items)
            {
                TotalValue += itens.Value * itens.Quantity;
            }
        }

        private string GenerateTrackingCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            var code = new char[10];
            var random = new Random();

            for (var i = 0; i < 5; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++)
            {
                code[i] = numbers[random.Next(numbers.Length)];
            }

            return new String(code);

        }
    }

    public class OrderItems
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
