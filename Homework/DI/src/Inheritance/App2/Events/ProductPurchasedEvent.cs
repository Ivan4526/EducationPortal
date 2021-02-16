using App.Abstractions;

namespace App.Events
{
    public class ProductPurchasedEvent : Event
    {
        public ProductPurchasedEvent(string productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public string ProductId { get; }

        public int Quantity { get; }
    }
}