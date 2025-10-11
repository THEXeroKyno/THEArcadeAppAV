using System.Threading.Tasks;

namespace THEArcadeAppAV;

public partial class Clicker_HomePage : ContentPage
{
    public Clicker_HomePage ()
    {
        InitializeComponent();
    }
    
    private async void Button1Game_Clicked(object sender, EventArgs e)
    {
    await Shell.Current.GoToAsync("Clicker_main");
    }

    private async void Button3Game_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("arcade_main");
    }
}