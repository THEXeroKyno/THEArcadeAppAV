using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;
public partial class Inv : ContentPage
{
    public Inv ()
    {
        InitializeComponent();

        Users user = App.UserRepo.GetUser(App.LoggedInUser);

        abigalLabel.Text = Convert.ToString(user.abigal);
        blueLabel.Text = Convert.ToString(user.blue);
        CoralLabel.Text = Convert.ToString(user.coral);
        CursedLabel.Text = Convert.ToString(user.cursed);
        hotpepperLabel.Text = Convert.ToString(user.hot_pepper);
        nobackLabel.Text = Convert.ToString(user.noback);
        robinLabel.Text = Convert.ToString(user.robin);
        greenmanLabel.Text = Convert.ToString(user.greenman);
        tunaLabel.Text = Convert.ToString(user.tuna);
        yayLabel.Text = Convert.ToString(user.yay);
        yayyLabel.Text = Convert.ToString(user.yayy);
        testingimageLabel.Text = Convert.ToString(user.testingimage);
    }
}