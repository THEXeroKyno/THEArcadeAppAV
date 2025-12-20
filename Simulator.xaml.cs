using Vision;

namespace THEArcadeAppAV;
public partial class Simulator : ContentPage
{
	List<String> cards = new List<string>()
	{
		"abigal.jpg",
		"blue.jpg",
		"coral.png",
		"cursed.png",
		"hot_pepper.png",
		"noback.png",
		"robin.png",
		"greenman.jpg",
		"tuna.png",
		"yay.png",
		"yayy.png",
		"testingimage.png"
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

		String imageSource1 = cards[rand1];
		String imageSource2 = cards[rand2];
		String imageSource3 = cards[rand3];
		String imageSource4 = cards[rand4];

		Card1.Source = imageSource1;
		Card2.Source = imageSource2;
		Card3.Source = imageSource3;
		Card4.Source = imageSource4;

		await TopPack.TranslateTo(TopPack.X - 340, 0, 2000, Easing.Linear);
		await TopPack.FadeTo(0);

		await BottomPack.TranslateTo(0, BottomPack.Y + 300, 2000, Easing.Linear);
		await BottomPack.FadeTo(0);

		await Card1.TranslateTo(Card1.X - 300, 0);
		await Card4.TranslateTo(Card1.X + 490, 0);
		await Card2.TranslateTo(Card1.X - 60, 0);
		await Card3.TranslateTo(Card1.X + 215, 0);
    }

	private void inv_Clicked(object sender, EventArgs e)
    {
        
    }
}