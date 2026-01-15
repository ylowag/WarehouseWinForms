using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarehouseWinForms.Services
{
    public class WeatherService
    {
        private const string ApiKey = "anonim"; //мій ключ 
        private const string City = "Lviv";
        private const string Country = "ua";

        public async Task<double?> GetCurrentTemperatureCelsiusAsync()
        {
            string url =
                "https://api.openweathermap.org/data/2.5/weather?q="
                + City + "," + Country +
                "&appid=" + ApiKey +
                "&units=metric";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                var data = JsonConvert.DeserializeObject<WeatherResponse>(json);

                return data.main.temp;
            }
        }
    }

    public class WeatherResponse
    {
        public MainInfo main { get; set; }
    }

    public class MainInfo
    {
        public double temp { get; set; }
    }
}
