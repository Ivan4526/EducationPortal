using System;
using System.Collections.Generic;
using App.Abstractions;
using App.EventHandlers;
using App.Events;

namespace App.Data
{
    public class EventBus
    {
        public void Publish<T>(T @event)
            where T : Event
        {
            var eventType = typeof(T);

            if (!EventHandlers.ContainsKey(eventType))
            {
                return;
            }

            EventHandlers[eventType].Handle(@event);
        }

        private static readonly Dictionary<Type, IEventHandler> EventHandlers = new Dictionary<Type, IEventHandler>
        {
            [typeof(ProductPurchasedEvent)] = new PurchasedProductEventHandler(),
            [typeof(ShippingRequestedEvent)] = new ShippingRequestedEventHandler()
        };
    }
}