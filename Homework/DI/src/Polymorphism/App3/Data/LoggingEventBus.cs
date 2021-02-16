using System;
using App.Abstractions;

namespace App.Data
{
    public class LoggingEventBus : SimpleEventBus
    {
        public new void Publish(Event e)
        {
            Console.WriteLine($"TRACE: event published [{e.GetType().Name}]");

            base.Publish(e);
        }
    }
}