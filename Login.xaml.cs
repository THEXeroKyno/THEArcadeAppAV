using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;

public partial class Login : ContentPage
{
     public Login()
        {
           InitializeComponent();
        }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Users result = App.UserRepo.GetUser(UsernameEntry.Text);
        if(result != null)
        {
            if(UsernameEntry.Text == result.Username && PasswordEntry.Text == result.Password)
            {
                await Shell.Current.GoToAsync("arcade_main");
            }
        }
        
        
    }

    private async void Button_Clicked1(object sender, EventArgs e)
    {
            await Shell.Current.GoToAsync("signingup");
    }
}