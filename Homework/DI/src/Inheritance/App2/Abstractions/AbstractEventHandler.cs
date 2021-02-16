namespace App.Abstractions
{
    public abstract class AbstractEventHandler<T>
        where T : Event
    {
        public abstract void Handle(T @event);
    }
}