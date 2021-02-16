using System;
using App.Abstractions;
using App.Events;

namespace App.EventHandlers
{
    public class PurchasedProductEventHandler : AbstractEventHandler<ProductPurchasedEvent>
    {
        public override void Handle(ProductPurchasedEvent e)
        {
            Console.WriteLine($"Prepare the parcel with {e.Quantity} pcs. of {e.ProductId}");
        }
    }
}