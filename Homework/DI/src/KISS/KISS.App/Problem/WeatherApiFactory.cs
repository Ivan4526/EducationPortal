using KISS.App.Problem.CommunicationFramework;

namespace KISS.App.Problem
{
    public class WeatherApiFactory
    {
        public WeatherApiFactory()
        {
            
        }

        public WeatherApiFactory(WeatherApiSettings settings)
        {
            
        }
        public IWeatherApi Create()
        {
            return new DynamicProxy<IWeatherApi>() as IWeatherApi;
        }
    }
}