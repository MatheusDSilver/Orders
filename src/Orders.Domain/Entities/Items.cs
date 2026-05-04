namespace Orders.Domain.Entities
{
    public class Items
    {
        public Guid Id { get; private set; }
        public string ItemName { get; set; } = string.Empty;

        public int Amount { get; set; }

        public decimal Value { get; set; }

        public Items()
        {
            Id = new Guid();
        }
    }
}
