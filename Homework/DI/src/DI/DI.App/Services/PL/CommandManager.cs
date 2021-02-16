using System;
using System.Text;
using DI.App.Abstractions;
using DI.App.Abstractions.PL;
using Microsoft.Extensions.DependencyInjection;

namespace DI.App.Services.PL
{
    public class CommandManager : ICommandManager
    {
        //private readonly ICommandProcessor processor = new CommandProcessor();
        ICommandProcessor processor;
        private string info;
        public CommandManager(ICommandProcessor processor)
        {
            this.processor = processor;
        }

        public void Start()
        {
            this.SetupInfo();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(this.info);

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)
                    ||
                    !int.TryParse(input, out var command))
                {
                    continue;
                }

                this.processor.Process(command);

                Console.WriteLine("RETURN to continue...");
                Console.ReadLine();
            }
        }

        private void SetupInfo()
        {
            var sb = new StringBuilder();
            var commands = this.processor.Commands;

            sb.AppendLine("Select operation:");

            foreach (var command in commands)
            {
                sb.AppendLine($"{command.Number}. {command.DisplayName}");
            }

            this.info = sb.ToString();
        }
    }
}