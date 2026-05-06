using Orders.Domain.Entities;

namespace Orders.Application.InputModels
{
    public class AddItemInputModel
    {
        public string ItemName { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Value { get; set; }

        public Items ToEntity()
        {
            return new Items(ItemName, Amount, Value);
        }
    }
}
