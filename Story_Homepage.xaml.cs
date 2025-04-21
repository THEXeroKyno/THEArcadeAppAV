namespace THEArcadeAppAV;

public partial class Story_HomePage : ContentPage
{
	public Story_HomePage()
	{
		InitializeComponent();
	}

    private async void Button1Story_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("story_main");
    }

    private async void Button3Story_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("arcade_main");
    }
}