using App.Abstractions;

namespace App.Events
{
    public class ShippingRequestedEvent : Event
    {
        public ShippingRequestedEvent(string address)
        {
            this.ShippingAddress = address;
        }

        public string ShippingAddress { get; }
    }
}