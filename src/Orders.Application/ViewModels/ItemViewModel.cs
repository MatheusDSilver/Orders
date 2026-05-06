using Orders.Domain.Entities;

namespace Orders.Application.ViewModels
{
    public class ItemViewModel
    {
        public string ItemName { get; set; } = string.Empty;
        public decimal Value { get; set; }

        public ItemViewModel(string itemName, decimal value)
        {
            ItemName = itemName;
            Value = value;
        }

        public static ItemViewModel FromEntity(Items item)
        {
            return new ItemViewModel(item.ItemName, item.Value);
        }
    }
}
