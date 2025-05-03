namespace THEArcadeAppAV;

public partial class Story_MainPage : ContentPage
{
	public Story_MainPage()
	{
		InitializeComponent();
	}

	/////// Buttons for Page 1 ///////////
    private void Page_1_SizeChanged(object sender, EventArgs e)
    {
		if (Width < 950)
		{
			Page_1_ToggleButton_Story.WidthRequest = 300;
			Page_1_ToggleButton_Story.FontSize = 12;

			Page_1_TextBox.WidthRequest = 300;
			Page_1_TextBox.HeightRequest = 250;

			Page_1_Text.FontSize = 12;

			Page_1_Choice1.WidthRequest = 150;
			Page_1_Choice1.FontSize = 12;
			Page_1_Choice1.Margin = new Thickness(0,400,150,0);

			Page_1_Choice2.WidthRequest = 150;
			Page_1_Choice2.FontSize = 12;
			Page_1_Choice2.Margin = new Thickness(150, 400, 0, 0);
		}
		else
		{
			Page_1_ToggleButton_Story.WidthRequest = 500;
			Page_1_ToggleButton_Story.FontSize = 18;

			Page_1_TextBox.WidthRequest = 500;
			Page_1_TextBox.HeightRequest = 350;

			Page_1_Text.FontSize = 18;

			Page_1_Choice1.WidthRequest = 200;
			Page_1_Choice1.FontSize = 18;
			Page_1_Choice1.Margin = new Thickness(0,300,300,0);

			Page_1_Choice2.WidthRequest = 200;
			Page_1_Choice2.FontSize = 18;
			Page_1_Choice2.Margin = new Thickness(300, 300, 0, 0);
		}
    }

    private void Page_1_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_1_TextBox.IsVisible == true)
		{
			Page_1_TextBox.IsVisible = false;
		}
		else
		{
			Page_1_TextBox.IsVisible = true;
		}
    }

	private async void Page_1_Choice1_Clicked(object sender, EventArgs e)
    {
		Page_1_Choice2. IsEnabled = false;
		Page_2a.Opacity = 0; //makes page 2a transparent
		Page_2a.IsVisible = true;

		await Task.Delay(100); //small delay to load page 2a

		//scrolling to the start of page 2a
		await scrollview.ScrollToAsync(Page_2a, ScrollToPosition.Start, true);

		await Page_2a. FadeTo(1,100); //over 100 milliseconds, fades to solid opacity
    }

  private async void Page_1_Choice2_Clicked(object sender, EventArgs e)
    {
		Page_1_Choice1. IsEnabled = false;
		Page_2b.Opacity = 0; //makes page 2b transparent
		Page_2b.IsVisible = true;

		await Task.Delay(100); //small delay to load page 2b
		await scrollview.ScrollToAsync(Page_2b, ScrollToPosition.Start, true);
		await Page_2b. FadeTo(1,100);
    }


	/////// Buttons for Page 2a ///////////
    private void Page_2a_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_2a_TextBox.IsVisible == true)
		{
			Page_2a_TextBox.IsVisible = false;
		}
		else
		{
			Page_2a_TextBox.IsVisible = true;
		}
    }

    private void Page_2a_Choice2_Clicked(object sender, EventArgs e)
    {

    }

    private async void Page_2a_Choice1_Clicked(object sender, EventArgs e)
    {
		Page_2a_Choice1. IsEnabled = false;
		Page_3a.Opacity = 0; //makes page 2b transparent
		Page_3a.IsVisible = true;

		await Task.Delay(100); //small delay to load page 2b
		await scrollview.ScrollToAsync(Page_3a, ScrollToPosition.Start, true);
		await Page_3a. FadeTo(1,100);
    }

	/////// Buttons for Page 2b //////////
    private void Page_2b_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {

    }

    private void Page_2b_Choice1_Clicked(object sender, EventArgs e)
    {

    }


	////// Buttons for Page 3a //////////////

    private void Page_3a_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_3a_TextBox.IsVisible == true)
		{
			Page_3a_TextBox.IsVisible = false;
		}
		else
		{
			Page_3a_TextBox.IsVisible = true;
		}
    }
  //////// Button for Page 3b ///////////////
    private void Page_3b_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_3b_TextBox.IsVisible == true)
		{
			Page_3b_TextBox.IsVisible = false;
		}
		else
		{
			Page_3b_TextBox.IsVisible = true;
		}
    }
  
}
