using System;
using System.Text;
using System.Threading;

namespace DIP01.Problem
{
    internal class Program
    {
        private static readonly ManualResetEventSlim Exit = new ManualResetEventSlim(false);

        private static void Main()
        {
            Console.CancelKeyPress += (s, e) => Exit.Set();
            Console.OutputEncoding = Encoding.UTF8;

            Run();

            Exit.Wait();
        }

        private static void Run()
        {
            var car = new Car();

            car.GasTank.FillUp(5);

            car.StartEngine();
        }
    }
}
