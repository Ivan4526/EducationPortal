namespace KISS.App.Problem
{
    public interface IWeatherApi
    {
        WeatherInfo GetWaWeatherInfo(string city);
    }
}