using System.Collections.Generic;
using App.Abstractions;

namespace App.Data
{
    public class EventBus
    {
        private readonly Dictionary<string, Event> entities = new Dictionary<string, Event>();

        public void Publish(Event @event)
        {
            this.entities.TryAdd(@event.Id, @event);
        }
    }
}