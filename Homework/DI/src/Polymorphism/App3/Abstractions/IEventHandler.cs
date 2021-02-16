namespace App.Abstractions
{
    public interface IEventHandler
    {
        void Handle(Event @event);
    }

    public interface IEventHandler<in T> : IEventHandler
        where T : Event
    {
        void Handle(T @event);
    }
}