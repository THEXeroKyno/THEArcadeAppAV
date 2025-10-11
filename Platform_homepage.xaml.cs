namespace THEArcadeAppAV;

public partial class Platform_HomePage : ContentPage
{
    public Platform_HomePage()
    {
        InitializeComponent();
    }

    private async void Button1Game_Clicked(object sender, EventArgs e)
    {
    await Shell.Current.GoToAsync("Platform_main");
    }

    private async void Button3Game_Clicked(object sender, EventArgs e)
    {
    await Shell.Current.GoToAsync("arcade_main");
    }
}