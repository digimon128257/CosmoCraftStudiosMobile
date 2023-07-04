using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EasyFinanceLoan.Mobile.Services
{
    public class GenericService
    {
        public async Task<List<WeatherForecast>> GetWeathers()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List< WeatherForecast>>("https://c00c-47-35-180-19.ngrok.io/WeatherForecast");
        }
    }
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
