namespace THEArcadeAppAV;
public partial class Platform_MainPage : ContentPage
{
    public Platform_MainPage()
    {
        InitializeComponent();
    }

    private void Start_Button_Clicked(Object sender, EventArgs e)
    {
        Fill_Grid();

        Start_Button.IsEnabled = false;
    }

    private void Reset_Button_Clicked(Object sender, EventArgs e)
    {

    }

    async public void Fill_Grid()
    {
        int rows = 5;
        int columns = 5;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                StackLayout unit = new StackLayout() { ZIndex = 0 };
                unit.BackgroundColor = Colors.LightSkyBlue;
                gameGrid.Add(unit, j, i);
            }
        }
    }
}