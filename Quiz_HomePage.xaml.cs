namespace THEArcadeAppAV;

public partial class Quiz_HomePage : ContentPage
{
	public Quiz_HomePage()
	{
		InitializeComponent();
        SizeChanged += Grid_SizeChanged;
    }

    private void Grid_SizeChanged(object sender, EventArgs e)
    {
         if (Width < 400 || Height < 600)
        {
            Title1.FontSize = 53;
            Title2.FontSize = 53;
            Button1.FontSize = 12;
            Button1.WidthRequest = 160;
            Button1.HeightRequest = 50;
            Button1.Margin = new Thickness(-550, 0, 0, 100);
            Button2.FontSize = 12;
            Button2.WidthRequest = 160;
            Button2.HeightRequest = 50;
            Button2.Margin = new Thickness(0, 0, 0, 100);
            Button3.FontSize = 12;
            Button3.WidthRequest = 160;
            Button3.HeightRequest = 50;
            Button3.Margin = new Thickness(550, 0, 0, 100);
        }
        else
        {
            Title1.FontSize = 75;
            Title2.FontSize = 75;
            Button1.FontSize = 25;
            Button1.WidthRequest = 200;
            Button1.HeightRequest = 75;
            Button1.Margin = new Thickness(-600, 0, 0, 200);
            Button2.FontSize = 25;
            Button2.WidthRequest = 200;
            Button2.HeightRequest = 75;
            Button2.Margin = new Thickness(0, 0, 0, 200);
            Button3.FontSize = 25;
            Button3.WidthRequest = 200;
            Button3.HeightRequest = 75;
            Button3.Margin = new Thickness(600, 0, 0, 200);
        }
    }

    private async void Button1_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("quiz_main");
    }

    private async void Button3_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("arcade_main");
    }

    private void Button1_Clicked1(object sender, EventArgs e)
    {
    }

    private void Grid_SizeChanged1(object sender, EventArgs e)
    {
    }

    private void Grid_SizeChanged2(object sender, EventArgs e)
    {
    }
}