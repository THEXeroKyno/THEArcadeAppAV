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
		App.UserRepo.AddCard("a1", "a1.png", 30, 30, "common"); //anchovy attack is first meaning put g as health
		App.UserRepo.AddCard("a2", "a2.png", 28, 30, "common"); //sunfish
		App.UserRepo.AddCard("a3", "a3.png", 80, 200, "common"); //Pufferfish
		App.UserRepo.AddCard("a4", "a4.png", 40, 50, "common"); // red snapper
		App.UserRepo.AddCard("a5", "a5.png", 50, 75, "common"); // salmon
		App.UserRepo.AddCard("a6", "a6.png", 60, 75, "common"); //albacore
		App.UserRepo.AddCard("a7", "a7.png", 75, 80, "common"); //squid
		App.UserRepo.AddCard("a8", "a8.png", 78, 200, "common"); //sturgen
		App.UserRepo.AddCard("a13", "a13.png", 30, 25, "common"); //triaining
		//rare
		App.UserRepo.AddCard("a14", "a14.png", 50, 500, "rare"); //bamboo
		App.UserRepo.AddCard("a15", "a15.png", 70, 1800, "rare"); //fiberglass
		App.UserRepo.AddCard("a16", "a16.png", 90, 7500, "rare"); //iridium
		App.UserRepo.AddCard("a17", "a17.png", 110, 15000, "rare"); //advanced
		//ledgenary
		App.UserRepo.AddCard("a9", "a9.png", 80, 1000, "legendary"); //mutan carp
		App.UserRepo.AddCard("a10", "a10.png", 110, 5000, "legendary"); //legendary
		App.UserRepo.AddCard("a11c", "a11.png", 95, 1500, "legendary"); //Crimson fish
		App.UserRepo.AddCard("a12c", "a9.png", 85, 900, "legendary"); //Angler
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