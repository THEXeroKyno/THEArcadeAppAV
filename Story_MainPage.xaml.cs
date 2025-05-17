using System.Threading.Tasks;

namespace THEArcadeAppAV;

public partial class Story_MainPage : ContentPage
{
	public Story_MainPage()
	{
		InitializeComponent();
	}

	/////// Buttons for Page 1 ///////////

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

		if (Page_1_Character_Name.IsVisible == true)
		{
			Page_1_Character_Name.IsVisible = false;
		}
		else
		{
			Page_1_Character_Name.IsVisible = true;
		}

		if (Page_1_NEXT.IsVisible == true)
		{
			Page_1_NEXT.IsVisible = false;
		}
		else
		{
			Page_1_NEXT.IsVisible = true;
		}
    }
    private async void Page_1_NEXT_Clicked(object sender, EventArgs e)
    {
		Page_2a.Opacity = 0;
		Page_2a.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_2a, ScrollToPosition.Start, true);

		await Page_2a. FadeTo(1,100);
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

		if (Page_2a_Character_Name.IsVisible == true)
		{
			Page_2a_Character_Name.IsVisible = false;
		}
		else
		{
			Page_2a_Character_Name.IsVisible = true;
		}

		if (Page_2a_NEXT.IsVisible == true)
		{
			Page_2a_NEXT.IsVisible = false;
		}
		else
		{
			Page_2a_NEXT.IsVisible = true;
		}
    }

	private async void Page_2a_NEXT_Clicked(object sender, EventArgs e)
    {
		Page_3a.Opacity = 0;
		Page_3a.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_3a, ScrollToPosition.Start, true);

		await Page_3a. FadeTo(1,100);
	}

	
	/////// Buttons for Page 3a //////////

  private void Page_3a_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_3a_textbox.IsVisible == true)
		{
			Page_3a_textbox.IsVisible = false;
		}
		else
		{
			Page_3a_textbox.IsVisible = true;
		}

		if (Page_3a_Choice1.IsVisible == true)
		{
			Page_3a_Choice1.IsVisible = false;
		}
		else
		{
			Page_3a_Choice1.IsVisible = true;
		}

		if (Page_3a_Choice2.IsVisible == true)
		{
			Page_3a_Choice2.IsVisible = false;
		}
		else 
		{
			Page_3a_Choice2.IsVisible = true;
		}
    }


    


	////// Buttons for Page 4a //////////////
    private void Page_4a_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
    }

    private void Page_4a_NEXT_Clicked(object sender, EventArgs e)
    {

    }

  


  //////// Button for Page 3b ///////////////

}
