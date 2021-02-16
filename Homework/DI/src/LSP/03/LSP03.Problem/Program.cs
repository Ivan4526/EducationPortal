using System;

namespace LSP03.Problem
{
    internal class Program
    {
        private static void Main()
        {
            TestBoiler(new BoschBoiler(), 40);

            TestBoiler(new SamsungBoiler(), 80);

            TestBoiler(new TeslaBoiler(), 80);
        }

        private static void TestBoiler(Boiler boiler, double desiredTemperature)
        {
            boiler.DesiredTemperature = desiredTemperature;

            boiler.HeatWater();

            Console.WriteLine($"Boiler {boiler.Manufacturer} is heated up to {boiler.GetWaterTemperature()} °C");
        }
    }
}
