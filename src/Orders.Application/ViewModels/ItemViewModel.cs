using Orders.Domain.Entities;

namespace Orders.Application.ViewModels
{
    public class ItemViewModel
    {
        public List<string> ItemNames { get; set; }

        public ItemViewModel(List<string> itemsNamesList)
        {
            ItemNames = itemsNamesList;

        }
        public ItemViewModel(string itemName)
        {
            ItemNames = new List<string> { itemName };
        }


        public static ItemViewModel FromEntity(List<Items> itemsList)
        {
            var ItemsNames = itemsList.Select(i => i.ItemName).ToList();
            return new ItemViewModel(ItemsNames);
        }

        public static ItemViewModel FromEntity(Items item)
        {
            return new ItemViewModel(item.ItemName);
        }
    }
}
