namespace THEArcadeAppAV;

public partial class Signup : ContentPage
{
     public Signup()
        {
           InitializeComponent();
        }

    private async void Button_Clicked(object sender, EventArgs e)
    { 
        if(UsernameEntry.Text != null && PasswordEntry.Text != null)
        {   
            if(App.UserRepo.GetUser(UsernameEntry.Text) == null && App.UserRepo.GetUser(PasswordEntry.Text) == null)
            {
                App.UserRepo.AddUser(UsernameEntry.Text, PasswordEntry.Text);
                await Shell.Current.GoToAsync("Logingin");
            }
        }    
            
    }
}