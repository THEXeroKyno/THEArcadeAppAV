
using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;
//Access Key: dc70c7a6e25263463adf247446a79971
public partial class WeatherApp : ContentPage
{
	public WeatherApp()
	{
		InitializeComponent();
		BindingContext = new Weatherinfo();
	}
}