namespace Orders.Domain.Events
{
    public class OrderUpdatedEvent
    {
        public OrderUpdatedEvent(string trackingCode)
        {
            TrackingCode = trackingCode;
        }

        public string TrackingCode { get; private set; }
    }
}
