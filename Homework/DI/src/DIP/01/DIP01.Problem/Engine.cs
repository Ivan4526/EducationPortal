using System;
using System.Threading.Tasks;

namespace DIP01.Problem
{
    public class Engine
    {
        private bool isStarted;

        private readonly GasTank gasTank;

        public Engine(Car car)
        {
            this.gasTank = car.GasTank;
        }

        public void Start()
        {
            this.isStarted = true;

            Task.Run(() =>
            {
                while (this.isStarted)
                {
                    if (this.gasTank.GasAmount <= 0)
                    {
                        this.Stop();
                        return;
                    }

                    this.gasTank.GetGas();

                    Task.Delay(300).Wait();

                    Console.Write("-Дыр");
                }
            });
        }

        public void Stop()
        {
            this.isStarted = false;
            Console.WriteLine("-Пых!");
        }
    }
}