using App.Data;
using App.Events;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            var eventBus = new SimpleEventBus(); // LoggingEventBus

            var productPurchased = new ProductPurchasedEvent(productId: "KK-4311", quantity: 10);
            var shippingRequest = new ShippingRequestedEvent("Ukraine, Kharkov, Karazina st., 2");

            eventBus.Publish(productPurchased);
            eventBus.Publish(shippingRequest);
        }
    }
}
