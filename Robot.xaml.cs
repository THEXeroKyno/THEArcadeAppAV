using System.Security.Cryptography.X509Certificates;
using MetalPerformanceShaders;

namespace THEArcadeAppAV;
public partial class Robot : ContentPage
{
    public BoardSquare sq1;
    public BoardSquare sq2;
    public BoardSquare sq3;
    public BoardSquare sq4;
    public BoardSquare sq5;
    public BoardSquare sq6;
    public BoardSquare sq7;
    public BoardSquare sq8;
    public BoardSquare sq9;
    List<BoardSquare> squares = new List<BoardSquare>();
    public int currentTurn = 0;



    public Robot()
    {
        InitializeComponent();
        InitializeGame();
    }
    public void RandomLocation()
        {
            var rand = new Random();
            int loc = rand.Next(squares.Count);

            squares[loc].AITurn();
            squares.Remove(squares[loc]);
        }

    public void Checkforwin()
    {
        if ((sq1.isX && sq2.isX && sq3.isX) || (sq4.isX && sq5.isX && sq6.isX) || (sq7.isX && sq8.isX && sq9.isX) || 
        (sq1.isX && sq4.isX && sq7.isX) || (sq2.isX && sq5.isX && sq8.isX) || (sq3.isX && sq6.isX && sq9.isX) ||
        (sq1.isX && sq5.isX && sq9.isX) || (sq3.isX && sq5.isX && sq7.isX))
        {
            GameOver("user");
        }

        if ((sq1.isO && sq2.isO && sq3.isO) || (sq4.isO && sq5.isO && sq6.isO) || (sq7.isO && sq8.isO && sq9.isO) || 
        (sq1.isO && sq4.isO && sq7.isO) || (sq2.isO && sq5.isO && sq8.isO) || (sq3.isO && sq6.isO && sq9.isO) ||
        (sq1.isO && sq5.isO && sq9.isO) || (sq3.isO && sq5.isO && sq7.isO))
        {
            GameOver("Ai");
        }

    }

    public void GameOver(string id)
    {
        if (squares.Count > 0)
        {
            foreach (var BoardSquare in squares)
            {
                BoardSquare.square.IsEnabled = false;
                
            }
        }
        if(id == "user")
        {
            Winner_Label.Text = "YOU WON!";
        }
        else if(id == "Ai")
        {
            Winner_Label.Text = "LOSER!";
        }
        newgame.IsVisible = true;
    }
    

    private void square1_Clicked(object sender, EventArgs e)
    {
        sq1.PlayerTurn();
        currentTurn++;
        squares.Remove(sq1);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square2_Clicked(object sender, EventArgs e)
    {
        sq2.PlayerTurn();
        currentTurn++;
        squares.Remove(sq2);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square3_Clicked(object sender, EventArgs e)
    {
        sq3.PlayerTurn();
        currentTurn++;
        squares.Remove(sq3);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square4_Clicked(object sender, EventArgs e)
    {
        sq4.PlayerTurn();
        currentTurn++;
        squares.Remove(sq4);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square5_Clicked(object sender, EventArgs e)
    {
        sq5.PlayerTurn();
        currentTurn++;
        squares.Remove(sq5);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square6_Clicked(object sender, EventArgs e)
    {
        sq6.PlayerTurn();
        currentTurn++;
        squares.Remove(sq6);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square7_Clicked(object sender, EventArgs e)
    {
        sq7.PlayerTurn();
        currentTurn++;
        squares.Remove(sq7);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square8_Clicked(object sender, EventArgs e)
    {
        sq8.PlayerTurn();
        currentTurn++;
        squares.Remove(sq8);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    private void square9_Clicked(object sender, EventArgs e)
    {
        sq9.PlayerTurn();
        currentTurn++;
        squares.Remove(sq9);
        Checkforwin();
        RandomLocation();
        Checkforwin();
    }

    public void InitializeGame()
    {
        squares.Clear(); //empty list
        currentTurn = 0;
        newgame.IsVisible = false;
        
        sq1 = new BoardSquare(square1, 0);
        squares.Add(sq1);
        sq2 = new BoardSquare(square2, 1);
        squares.Add(sq2);
        sq3 = new BoardSquare(square3, 2);
        squares.Add(sq3);
        sq4 = new BoardSquare(square4, 3);
        squares.Add(sq4);
        sq5 = new BoardSquare(square5, 4);
        squares.Add(sq5);
        sq6 = new BoardSquare(square6, 5);
        squares.Add(sq6);
        sq7 = new BoardSquare(square7, 6);
        squares.Add(sq7);
        sq8 = new BoardSquare(square8, 7);
        squares.Add(sq8);
        sq9 = new BoardSquare(square9, 8);
        squares.Add(sq9);   
    }

    private void newgame_Clicked(object sender, EventArgs e)
    {
        Winner_Label.Text = "";
        InitializeGame();
        foreach (var BoardSquare in squares)
        {
            BoardSquare.square.IsEnabled = true;
            BoardSquare.square.Source = "";
        }
    }
}



public class BoardSquare
    {
        public ImageButton square;
        public int squareNumber;
        public bool isX = false;
        public bool isO = false;
        public string imagesource;

        public BoardSquare(ImageButton ib, int number)
        {
            square = ib;
            squareNumber = number;
        }
        public void PlayerTurn()
        {
            isX = true;
            imagesource="x.png";
            square.IsEnabled = false;
            square.Source = imagesource;
        }

        public void AITurn()
        {
            isO = true;
            imagesource = "o.png";
            square.IsEnabled = false;
            square.Source = imagesource;
        }

       
    }