using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using AVFoundation;

namespace THEArcadeAppAV;

public partial class Platform_MainPage : ContentPage
{
    public bool gridReady;
    private Player user;
    private Platform[] platformList = new Platform[4];
    public int level = 1;
    public int score = 0;
    public Label scoreLabel;
    public Label levelLabel;
    public double difficulty = 400;
    public Clint stalker;
    public Button startbutton;
    public Platform_MainPage()
    {
        InitializeComponent();
        startbutton = Start_Button;
    }

    private void Start_Button_Clicked(Object sender, EventArgs e)
    {
        Fill_Grid(true);
        gridReady = true;
        Start_Button.IsEnabled = false;
    }

    private void Reset_Button_Clicked(Object sender, EventArgs e)
    {
        gameGrid.Clear();
        Start_Button.IsEnabled = true;
        gridReady = true;
        score = 0;
        level = 1;
        Start_Button.Text = "Try again loser";
        Start_Button.FontSize = 15;
    }

    async public void Fill_Grid(bool start)
        {
        //store a random row position for the cloud
        var randClintPosition = new Random();
        // --> random number 0-4
        int clintRow = randClintPosition.Next(4);
        if (start)
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

                    if (i < 4 && j == 0)
                    {
                        //create boxviews and platform object here
                        BoxView newRect = new BoxView()
                        {
                            HeightRequest = 20,
                            Color = Colors.Green,
                            VerticalOptions = LayoutOptions.End,
                            CornerRadius = 10,
                            ZIndex = 1
                        };
                        Platform newPlat = new Platform(newRect, i, j);
                        platformList[i] = newPlat;
                        gameGrid.Add(newRect, newPlat.col, newPlat.row);
                    }

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

            //create a new image for the cloud image
            Image clintIMG = new Image() { Source = "clint.jpg", ZIndex = 1 };
            //set talker to a new clint object
            stalker = new Clint(clintIMG, clintRow, 4, user);
            //add the cloud to the grid
            gameGrid.Add(clintIMG, 4, clintRow);
            //start cloud oscillartion
            stalker.oscillate(gameGrid, this);
        }
        else //RESET USER AND PLATFORM = LEVEL RESET STATE
        {
            user.row = 4;

            gameGrid.SetRow(user.image, user.row);

            //set the cloud row to the random number
            //set the new row on the grid for the cloud

            foreach (Platform plat in platformList)
            {
                plat.col = 0;

                gameGrid.SetColumn(plat.rect, plat.col);
            }
        }



            foreach (Platform plat in platformList)
            {
                plat.movingright = true; //set platform to moving right

                plat.Oscillate(gameGrid, this); //set platform oscillation
            }

        }
    private Player Create_User()
    {
        Image userIcon = new Image { Source = "tuna.png", ZIndex = 1 };
        user = new Player(userIcon, 4, 2);
        return user;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (gridReady)
        {
            //jump
            gridReady = user.Jump(gameGrid, platformList, gridReady, this);

            if (gridReady == false)
            {
                Start_Button.Text = "U sux";
            }
        }
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

    public bool Jump(Grid g, Platform[] list, bool con, Platform_MainPage page)
    {
        if (this.row == 0)
        {
            page.difficulty = page.difficulty * 0.9;
            page.level++;
            page.levelLabel.Text = "Level:" + page.level;
            page.Fill_Grid(false);
        }
        else
        {
            g.SetRow(this.image, this.row -= 1);
            Platform plat = list[this.row];

            if (this.row == plat.row && this.col == plat.col)
            {
                page.score++;
                page.scoreLabel.Text = "Score: " + page.score;
                plat.StopMovement();
            }

            else
            {
                con = false; //GAMEOVER MAN. GAME OVER
            }

        }
        return con;
    }
    public void destroy(Grid g, Platform_MainPage page)
    {
        //set gridready to false
        page.gridReady = false;
        //use the player image from the grid, use grid.remove
        g.Remove(this.image);
        //set start button tect to game over
        page.startbutton.Text = "U ded";
    } 
}

//create platform class here
public class Platform
{
    public BoxView rect;
    public int row;
    public int col;
    public bool movingright;
    public bool movingleft;

    public Platform(BoxView rectangle, int r, int c)
    {
        rect = rectangle;
        row = r;
        col = c;
        movingright = true;
        movingleft = false;
    }

    public void StopMovement()
    {
        movingright = false;
        movingleft = false;
    }

    async public void Oscillate(Grid g, Platform_MainPage page)
    {
        int boundaryleft = 0;
        int boundaryright = 4;
        var rand = new Random();
        await Task.Delay(rand.Next(400));
        Moveright(g, boundaryleft, boundaryright, page); //start movement START OF LOOP
    }

    async public void Moveright(Grid g, int LimitLeft, int LimitRight, Platform_MainPage page)
    {
        while (col < LimitRight && movingright)
        {
            col++;
            g.SetColumn(rect, col);
            await Task.Delay((int)page.difficulty); //delay based on level
        }
        if (movingright)
        {
            movingleft = true;
            movingright = false;
            Moveleft(g, LimitLeft, LimitRight, page);
            //moving left
        }
    }

    async public void Moveleft(Grid g, int LimitLeft, int LimitRight, Platform_MainPage page)
    {
        while (col > LimitLeft && movingleft)
        {
            col--;
            g.SetColumn(rect, col);
            await Task.Delay((int)page.difficulty);
        }
        if (movingleft)
        {
            movingright = true;
            movingleft = false;
            Moveright(g, LimitLeft, LimitRight, page);

            //moving right
        }
    }
}

public class Clint
{
    //define clint data,
    public Image clintimage;
    public int row;
    public int col;
    public Player user;

    //clint constructor
    public Clint(Image cimage, int r, int c, Player userplayer)
    {
        clintimage = cimage;
        row = r;
        col = c;
        user = userplayer;
    }

    //clint oscillate funtion
    async public void oscillate(Grid g, Platform_MainPage page)
    {
        int boundaryleft = 0;
        int boundaryright = 4;
        var rand = new Random();
        await Task.Delay(rand.Next(700));
        Moveleft(g, boundaryleft, boundaryright, page); //start movement START OF LOOP
    }
    //moveleft function
    // -> if the user collides with the cloud, destroy() the user

    async public void Moveleft(Grid g, int LimitLeft, int LimitRight, Platform_MainPage page)
    {
        while (col > LimitLeft)
        {
            col--;
            g.SetColumn(clintimage, col);

            if (col == user.col && row == user.row)
            { 
            user.destroy(g, page);
            return;
            }
            await Task.Delay((int)page.difficulty);
        }

            Moveright(g, LimitLeft, LimitRight, page);

            //moving right
    }


    //moveright function
    // -> if the user collides with the cloud, destory the user

    async public void Moveright(Grid g, int LimitLeft, int LimitRight, Platform_MainPage page)
    {
        while (col < LimitRight)
        {
            col++;
            g.SetColumn(clintimage, col);
            if (col == user.col && row == user.row)
            {
                user.destroy(g, page);
                return;
            }
            await Task.Delay((int)page.difficulty); //delay based on level
        }
            Moveleft(g, LimitLeft, LimitRight, page);
            //moving left
        
    }
}
