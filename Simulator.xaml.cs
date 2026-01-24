using THEArcadeAppAV.Models;
using Vision;

namespace THEArcadeAppAV;
public partial class Simulator : ContentPage
{
	List<String> cards = new List<string>()
	{
		"a1.png",
		"a2.png",
		"a3.png",
		"a4.png",
		"a5.png",
		"a6.png",
		"a7.png",
		"a8.png",
		"a9.png",
		"a10.png",
		"a11.png",
		"a12.png"
	};

	List<String> columns = new List<String>()
	{
		"abigal",
        "blue",
        "coral",
        "cursed",
        "hot_pepper",
        "noback",
        "robin",
        "greenman",
        "tuna",
        "yay",
        "yayy",
        "testingimage"
	};
	public Simulator()
	{
		InitializeComponent();
	}

    async private void open_Clicked(object sender, EventArgs e)
    {
        var rand = new Random();
		int rand1 = rand.Next(12);

		rand = new Random();
		int rand2 = rand.Next(12);
		
		rand = new Random();
		int rand3 = rand.Next(12);

		rand = new Random();
		int rand4 = rand.Next(12);

		string imageSource1 = cards[rand1];
		string column1 = columns[rand1];
		string imageSource2 = cards[rand2];
		string column2 = columns[rand2];
		string imageSource3 = cards[rand3];
		string column3 = columns[rand3];
		string imageSource4 = cards[rand4];
		string column4 = columns[rand4];

		Users loggedInUser = App.UserRepo.GetUser(App.LoggedInUser);
		var prop1 = typeof(Users).GetProperty(column1);
		int val1 = (int)prop1.GetValue(loggedInUser);

		var prop2 = typeof(Users).GetProperty(column2);
		int val2 = (int)prop2.GetValue(loggedInUser);

		var prop3 = typeof(Users).GetProperty(column3);
		int val3 = (int)prop3.GetValue(loggedInUser);

		var prop4 = typeof(Users).GetProperty(column4);
		int val4 = (int)prop4.GetValue(loggedInUser);

		//add one to card inv
		App.UserRepo.UpdateUserFishCard(App.LoggedInUser, column1, val1 + 1);
		App.UserRepo.UpdateUserFishCard(App.LoggedInUser, column2, val2 + 1);
		App.UserRepo.UpdateUserFishCard(App.LoggedInUser, column3, val3 + 1);
		App.UserRepo.UpdateUserFishCard(App.LoggedInUser, column4, val4 + 1);

		Card1.Source = imageSource1;
		Card2.Source = imageSource2;
		Card3.Source = imageSource3;
		Card4.Source = imageSource4;

		open.Text = App.LoggedInUser;

		await TopPack.TranslateTo(TopPack.X - 340, 0, 2000, Easing.Linear);
		await TopPack.FadeTo(0);

		await BottomPack.TranslateTo(0, BottomPack.Y + 300, 2000, Easing.Linear);
		await BottomPack.FadeTo(0);

		await Card1.TranslateTo(Card1.X - 300, 0);
		await Card4.TranslateTo(Card1.X + 490, 0);
		await Card2.TranslateTo(Card1.X - 60, 0);
		await Card3.TranslateTo(Card1.X + 215, 0);
    }

	private async void inv_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("inv");   
    }
}