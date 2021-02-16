public class SaveEvent { }
public class LoadEvent { }
public class ClearEvent { }

public class SaveEventHandler 
{ 
    public void Handle(SaveEvent @event) {}
}

public class LoadEventHandler 
{ 
    public void Handle(LoadEvent @event) {}
}

public class ClearEventHandler 
{ 
    public void Handle(ClearEvent @event) {}
}

public class Program
{
    public static void Main()
    {
        var @event = GetEvent();

        Handle(@event);
    }

    public static object GetEvent()
    {
        // get event from somewhere...
        return new object();
    }

    public static void Handle(object @event)
    {
        if (@event is SaveEvent saveEvent)
        {
            new SaveEventHandler().Handle(saveEvent);
        }
        else if (@event is LoadEvent loadEvent)
        {
            new LoadEventHandler().Handle(loadEvent);
        }
        else if (@event is ClearEvent clearEvent)
        {
            new ClearEventHandler().Handle(clearEvent);
        }
    }
}