using System.Xml.Serialization;
using Microsoft.VisualBasic;
using SQLitePCL;

namespace THEArcadeAppAV;

public partial class Checkers : ContentPage
{
    //class attributes
    public List<CheckerboardSquare> Checkerboard = new List<CheckerboardSquare>();
    public List<Checker> AIPieces = new List<Checker>();
    public List<Checker> UserPieces = new List<Checker>();
    public bool checkerIsSelected = false;
    public List<AIMove> PriorityMoves = new List<AIMove>();
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
        foreach (Checker piece in AIPieces)
        {
            if (piece.currentLocation[0] == location[0] && piece.currentLocation[1] == location[1])
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

    public void EndofUserTurn(CheckerboardSquare moveTo)
    {
        moveTo.isActive = true; 

        foreach (CheckerboardSquare bs in Checkerboard)
        {
            if (bs.choosingforMove)
            {
                int[] fromLocation = bs.location;
                CheckForCheckerElimination("user", fromLocation, moveTo.location);
                foreach (Checker piece in UserPieces)
                {
                    if (piece.currentLocation[0] == fromLocation[0] && piece.currentLocation[1] == fromLocation [1])
                    {
                        piece.currentLocation[0] = moveTo.location[0];
                        piece.currentLocation[1] = moveTo.location[1];
                    }
                }
                bs.square.Source = null;
                bs.isActive = false;
                bs.choosingforMove = false;
            }
            if(bs.square.BorderWidth == 5)
            {
                DehighlightSquares(new List<int[]>() {bs. location});
            }
        }
        foreach (CheckerboardSquare bs in Checkerboard)
        {
            bs.RemoveEvents();
            //bs.TestActive();
        }
        AITurn();
    }
    
    public void AITurn()
    {
        /*
        if (AIPieces.Count == 0)
        {
            UserWin();
            return;
        }
        */
        
        List<List<int[]>> AIMoves = new List<List<int[]>>(); // list of list of loations
        foreach (Checker piece in AIPieces)
        {
            List<int[]> moves = piece.GetPossibleMoves("ai", this);
            AIMoves.Add(moves);

            foreach (int[] location in moves)
            {
                if(location[1] - piece.currentLocation[1] > 1)
                {
                    AIMove move = new AIMove(1, piece.currentLocation, location, piece);
                    PriorityMoves.Add(move);
                }
                else
                {
                    AIMove move = new AIMove(0, piece.currentLocation,location,piece);
                    PriorityMoves.Add(move);
                }
            }
        }

        if(PriorityMoves.Count > 0)
        {
            AIMove chosenMove = ChooseAIMove();
            CheckerboardSquare fromsquare = IdentifyCheckerboardSquare(chosenMove.fromLocation);
            CheckerboardSquare tosquare = IdentifyCheckerboardSquare(chosenMove.toLocation);

            chosenMove.piece.currentLocation = chosenMove.toLocation;

            fromsquare.square.Source = null;
            tosquare.square.Source = "black.png";
            tosquare.choosingforMove = false;

            CheckForCheckerElimination("ai", chosenMove.fromLocation, chosenMove.toLocation);
            
            foreach (CheckerboardSquare bs in Checkerboard)
            {
                bs.TestActive();
            }
            PriorityMoves.Clear();
        }
        else
        {
            UserWin();
        }
    }

    public AIMove ChooseAIMove()
    {
        foreach (AIMove move in PriorityMoves)
        {
            if (move.priority == 1)
            {
                return move;
            }
        }
        var rand = new Random();
        int randmove = rand.Next(0, PriorityMoves.Count);
        return PriorityMoves[randmove];
    }

    public void CheckForCheckerElimination(string playerID, int[] from, int[] to)
    {
        int[] checkerToEliminate = new int[2] { -1, -1};

        if(playerID == "user")
        {
            if (from[1] - to [1] > 1)
            {
                if (to[0] > from[0])
                {
                    checkerToEliminate[0] = to[0] - 1;
                }
                else
                {
                checkerToEliminate[0] = from[0] - 1;
                }
            checkerToEliminate[1] = to[1] + 1;
            if (AIPieces.Contains(IdentifyChecker(checkerToEliminate)))
                {
                    AIPieces.Remove(IdentifyChecker(checkerToEliminate));
                }
            }
        }
        else if(playerID == "ai")
        {
            if (to[1] - from [1] > 1)
            {
                if (to[0] > from[0])
                {
                    checkerToEliminate[0] = to[0] - 1;
                }
                else
                {
                checkerToEliminate[0] = from[0] - 1;
                }
            checkerToEliminate[1] = to[1] - 1;
                if (UserPieces.Contains(IdentifyChecker(checkerToEliminate)))
                {
                    UserPieces.Remove(IdentifyChecker(checkerToEliminate));
                }
            }
        }

        if(checkerToEliminate[0] != -1 && checkerToEliminate[1] != -1)
        {
            IdentifyCheckerboardSquare(checkerToEliminate).square.Source = null;
            IdentifyCheckerboardSquare(checkerToEliminate).isActive = false;
            IdentifyCheckerboardSquare(checkerToEliminate).choosingforMove = false;
        }

    }

    public void Forfeit_button_Clicked(object sender, EventArgs e)
    {
        //Forfeit_button.isVisible = false;
        //GameOver.Text = "YOU LOST!!! AI WON";
        //GameOver.isVisible = true;
        foreach(CheckerboardSquare sq in Checkerboard)
        {
            sq.square.IsEnabled = false;
        }

    }

    public void UserWin()
    {
        //Forfeit_button.isVisible = false;
        //GameOver.Text = "YOU WINNNN!!!!!!!!";
        //GameOver.isVisible = true;
        foreach(CheckerboardSquare sq in Checkerboard)
        {
            sq.square.IsEnabled = false;
        }
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
                int[] move1 = new  int[2] { currentLocation[0] - 1, currentLocation[1] - 1}; //up left 
                int[] move2 = new int[2] { currentLocation[0] + 1, currentLocation[1] - 1}; //up right 

                CheckerboardSquare sq1 = p.IdentifyCheckerboardSquare(move1);
                CheckerboardSquare sq2 = p.IdentifyCheckerboardSquare(move2);
                
                move1 = GetActualUserMoves(move1, sq1, "move1", p);
                move2 = GetActualUserMoves(move2, sq2, "move2", p);

                if(move1 != null)
                {
                    moves.Add(move1);
                }
                if(move2 != null)
                {
                    moves.Add(move2);
                }
            }

            else
            {
                int[] move1 = new int[2] { currentLocation[0] - 1, currentLocation[1] + 1};  //AI
                int[] move2 = new int[2] { currentLocation[0] - 1, currentLocation[1] + 1};

                CheckerboardSquare sq1 = p.IdentifyCheckerboardSquare(move1);
                CheckerboardSquare sq2 = p.IdentifyCheckerboardSquare(move2);

                move1 = GetActualAIMoves(move1, sq1, "move1", p);
                move2 = GetActualAIMoves(move2, sq2, "move2", p);

                if(move1 != null)
                {
                    moves.Add(move1);
                }
                if(move2 != null)
                {
                    moves.Add(move2);
                }
            }
            return moves;
        }
            public int[] GetActualUserMoves(int[] move, CheckerboardSquare sq, string moveID, Checkers p, int moveIndex = 0)
    {
        if(moveID == "move1")
        {
            if(move[0] >= 0 && move[1] >= 0 && sq != null) //checkz if move in baord
            {
                if(sq.isActive == true) //see if open
                {
                    if (Convert.ToString(sq.square.Source).Substring(6) != "white.png" && moveIndex == 0)
                    {
                        move[0] = (move[0] + 1);
                        move[1] = (move[1] - 1);
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualUserMoves(move, sq, moveID, p, moveIndex + 1);
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
                    if (Convert.ToString(sq.square.Source).Substring(6) != "white.png" && moveIndex == 0)
                    {
                        move[0] = (move[0] - 1);
                        move[1] = (move[1] - 1);
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualUserMoves(move, sq, moveID, p, moveIndex + 1);
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
        public int[] GetActualAIMoves(int[] move, CheckerboardSquare sq, string moveID, Checkers p, int moveIndex = 0)
    {
        if(moveID == "move1")
        {
            if(move[0] >= 0 && move[1] >= 7 && sq != null) //checkz if move in baord
            {
                if(sq.isActive == true) //see if open
                {
                    if (Convert.ToString(sq.square.Source).Substring(6) != "black.png" && moveIndex == 0)
                    {
                        move = new int[2] { move[0] - 1, move[1] + 1};
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualAIMoves(move, sq, moveID, p, moveIndex + 1);
                    }
                    else
                    {
                        move = null;
                    }
                }
            }
            else
            {
                move = null;
            }
        }
        else if(moveID == "move2")
        {
            if(move[0] <= 7 && move[1] <= 7 && sq != null) //checkz if move in baord
            {
                if(sq.isActive == true) //see if open
                {
                    if (Convert.ToString(sq.square.Source).Substring(6) != "black.png")
                    {
                        move = new int[2] {move[0] + 1, move[2] + 1};
                        sq = p.IdentifyCheckerboardSquare(move);
                        move = GetActualAIMoves(move, sq, moveID, p);
                    }
                    else
                    {
                        move = null;
                    }
                }
            }
            else
            {
                move = null;
            }
        }
        return move;
    }
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
                    p.HighlightSquares(availableMoves);
                }
                else if (choosingforMove)
                {
                    square.Source = "white.png";
                    currentState = 0;
                    choosingforMove = false;
                    p.checkerIsSelected = false;
                    p.DehighlightSquares(availableMoves);
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
                    p.EndofUserTurn(this);
                }
            };
            square.Clicked += DoMove;
        }
       
       public void RemoveEvents()
       {
            square.Clicked -= DoToggle; //remove currnet toggle
            square.Clicked -= DoMove;
       }
    }

public class AIMove
{
    public int[] fromLocation = new int[2];
    public int[] toLocation = new int[2];
    public int priority;
    public Checker piece;
    public AIMove(int p, int[] f, int[] t, Checker pe)
    {
        priority = p;
        fromLocation = f;
        toLocation = t;
        piece = pe;
    }
}