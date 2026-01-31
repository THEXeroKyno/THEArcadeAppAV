using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using THEArcadeAppAV.Models.APIModels;

namespace THEArcadeAppAV.Services
{
    internal class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
    }

    public async Task<WeatherApiReasonse> GetWeatherInformation(string city)
        {
            return await _httpClient.GetFromJsonAsync<WeatherApiReasonse>
            (
                $"current?access_key={Constants.API_KEY}&query={city}"
            );
        }
    }
}