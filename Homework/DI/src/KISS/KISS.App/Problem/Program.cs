using System;
using KISS.App.Problem;
using KISS.App.Solution;

namespace KISS.App
{
    internal class Program
    {
        private static void Main2()
        {
            Console.WriteLine("Weather in Kharkov today");

            var settings = new WeatherApiSettings();
            var api = new WeatherApiFactory(settings).Create();
            var info = api.GetWaWeatherInfo(Cities.Kharkov);
            var temperature = info.Temperature;

            Console.WriteLine(temperature);
        }
    }
}
