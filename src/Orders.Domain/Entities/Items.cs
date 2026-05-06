namespace Orders.Domain.Entities
{
    public class Items
    {
        public Guid Id { get; private set; }
        public string ItemName { get; private set; } = string.Empty;
        public int Amount { get; private set; }
        public decimal Value { get; private set; }

        public Items(string itemName, int amount, decimal value)
        {
            Id = new Guid();
            ItemName = itemName;
            Amount = amount;
            Value = value;

        }
    }
}
