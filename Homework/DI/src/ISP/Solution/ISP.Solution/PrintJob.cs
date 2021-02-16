using System;
using System.Threading.Tasks;

namespace ISP.Solution
{
    public class PrintJob : ExceptionLoggingJob
    {
        public override string Name { get; } = "Print";

        public override void Execute()
        {
            for (var i = 1; i < 5; i++)
            {
                Console.WriteLine(DateTime.Now);

                if (i % 2 == 0) throw new Exception("Oops");

                Task.Delay(1000).Wait();
            }
        }
    }
}