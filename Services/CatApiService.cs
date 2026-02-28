using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using THEArcadeAppAV.Models.APIModels;
/*
namespace THEArcadeAppAV.Services
{
    internal class CatApiService
    {
        private readonly HttpClient _httpClient;

        public CatApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.CATAPI_BASE_URL);
    }

    public async Task<CatApiService> GetCatInformation()
        {
            return await _httpClient.GetFromJsonAsync<CatApiResponse>
            (
                $"current?access_key={Constants.CATAPI_KEY}"
            );
        }
    }    
}
*/