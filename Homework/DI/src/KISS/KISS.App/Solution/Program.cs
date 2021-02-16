using System;

namespace KISS.App.Solution
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Weather in Kharkov today");

            var api = new WeatherApi();

            var temperature = api.GetTemperatureAsync().Result;

            Console.WriteLine($"{temperature} °C");
        }
    }
}
