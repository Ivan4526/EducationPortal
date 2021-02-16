using App.Abstractions;
using App.EventHandlers;

namespace App.Data
{
    public class SimpleEventBus
    {
        private static IEventHandler[] Handlers = new IEventHandler[]
        {
            new PurchasedProductEventHandler(),
            new ShippingRequestedEventHandler()
        };

        public void Publish(Event @event)
        {
            foreach (var handler in Handlers)
            {
                handler.Handle(@event);
            }
        }

        public void Publish<T>(T @event)
            where T : Event
        {
            foreach (IEventHandler item in Handlers)
            {
                if (item is IEventHandler<T> handler)
                {
                    handler.Handle(@event);
                }
            }
        }
    }
}