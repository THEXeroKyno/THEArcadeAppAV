using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using THEArcadeAppAV.Services;


namespace THEArcadeAppAV.Models;

internal partial class Weatherinfo : ObservableObject
{
    private readonly WeatherApiService weatherApiService;

    public Weatherinfo()
    {
        weatherApiService = new WeatherApiService();
    }
    
    
    [ObservableProperty]
    private string city;
    [ObservableProperty]
    private string state;
    [ObservableProperty]
    private string temp;
    [ObservableProperty]
    private string wicon;

    [RelayCommand]
    private async Task FetchWeatherInformation()
    {
        var WeatherApiReasonse = await weatherApiService.GetWeatherInformation(city);
        if(WeatherApiReasonse.Current != null)
        {
            //wicon = WeatherApiReasonse.Current.WeatherIcons[0];
            Temp = $"(weatherApiResonse.Current.temp)C";
        }
    }
}