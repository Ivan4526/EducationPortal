using System;

namespace ISP.Problem
{
    public abstract class ExceptionLoggingJob : IJob
    {
        public abstract string Name { get; }

        public abstract void Execute();

        public abstract void OnStaring(); // redundant

        public void OnFailed(Exception e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Error: {e.Message}");

            Console.ForegroundColor = color;
        }

        public abstract void OnFinished(); // redundant
    }
}