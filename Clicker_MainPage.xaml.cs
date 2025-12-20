using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AudioToolbox;

namespace THEArcadeAppAV;

public partial class Clicker_MainPage : ContentPage
{

    public Bank Bankk = new Bank("Adrienne", 0, 10, 100, 1);
    public Clicker clickerr = new Clicker(1, 5, 1);
    public PassiveIncome PassiveIncomee = new PassiveIncome(0, 100, 1);
    public Interest interest = new Interest(1, 10000, 1);


    public static string[] acheievements = new string[4]
    {
        "Acheievement: First Click",
        "Acheievement: 67",
        "Acheievement: wow ur rich",
        "Acheievement: 100G wowowoowow",
    };

    public static bool[] acheievementsOnce = new bool[4]
    {
        false, false, false, false
    };

    private readonly List<Label> activePopup = new();
    public async Task Showpopupasync(string text)
    {
        var popup = new Label
        {
            Text = text,
            TextColor = Colors.Gold,
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            Opacity = 1,
            TranslationY = 0,
        };
        objectclicked.Children.Add(popup);
        activePopup.Add(popup);
        await popup.TranslateTo(0, -80, 800, Easing.SinInOut);
        await popup.FadeTo(0, 400);
        objectclicked.Children.Remove(popup);
        activePopup.Remove(popup);
    }   

    public class Clicker
    {
        public int clicker_Value;
        public int clicker_Cost;
        public int clicker_Level;
        public Clicker(int clicker_Value, int clicker_Cost, int clicker_Level)
        {
            this.clicker_Value = clicker_Value;
            this.clicker_Cost = clicker_Cost;
            this.clicker_Level = clicker_Level;
        }
        public void Upgrade()
        {
            clicker_Value += 3;
            clicker_Cost = clicker_Cost * 2 + 5;
            clicker_Level++;
        }
    }

    public class Bank
        {
            public string name;
            public int balance;
            public int gold_cost;
        public int level_Cost;
        public int level;

        public Bank(string name, int balance, int gold_cost, int level_Cost, int level)
        {
            this.name = name;
            this.balance = balance;
            this.gold_cost = gold_cost;
            this.level_Cost = level_Cost;
            this.level = level;
        }

        public void addBalance(int value)
        {
            this.balance += value;
        }
    }

    public class PassiveIncome
        {
            public int passiveincome_Value;
            public int passiveincome_Cost;
            public int passiveincome_Level;
            public PassiveIncome(int passiveincome_Value, int passiveincome_Cost, int passiveincome_Level)
            {
                this.passiveincome_Value = passiveincome_Value;
                this.passiveincome_Cost = passiveincome_Cost;
                this.passiveincome_Level = passiveincome_Level;
            }
        public void Upgrade()
        {
            passiveincome_Value += 3;
            passiveincome_Cost = passiveincome_Cost * 2 - 3;
            passiveincome_Level++;
        }
        
    }

    public class Interest
    {
        public int interest_value;
        public int interest_cost;
        public int interest_level;
        public Interest(int interest_value, int interest_cost, int interest_level)
        {
            this.interest_value = interest_value;
            this.interest_cost = interest_cost;
            this.interest_level = interest_level;
        }
        public void Upgrade()
        {
            interest_value += 10;
            interest_cost = interest_cost * 2 + 250;
            interest_level++;
        }
    }

    public Clicker_MainPage()
    {
        InitializeComponent();
        animation();
        FirstUpgrade.Text = "clicker upgrade = G" + clickerr.clicker_Cost;
        SecondUpgrade.Text = "passive upgrade: G" + PassiveIncomee.passiveincome_Cost;
        ThirdUpgrade.Text = "interest upgrade: G" + interest.interest_cost;
    }

    public async void acheievementpopup(string message)
    {
        var popupacheievement = new Label { Text = message, FontSize = 40, HorizontalOptions = LayoutOptions.Center, TextColor=Colors.Black};
        acheievementpopuplayout.Children.Add(popupacheievement);
        await popupacheievement.FadeTo(1, 300);
        await Task.Delay(5000);
        await popupacheievement.FadeTo(0, 300);
        acheievementpopuplayout.Children.Remove(popupacheievement);
    }
    
