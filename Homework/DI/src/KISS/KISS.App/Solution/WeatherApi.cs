using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KISS.App.Solution
{
    public class WeatherApi
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private const string BaseUrl = 
            "http://api.openweathermap.org/data/2.5/weather?APPID=9e4e7f168e9e556400907b57952a2683&units=metric&lang=ru_ru&q=";

        public async Task<double> GetTemperatureAsync(string city = Cities.Kharkov)
        {
            var response = await HttpClient.GetAsync(BaseUrl + city);

            dynamic info = JsonConvert.DeserializeObject(
                await response.Content.ReadAsStringAsync());

            return double.Parse(info["main"]["temp"].ToString());
        }
    }
}