using System.Threading.Tasks;

namespace THEArcadeAppAV
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ImageButton1_Clicked(object sender, EventArgs e)
        {
            ImageButton1.BackgroundColor = Colors.Aquamarine;
            await Shell.Current.GoToAsync("quiz_home");
        }
        private async void ImageButton2_Clicked(Object sender, EventArgs e)
        {
            ImageButton2.BackgroundColor = Colors.Red;
            await Shell.Current.GoToAsync("story_home");
        }
        private async void ImageButton3_Clicked(Object sender, EventArgs e)
        {
            ImageButton3.BackgroundColor = Colors.LightGray;
            await Shell.Current.GoToAsync("Calculator");
        }

        private async void ImageButton4_Clicked(object sender, EventArgs e)
        {
            ImageButton4.BackgroundColor = Colors.DarkBlue;
            await Shell.Current.GoToAsync("Platform_home");
        }

        private async void ImageButton5_Clicked(Object sender, EventArgs e)
        {
            ImageButton5.BackgroundColor = Colors.LightGray;
            await Shell.Current.GoToAsync("Clicker_home");
        }
        private async void ImageButton6_Clicked(Object sender, EventArgs e)
        {
            ImageButton6.BackgroundColor = Colors.LightGray;
            await Shell.Current.GoToAsync("simulator");
        }

        private async void InvButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("inv");   
        }

        private async void ImageButton7_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("weather");   
        }

        private async void ImageButton8_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("kitty");
        }

        private async void ImageButton9_Clicked1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("tictactoe");
        }





    }

}
