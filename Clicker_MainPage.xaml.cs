using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using AudioToolbox;

namespace THEArcadeAppAV;

public partial class Clicker_MainPage : ContentPage
{
    
    public Bank Bankk = new Bank("Adrienne", 0, 10, 100, 1);
    public Clicker clickerr = new Clicker(1, 5, 1);
    public PassiveIncome PassiveIncomee = new PassiveIncome(0, 100, 1);
    

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

    
    
    public Clicker_MainPage ()
    {
        InitializeComponent();
        FirstUpgrade.Text = "clicker upgrade = G" + clickerr.clicker_Cost;
        SecondUpgrade.Text = "passive upgrade: G" + PassiveIncomee.passiveincome_Cost;

    }

    private void JunimoTapped(object sender, TappedEventArgs e)
    {
        Bankk.addBalance(clickerr.clicker_Value);
        changeMoney_label();
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
            //FirstUpgrade.BackgroundColor = Colors.
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
        Bankk.addBalance(PassiveIncomee.passiveincome_Value);
        changeMoney_label();
        await Task.Delay(1000);
        PassiveIncomeee();
    }
    
}