using System.Security.Cryptography.X509Certificates;

namespace THEArcadeAppAV;

public partial class Platform_MainPage : ContentPage
{
    private Player user;
    public int level = 1;
    public int score = 0;
    public Label scoreLabel;
    public Label levelLabel;
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

                await Task.Delay(100);
            }
        }

        //Lab code here:

        scoreLabel = new Label()
        {
            //solution
            Text = "score: " + score,
            FontSize = 30,
            ZIndex = 1,
            TextColor = Colors.White,
            Margin = new Thickness(10),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,

        };

        levelLabel = new Label()
        {
            //solution
            Text = "level: " + level,
            FontSize = 30,
            ZIndex = 1,
            TextColor = Colors.White,
            Margin = new Thickness(10),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        //delay
        await Task.Delay(100);
        gameGrid.Add(scoreLabel, 0, 4);
        await Task.Delay(100);
        user = Create_User();
        gameGrid.Add(user.image, user.col, user.row);
        await Task.Delay(100);
        gameGrid.Add(levelLabel, 4, 4);
    }
    private Player Create_User()
    {
        Image userIcon = new Image { Source = "tuna.png", ZIndex = 1 };
        user = new Player(userIcon, 4, 2);
        return user;
    }
}


public class Player
{
    public Image image;
    public int row;
    public int col;

    public Player(Image img, int r, int c)
    {
        image = img;
        row = r;
        col = c;
    }
}