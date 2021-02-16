using System;

namespace App.Abstractions
{
    public abstract class Event
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}