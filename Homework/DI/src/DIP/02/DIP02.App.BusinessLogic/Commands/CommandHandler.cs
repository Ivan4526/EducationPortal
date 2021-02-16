using System;
using System.Collections.Generic;
using DIP02.App.BusinessLogic.Commands.Abstractions;

namespace DIP02.App.BusinessLogic.Commands
{
    public class CommandHandler
    {
        private readonly Dictionary<string, AbstractCommand> commands = 
            new Dictionary<string, AbstractCommand>();

        public CommandHandler()
        {
            this.RegisterCommand(new ListDocumentsCommand());
            this.RegisterCommand(new AddDocumentCommand());
            this.RegisterCommand(new DeleteDocumentCommand());
        }

        public void Handle(string command, string[] args)
        {
            if (this.commands.TryGetValue(command, out var cmd))
            {
                cmd.Execute(args);
            }
            else
            {
                Console.WriteLine($"Unknown command {command}");
            }
        }

        protected void RegisterCommand(AbstractCommand command)
        {
            this.commands[command.Name] = command;
        }
    }
}