using System.Data.Common;

namespace THEArcadeAppAV;

public partial class Zoo : ContentPage
{
	List<String> commonList = new List<String>()
	{
		"a1",
		"a2",
		"a3",
		"a4",
		"a5",
		"a6",
		"a7",
		"a8"
	};
	List<String> rareList = new List<String>()
	{

	};
	List<String> legendaryList = new List<String>()
	{
		"a9",
		"a10",
		"a11",
		"a12"
	};
	public Zoo()
	{
		InitializeComponent();
		AddDatabase();
	}

	public void AddDatabase()
	{
		App.UserRepo.ClearCards(); // clear card table

		//commons
		App.UserRepo.AddCard("a1", "a1.png", 2, 5, "common"); //anchovy
		App.UserRepo.AddCard("a2", "a2.png", 5, 5, "common"); //sunfish
		App.UserRepo.AddCard("a3", "a3.png", 5, 15, "common"); //Pufferfish
		App.UserRepo.AddCard("a4", "a4.png", 5, 5, "common"); // red snapper
		App.UserRepo.AddCard("a5", "a5.png", 10, 5, "common"); // salmon
		App.UserRepo.AddCard("a6", "a6.png", 8, 15, "common"); //albacore
		App.UserRepo.AddCard("a7", "a7.png", 8, 8, "common"); //squid
		App.UserRepo.AddCard("a8", "a8.png", 15, 15, "common"); //sturgen
		//rare

		//ledgenary
		App.UserRepo.AddCard("a8", "a8.png", 15, 15, "legendary");
		CreateBoard();
	}

	public void CreateBoard()
	{
		int rows = 4;
		int column = 5;

		for(int i = 0; i < column; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				Color color = new Color();

				if(j == 1 || j == 2)
				{
					color = Color.FromRgb(255, 255, 255); //white
				}
				else
				{
					color = Color.FromRgb(0, 0, 0); //black
				}

				ImageButton sq = new ImageButton()
				{
					BackgroundColor = color
				};

				GameBoard.Add(sq , i , j);
			}
		}
	}
}