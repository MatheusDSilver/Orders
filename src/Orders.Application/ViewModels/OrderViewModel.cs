using Orders.Domain.Entities;
using Orders.Domain.Enum;

namespace Orders.Application.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel(string trackingCode, DateTime postedAt, decimal totalValue, List<OrderItems> items)
        {
            TrackingCode = trackingCode;
            PostedAt = postedAt;
            TotalValue = totalValue;
            Items = items;
        }

        public string TrackingCode { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; }
        public decimal TotalValue { get; set; }
        public List<OrderItems> Items { get; set; }

        public static OrderViewModel FromEntity(Order order)
        {
            return new OrderViewModel(order.TrackingCode, order.PostedAt, order.TotalValue, order.Items);
        }


    }
}
