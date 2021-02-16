using System;
using System.Threading.Tasks;

namespace ISP.Problem
{
    public class PrintJob : ExceptionLoggingJob
    {
        public override string Name { get; }

        public override void Execute()
        {
            for (var i = 1; i < 5; i++)
            {
                Console.WriteLine(DateTime.Now);

                if (i % 2 == 0) throw new Exception("Oops");

                Task.Delay(1000).Wait();
            }
        }

        public override void OnStaring()
        {
            // redundant
        }

        public override void OnFinished()
        {
            // redundant
        }
    }
}