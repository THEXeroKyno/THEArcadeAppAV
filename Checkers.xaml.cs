namespace THEArcadeAppAV;

public partial class Checkers : ContentPage
{
    //class attributes
    public List<CheckerboardSquare> Checkerboard = new List<CheckerboardSquare>();
    public List<Checker> AIPieces = new List<Checker>();
    public List<Checker> UserPieces = new List<Checker>();
    public bool checkerIsSelected = false;
    //class constructor
    public Checkers()
    {
        InitializeComponent();
        PopulateGameBoard();
    }

    public void PopulateGameBoard()
    {
        int rows = 8;
        int columns = 8;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Color color = new Color();
                if(i % 2 == 0)
                {
                    //even row
                    if (j % 2 == 0)
                    {
                        color = Color.FromRgb(255, 255, 255);
                    }
                    else
                    {
                        color = Color.FromRgb(50, 50, 50);
                    }
                }
                else
                {
                    //odd row
                    if (j % 2 == 0)
                    {
                        color = Color.FromRgb(50, 50, 50);
                    }
                    else
                    {
                        color = Color.FromRgb(255, 255, 255);
                    }
                }

                ImageButton sq = new ImageButton()
                {
                    BackgroundColor = color,
                };

                if ((j == 0 || j == 1 || j == 2) && sq.BackgroundColor.Equals(new Color(50, 50, 50)))
                {
                    sq.Source = "black.png";
                    Checker newPiece = new Checker(i, j);
                    AIPieces.Add(newPiece);
                }

                if ((j == 5 || j == 6 || j == 7) && sq.BackgroundColor.Equals(new Color(50, 50, 50)))
                {
                    sq.Source = "white.png";
                    Checker newPiece = new Checker(i, j);
                    UserPieces.Add(newPiece);
                }

                Gameboard.Add(sq, i,j);
                Checkerboard.Add(new CheckerboardSquare(this, sq, i, j));
            }
        }
    }

    public Checker IdentifyChecker(int[] location)
    {
        foreach (Checker piece in UserPieces)
        {
            if (piece.currentLocation[0] == location[0] && piece.currentLocation[1]==location[1])
            {
                return piece;
            }
        }
        return null;
    }

    public CheckerboardSquare IdentifyCheckerboardSquare(int[] location)
    {
        foreach (CheckerboardSquare square in Checkerboard)
        {
            if (square.location[0] == location[0] && square.location[1] == location[1])
            {
                return square;
            }
        }
        return null;
    }

    public void HighlightSquares(List<int[]> locations)
    {
        if(locations.Count != 0)
        {
            foreach (int[] location in locations)
            {
                IdentifyCheckerboardSquare(location).Addboarder();
            }
        }
        else
        {
            return;
        }
    }

    public void DehighlightSquares(List<int[]> locations)
    {
        if(locations.Count != 0)
        {
            foreach (int[] location in locations)
            {
                IdentifyCheckerboardSquare(location).Removeboarder();
            }
        }
        else
        {
            return;
        }
    }

    public class Checker
    {
        public int[] currentLocation = new int[2];
        public Checker(int i, int j)
        {
            currentLocation[0] = i;
            currentLocation[1] = j;
            
        }

        public List<int[]> GetPossibleMoves(string player, Checkers p)
        {
            List<int[]> moves = new List<int[]>();
            if(player == "user")
            {
                int[] move1 = new int[2] { currentLocation[0] - 1, currentLocation[1] - 1}; //up left 
                int[] move2 = new int[2] { currentLocation[0] + 1, currentLocation[1] - 1}; //up right 

                CheckerboardSquare sq1 = p.IdentifyCheckerboardSquare(move1);
                CheckerboardSquare sq2 = p.IdentifyCheckerboardSquare(move2);

                move1 = GetActualUserMoves(move1, sq1, "move1", p);
                move2 = GetActualUserMoves(move2, sq2, "move2", p);

                if(move1 != null)
                {
                    moves.Add(move1);
                }
                else(move2 != null)
                {
                    moves.Add(move2);
                }
            }

            else
            {
                //AI
            }
            return moves;
        }
    }

    public int[] GetActualUserMoves(int[] move, CheckerboardSquare sq, string moveID, Checkers p)
    {
        if(moveID == "move1")
        {
            if(move[0] >= 0 && move[1] >= 0 && sq != null) //checkz if move in baord
            {
                if(sq.isActive == true) //see if open
                {
                    if (Convert.ToString(sq.square.Source).Substring(6) != "white.png")
                    {
                        move[0] = (move[0] + 1);
                        move[1] = (move[1] - 1);
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualUserMoves(move, sq, moveID, p);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        else if(moveID == "move2")
        {
            if(move[0] <= 7 && move[1] >= 0 && sq != null) //checkz if move in baord
            {
                if(sq.isActive == true) //see if open
                {
                    if (Convert.ToString(sq.square.Source).Substring(6) != "white.png")
                    {
                        move[0] = (move[0] - 1);
                        move[1] = (move[1] - 1);
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualUserMoves(move, sq, moveID, p);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        return move;
    }

    public class CheckerboardSquare
    {
        Checkers p;
        public ImageButton square;
        public int[] location = new int[2];
        public bool isActive = false;
        public bool choosingforMove;
        public int currentState = 0;
        public EventHandler DoToggle;
        public EventHandler DoMove;

        public CheckerboardSquare(Checkers page, ImageButton sq, int i, int j)
        {
            p = page;
            location[0] = i;
            location[1] = j;
            square = sq;
            choosingforMove = false;
            TestActive();
        }

        public void Addboarder()
        {
            square.BorderColor = Color.FromRgb(255,223,0);
            square.BorderWidth = 5;
        }

        public void Removeboarder()
        {
            square.BorderColor = Color.FromRgb(0,0,0);
            square.BorderWidth = 0;
        }

        public void TestActive()
        {
            if (Convert.ToString(square.Source).Length > 7)
            {
                isActive = true;
                if (Convert.ToString(square.Source).Substring(6) == "white.png")
                {
                    DefineWhiteClick();
                }
                else
                {
                    isActive = false;
                    DefineWhiteMove();
                }
            }
        }

        public void DefineWhiteClick()
        {
            DoToggle = (sender, args) => //arrow funtion `` lambda expression?
            {
                
                Checker  currentChecker = p.IdentifyChecker(location);
                List<int[]> availableMoves = currentChecker.GetPossibleMoves("user", p); //list of valid moves
                
                if(currentState == 0 && (p.checkerIsSelected == false))
                {
                    square.Source = "white.png"; //cahnge this at some point bruv
                    choosingforMove = true;
                    currentState = 1; //toggle
                    p.checkerIsSelected = true;
                }
                else if (choosingforMove)
                {
                    square.Source = "white.png";
                    currentState = 0;
                    choosingforMove = false;
                    p.checkerIsSelected = false;
                }
            };
            square.Clicked += DoToggle;
        }

        public void DefineWhiteMove()
        {
            DoMove = (sender, args) =>
            {
                if (square.BorderWidth == 5)
                {
                    square.Source = "white.png";
                    currentState = 0;
                    choosingforMove = false;
                    p.checkerIsSelected = false;
                }
            };
            square.Clicked += DoMove;
        }
       
    }

}