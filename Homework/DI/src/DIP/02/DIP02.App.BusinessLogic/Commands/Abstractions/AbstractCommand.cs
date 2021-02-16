using System;
using System.Collections.Generic;
using System.Linq;

namespace DIP02.App.BusinessLogic.Commands.Abstractions
{
    public abstract class AbstractCommand : ICommand
    {
        public string[] Arguments { get; set; }

        public abstract string Name { get; set; }

        public abstract void Execute(string[] args);

        protected Dictionary<string, string> ParseArguments(string[] args)
        {
            var sanitizedArgs = args.Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();
            var parsedArgs = new Dictionary<string, string>();
            var length = Convert.ToInt32(Math.Floor(sanitizedArgs.Length / 2.0));

            for (var i = 0; parsedArgs.Count <= length && i < sanitizedArgs.Length; i += 2)
            {
                var argName = args[i];
                var argValue = args[i + 1];

                parsedArgs[argName] = argValue;
            }

            return parsedArgs;
        }
    }
}