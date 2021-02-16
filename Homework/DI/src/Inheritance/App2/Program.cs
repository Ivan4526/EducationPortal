using App.Data;
using App.Events;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            var eventBus = new EventBus(); // LoggingEventBus

            var productPurchased = new ProductPurchasedEvent(productId: "KK-4311", quantity: 10);

            eventBus.Publish(productPurchased);
        }
    }
}
