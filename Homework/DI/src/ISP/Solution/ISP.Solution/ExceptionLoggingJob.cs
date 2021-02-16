using System;

namespace ISP.Solution
{
    public abstract class ExceptionLoggingJob : IJob, IJobFailed
    {
        public abstract string Name { get; }

        public abstract void Execute();

        public void OnFailed(Exception e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Error: {e.Message}");

            Console.ForegroundColor = color;
        }
    }
}