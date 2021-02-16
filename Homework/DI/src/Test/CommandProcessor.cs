using System;
using System.Collections.Generic;

public class CommandProcessor
{
    private readonly IDictionary<Type, Action<Command>> commands = 
        new Dictionary<Type, Action<Command>>();

    public CommandProcessor()
    {
        this.commands[typeof(OpenFileCommand)] = c => {};
        this.commands[typeof(CloseFileCommand)] = c => {};
        this.commands[typeof(SaveFileCommand)] = c => {};
    }

    public void Process(Command command)
    {
        var type = command.GetType();

        this.commands[type](command);
    }
}

public class OpenFileCommand { }
public class CloseFileCommand { }
public class SaveFileCommand { }