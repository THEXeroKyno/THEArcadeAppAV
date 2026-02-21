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
    private string weatherdescription;

    [ObservableProperty]
    private string feels_like;

    [ObservableProperty]
    private string humidity;

    [ObservableProperty]
    private string placeholder;

    [ObservableProperty]
    private string localtime;

    [ObservableProperty]
    private string wicon;
    [RelayCommand]
    private async Task FetchWeatherInformation()
    {
        var WeatherApiReasonse = await weatherApiService.GetWeatherInformation(city);
        if(WeatherApiReasonse.Current != null)
        {
            Wicon = WeatherApiReasonse.Current.weather_icons[0];
            Temp = $"{WeatherApiReasonse.Current.Temperature}C";

            Weatherdescription = $"{WeatherApiReasonse.Current.weather_descriptions[0]}";
            
            Feels_like = $"{WeatherApiReasonse.Current.feelslike}";

            Humidity = $"{WeatherApiReasonse.Current.humidity}";

            Localtime = $"{WeatherApiReasonse.Location.Localtime}";

            Placeholder = $"{WeatherApiReasonse.Location.Name}, {WeatherApiReasonse.Location.Region}";
        }
    }
}