    public void acheievementcheckfunction()
    {
        if (Bankk.balance == 67 && acheievementsOnce[1] == false)
        {
            acheievementpopup(acheievements[1]);
            acheievementsOnce[1] = true;
        }
        else if (Bankk.balance >= 100 && acheievementsOnce[3] == false)
        {
            acheievementpopup(acheievements[3]);
            acheievementsOnce[3] = true;
        }
        else if (Bankk.balance == 1 && acheievementsOnce[0] == false)
        {
            acheievementpopup(acheievements[0]);
            acheievementsOnce[0] = true;
        }
        else if (Bankk.balance >= 10000 && acheievementsOnce[2] == false)
        {
            acheievementpopup(acheievements[2]);
            acheievementsOnce[2] = true;
        }
    }

    private async void JunimoTapped(object sender, TappedEventArgs e)
    {
        Bankk.addBalance(clickerr.clicker_Value * interest.interest_value);
        acheievementcheckfunction();
        changeMoney_label();
        await Showpopupasync("+" + clickerr.clicker_Value * interest.interest_value);
    }

    private async void FirstUpgrade_Clicked(object sender, EventArgs e)
    {
        if (Bankk.balance >= clickerr.clicker_Cost)
        {
            Bankk.balance -= clickerr.clicker_Cost;
            clickerr.Upgrade();
            FirstUpgrade.Text = "clicker upgrade = G" + clickerr.clicker_Cost;
            changeMoney_label();
        }
        else
        {
            //FirstUpgrade.BackgroundColor = Colors.DarkRed;
            await Task.Delay(1000);
            //FirstUpgrade.BackgroundColor = Colors.("#e88c14");
        }
    }

    private void changeMoney_label()
    {
        moneycounter.Text = Bankk.balance.ToString();
    }

    private async void SecondUpgrade_Clicked(object sender, EventArgs e)
    {
        if (Bankk.balance >= PassiveIncomee.passiveincome_Cost)
        {
            Bankk.balance -= PassiveIncomee.passiveincome_Cost;
            PassiveIncomeee();
            PassiveIncomee.Upgrade();
            SecondUpgrade.Text = "passive upgrade: G" + PassiveIncomee.passiveincome_Cost;
            changeMoney_label();
        }
        else
        {
            //FirstUpgrade.BackgroundColor = Colors.DarkRed;
            await Task.Delay(1000);
            //FirstUpgrade.BackgroundColor = Colors.
        }

    }
    
    async public void PassiveIncomeee()
    {
        Bankk.balance += PassiveIncomee.passiveincome_Value * interest.interest_value;
        acheievementcheckfunction();
        changeMoney_label();
        await Showpopupasync("+" + PassiveIncomee.passiveincome_Value * interest.interest_value);
        await Task.Delay(1000);
        PassiveIncomeee();
    }

    private async void ThirdUpgrade_Clicked(object sender, EventArgs e)
    {
        if (Bankk.balance >= interest.interest_cost)
        {
            Bankk.balance -= interest.interest_cost;
            interest.Upgrade();
            ThirdUpgrade.Text = "interest upgrade: G" + interest.interest_cost;
            changeMoney_label();
        }
        else
        {
            //FirstUpgrade.BackgroundColor = Colors.DarkRed;
            await Task.Delay(1000);
            //FirstUpgrade.BackgroundColor = Colors.
        }
    }
    
    public async void animation()
    {
        if (firstimage.IsVisible == true)
        {
            firstimage.IsVisible = false;
            secondimage.IsVisible = true;
            await Task.Delay(1000);
            animation();
        }
        else
        {
            firstimage.IsVisible = true;
            secondimage.IsVisible = false;
            await Task.Delay(1000);
            animation();
        }
    }

}