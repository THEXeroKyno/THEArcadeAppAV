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

	
	/////// Buttons for Page 3a which has choices to pick //////////

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

	private async void Page_3a_Choice1_Clicked(object sender, EventArgs e)
	{
		Page_4a.Opacity = 0;
		Page_4a.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_4a, ScrollToPosition.Start, true);

		await Page_4a. FadeTo(1,100);
    }

	private async void Page_3a_Choice2_Clicked(object sender, EventArgs e)
	{
		Page_4b.Opacity = 0;
		Page_4b.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_4b, ScrollToPosition.Start, true);

		await Page_4b. FadeTo(1,100);
    }



	////// Buttons for Page 4a //////////////
	private void Page_4a_ToggleButton_Story_Clicked(object sender, EventArgs e)
	{
		if (Page_4a_TextBox.IsVisible == true)
		{
			Page_4a_TextBox.IsVisible = false;
		}
		else
		{
			Page_4a_TextBox.IsVisible = true;
		}

		if (Page_4a_Character_Name.IsVisible == true)
		{
			Page_4a_Character_Name.IsVisible = false;
		}
		else
		{
			Page_4a_Character_Name.IsVisible = true;
		}

		if (Page_4a_NEXT.IsVisible == true)
		{
			Page_4a_NEXT.IsVisible = false;
		}
		else
		{
			Page_4a_NEXT.IsVisible = true;
		}
	}

    private async void Page_4a_NEXT_Clicked(object sender, EventArgs e)
    {
		Page_5a.Opacity = 0;
		Page_5a.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_5a, ScrollToPosition.Start, true);

		await Page_5a. FadeTo(1,100);
    }

	////// Buttons for Page 4b //////////////

	private void Page_4b_ToggleButton_Story_Clicked(object sender, EventArgs e)
	{
		if (Page_4b_TextBox.IsVisible == true)
		{
			Page_4b_TextBox.IsVisible = false;
		}
		else
		{
			Page_4b_TextBox.IsVisible = true;
		}

		if (Page_4b_Character_Name.IsVisible == true)
		{
			Page_4b_Character_Name.IsVisible = false;
		}
		else
		{
			Page_4b_Character_Name.IsVisible = true;
		}

		if (Page_4b_NEXT.IsVisible == true)
		{
			Page_4b_NEXT.IsVisible = false;
		}
		else
		{
			Page_4b_NEXT.IsVisible = true;
		}
    }

	private async void Page_4b_NEXT_Clicked(object sender, EventArgs e)
	{
		Page_5b.Opacity = 0;
		Page_5b.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_5b, ScrollToPosition.Start, true);

		await Page_5b. FadeTo(1,100);
    }

	//////// Button for Page 5a ///////////////
	private async void Page_5a_NEXT_Clicked(object sender, EventArgs e)
	{
		Page_4b.Opacity = 0;
		Page_4b.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_4b, ScrollToPosition.Start, true);

		await Page_4b. FadeTo(1,100);
    }

    private void Page_5a_ToggleButton_Story_Clicked(object sender, EventArgs e)
    {
		if (Page_5a_TextBox.IsVisible == true)
		{
			Page_5a_TextBox.IsVisible = false;
		}
		else
		{
			Page_5a_TextBox.IsVisible = true;
		}

		if (Page_5a_Character_Name.IsVisible == true)
		{
			Page_5a_Character_Name.IsVisible = false;
		}
		else
		{
			Page_5a_Character_Name.IsVisible = true;
		}

		if (Page_5a_NEXT.IsVisible == true)
		{
			Page_5a_NEXT.IsVisible = false;
		}
		else
		{
			Page_5a_NEXT.IsVisible = true;
		}
    }

	//////// Button for Page 5b WHICH HAS CHOICES///////////////
	private void Page_5b_ToggleButton_Story_Clicked(object sender, EventArgs e)
	{
		if (Page_5b_TextBox.IsVisible == true)
		{
			Page_5b_TextBox.IsVisible = false;
		}
		else
		{
			Page_5b_TextBox.IsVisible = true;
		}

		if (Page_5b_Choice2.IsVisible == true)
		{
			Page_5b_Choice2.IsVisible = false;
		}
		else
		{
			Page_5b_Choice2.IsVisible = true;
		}

		if (Page_5b_Choice2.IsVisible == true)
		{
			Page_5b_Choice2.IsVisible = false;
		}
		else
		{
			Page_5b_Choice2.IsVisible = true;
		}
	}

	private async void Page_5b_Choice1_Clicked(object sender, EventArgs e)
	{
		Page_6a.Opacity = 0;
		Page_6a.IsVisible = true;

		await Task.Delay(100);

		await scrollview.ScrollToAsync(Page_6a, ScrollToPosition.Start, true);

		await Page_6a. FadeTo(1,100);
    }

    private void Page_5b_Choice2_Clicked(object sender, EventArgs e)
    {
    }

	//////// Button for Page 6a ///////////////
    private void Page_6a_ToggleButton_Story_Clicked(object sender, EventArgs e)
	{
	}

    private void Page_6a_NEXT_Clicked(object sender, EventArgs e)
    {
    }





}
