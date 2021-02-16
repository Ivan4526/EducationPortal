using System;
using App.Abstractions;
using App.Events;

namespace App.EventHandlers
{
    public class ShippingRequestedEventHandler : AbstractEventHandler<ShippingRequestedEvent>
    {
        public override void Handle(ShippingRequestedEvent e)
        {
            Console.WriteLine($"Notify shipping department ({e.ShippingAddress})");
        }
    }
}