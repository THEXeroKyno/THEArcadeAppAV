using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using THEArcadeAppAV.Services;
using System.Text.Json.Serialization;
/*
namespace THEArcadeAppAV.Models;

internal partial class Catinfo : ObservableObject
{
   private readonly CatApiService catApiService;

    public Catinfo()
    {
        catApiService = new CatApiService();
    }

    [ObservableProperty]
    private string url;
    [RelayCommand]
    private async Task FetchCatInformation()
    {
        var CatApiResponse = await CatApiService.GetCatInformation();
        if (CatApiResponse != null)
        {
            Catimage = CatApiResponse.Url;
        }
    }
}
*/