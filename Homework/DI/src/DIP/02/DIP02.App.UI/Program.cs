using System;
using System.Linq;
using DIP02.App.BusinessLogic.Commands;

namespace DIP02.App.UI
{
    internal class Program
    {
        private static void Main()
        {
            var commandHandler = new CommandHandler();

            while (true)
            {
                Console.Write("> ");

                var input = Console.ReadLine().Split(' ');
                var command = input[0];
                var args = input.Skip(1).ToArray();

                commandHandler.Handle(command, args);
            }
        }
    }
}
