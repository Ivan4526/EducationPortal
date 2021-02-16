namespace App.Abstractions
{
    public abstract class AbstractEventHandler<T> : IEventHandler<T>
        where T : Event
    {
        public abstract void Handle(T @event);

        void IEventHandler.Handle(Event e)
        {
            if (e is T @event)
            {
                this.Handle(@event);
            }
        }
    }
}