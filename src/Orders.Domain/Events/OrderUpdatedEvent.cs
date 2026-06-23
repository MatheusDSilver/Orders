using Orders.Domain.Entities;
using Orders.Domain.Enum;

namespace Orders.Domain.Events
{
    public class OrderUpdatedEvent
    {
        public OrderUpdatedEvent(string trackingCode, OrderStatus status, List<OrderItems> items)
        {
            TrackingCode = trackingCode;
            Status = (int)status;
            Items = items;
        }

        public string TrackingCode { get; private set; }
        public int Status { get; private set; }
        public List<OrderItems> Items { get; private set; }
    }
}
