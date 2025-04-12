namespace THEArcadeAppAV;

public partial class Quiz_MainPage : ContentPage
{

    string answer1 = "Junimo";
    string answer2 = "The Wizard";
    string answer3 = "Clint";
    string answer4 = "Blue";
    string answer5 = "Lewis";
    string answer6 = "Coral";
    string answer7 = "Hot Pepper";
    string answer8 = "Robin";
    string answer9 = "Tuna";
    string answer10 = "Stardew Valley";


    public Quiz_MainPage()
	{
		InitializeComponent();
	}

    private void Submit_Button_Clicked(object sender, EventArgs e)
    {
        int score = 0;
        string text1 = question1.Text.ToString();
        string text2 = question2.Text.ToString();
        string text3 = question3.Text.ToString();
        string text4 = question4.Text.ToString();
        string text5 = question5.Text.ToString();
        string text6 = question6.Text.ToString();
        string text7 = question7.Text.ToString();
        string text8 = question8.Text.ToString();
        string text9 = question9.Text.ToString();
        string text10 = question10.Text.ToString();

        if (string.Equals(text1, answer1, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text2, answer2, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text3, answer3, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text4, answer4, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text5, answer5, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text6, answer6, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text7, answer7, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text8, answer8, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text9, answer9, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        if (string.Equals(text10, answer10, StringComparison.OrdinalIgnoreCase))
        {
            score = score + 10;

        }

        Submit_Button.Text = "score: " + score;
    }

    private void Answer1_Clicked(object sender, EventArgs e)
    {
        Answer1.BackgroundColor = Colors.Green;
    }

    private async void Answer2_Clicked(object sender, EventArgs e)
    {
        Answer2.BackgroundColor = Colors.Red;
        await Task.Delay(2000);
        Answer1.BackgroundColor = Colors.Black;
    }

    private async void Answer3_Clicked(object sender, EventArgs e)
    {
        Answer3.BackgroundColor = Colors.Red;
        await Task.Delay(2000);
        Answer1.BackgroundColor = Colors.Black;
    }

    private async void Answer4_Clicked(object sender, EventArgs e)
    {
        Answer4.BackgroundColor = Colors.Red;
        await Task.Delay(2000);
        Answer1.BackgroundColor = Colors.Black;
    }


}
