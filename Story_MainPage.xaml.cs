namespace THEArcadeAppAV;

public partial class Story_MainPage : ContentPage
{
	public Story_MainPage()
	{
		InitializeComponent();
	}

    private async void Page_1_Choice1_Clicked(object sender, EventArgs e)
    {
		Page_2a.IsVisible = true;

		await Task.Delay(100); //small delay to load page 2a
		await scrollview.ScrollToAsync(Page_2a, ScrollToPosition.Start, true);
    }


}