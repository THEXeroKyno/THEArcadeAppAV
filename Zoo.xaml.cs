using System.Data.Common;
using System.Runtime.CompilerServices;
using THEArcadeAppAV;
using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;

public partial class Zoo : ContentPage
{
	public List<CardBoardSquare> CardBoard = new List<CardBoardSquare>();
	public List<Card> PlayerDeck = new List<Card>();
	public List<Card> PlayerHand = new List<Card>();
	public List<Card> PlayerField = new List<Card>();

	public List<Card> AiDeck = new List<Card>();
	public List<Card> AiHand = new List<Card>();
	public List<Card> AiField = new List<Card>();
	public bool cardIsSelected = false;
	public int playerHealthNumber = 10;
	public int AiHealthNumber = 10;
	List<String> commonList = new List<String>()
	{
		"a1",
		"a2",
		"a3",
		"a4",
		"a5",
		"a6",
		"a7",
		"a8",
		"a13"
	};
	List<String> rareList = new List<String>()
	{
		"a13",
		"a14",
		"a15",
		"a16",
	};
	List<String> legendaryList = new List<String>()
	{
		"a9",
		"a10",
		"a11c",
		"a12c",
		"a17"
	};
	public Zoo()
	{
		InitializeComponent();
		AddDatabase();

		UserHealth.Text = playerHealthNumber.ToString();
		AIHealth.Text = AiHealthNumber.ToString();
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
		
		//ledgenary
		App.UserRepo.AddCard("a9", "a9.png", 80, 1000, "legendary"); //mutan carp
		App.UserRepo.AddCard("a10", "a10.png", 110, 5000, "legendary"); //legendary
		App.UserRepo.AddCard("a11c", "a11.png", 95, 1500, "legendary"); //Crimson fish
		App.UserRepo.AddCard("a12c", "a9.png", 85, 900, "legendary"); //Angler
		App.UserRepo.AddCard("a17", "a17.png", 110, 15000, "legendary"); //advanced

		PopulateDeck(AiDeck);
		PopulateDeck(PlayerDeck);

		CreateBoard();
	}

	public void CreateBoard()
	{
		int handSize = 5;

		for (int i = 0; i < handSize; i++)
		{
			ImageButton sq = new ImageButton();
			sq.Source = AiDeck[0].Name + ".png";
			Card newCard = AiDeck[0];
			newCard.spot = i;
			newCard.location = "AiHand";
			AiHand.Add(newCard);
			AiDeck.RemoveAt(0);
			AiHandGrid.Add(sq,i,0);
			CardBoard.Add(new CardBoardSquare(this,sq, i, "AiHand", false));
		}

		for (int i = 0; i < handSize; i++)
		{
			ImageButton sq = new ImageButton();
			PLayerFieldGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i ,"PlayerField", true));
		}

		for (int i = 0; i < handSize; i++)
		{
			ImageButton sq = new ImageButton();
			AiFieldGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i ,"AiField", true));
		}

		for (int i = 0; i < handSize; i++)
		{
			ImageButton sq = new ImageButton();
			sq.Source = PlayerDeck[0].Name + ".png";
			Card newCard = PlayerDeck[0];
			newCard.spot = i;
			newCard.location = "PlayerHand";
			PlayerHand.Add(newCard);
			PlayerDeck.RemoveAt(0);
			PLayerHandGrid.Add(sq,i,0);
			CardBoard.Add(new CardBoardSquare(this,sq, i, "PlayerHand", false));
		}
	}
	public void PopulateDeck(List<Card> Deck)
	{
		int common = 15;
		int rare = 10;
		int legendary = 5;
		Random rand = new Random();

		for(int i = 0; i < common; i++)
		{
			//rand num genderated
			int randNum = rand.Next(commonList.Count());

			//card will drawn from the rar list
			string name = commonList[randNum];

			//a card will be drawn from the darabase
			Cards result = App.UserRepo.GetCard(name);

			//a new card objet will be Created
			Card newCard = new Card(result.Name, 0, "DECK");

			//the new card will be added to the Deck
			Deck.Add(newCard);
		}

		for(int r = 0; r < rare; r++)
		{
			//rand num genderated
			int randNum = rand.Next(rareList.Count());

			//card will drawn from the rar list
			string name = rareList[randNum];

			//a card will be drawn from the darabase
			Cards result = App.UserRepo.GetCard(name);

			//a new card objet will be Created
			Card newCard = new Card(result.Name, 0, "DECK");

			//the new card will be added to the Deck
			Deck.Add(newCard);
		}

		for(int l = 0; l < legendary; l++)
		{
			//rand num genderated
			int randNum = rand.Next(legendaryList.Count());

			//card will drawn from the rar list
			string name = legendaryList[randNum];

			//a card will be drawn from the darabase
			Cards result = App.UserRepo.GetCard(name);

			//a new card objet will be Created
			Card newCard = new Card(result.Name, 0, "DECK");

			//the new card will be added to the Deck
			Deck.Add(newCard);

			ShuffleDeck(Deck);
		}
	}
		//shuffle Deck
		public List<Card> ShuffleDeck(List<Card> deck)
		{
			for(int i = deck.Count() - 1; i >= 0; i--)
			{
				Random shuffleNum = new Random();
				int k = shuffleNum.Next(i + 1);
				var card = deck[k];
				deck[k] = deck[i];
				deck[i] = card;
			}
			return deck;
		}

		public Card IdentifyCard(int spot, string location)
		{
			foreach (Card card in PlayerHand)
			{
				if (card.spot == spot && card.location == location)
				{
					return card;
				}
			}
			foreach(Card card in AiHand)
			{
				if (card.spot == spot && card.location == location)
				{
					return card;	
				}
			}
			foreach (Card card in PlayerField)
			{
				if (card.spot == spot && card.location == location)
				{
					return card;
				}
			}
			foreach(Card card in AiField)
			{
				if (card.spot == spot && card.location == location)
				{
					return card;	
				}
			}
			return null;
		}

		public void PlayerMoveCard(CardBoardSquare newSquare)
		{
			int index = 0;

			foreach (CardBoardSquare boardCard in CardBoard)
			{
				if (boardCard.chosenForMove && boardCard.location == "playerhand")
				{
					index = boardCard.spot;
					for (int x = 0; x < PlayerHand.Count; x++)
				{
					if(PlayerHand[x].spot == index)
					{
						newSquare.square.Source = PlayerHand[x].Name + ".png";
						newSquare.empty = false;
						PlayerHand[x].location = "playerfield";
						PlayerHand[x].spot = index;
						PlayerField.Add(PlayerHand[x]);
						PlayerHand.Remove(PlayerHand[x]);
					}
				}

					Card newCard = PlayerDeck[0];
					newCard.location = "playerhand";
					newCard.spot = index;
					PlayerHand.Add(newCard);

					boardCard.Square.Source = PlayerDeck[0].Name + ".png";
					PlayerDeck.RemoveAt(0);
					boardCard.Square.Scale = 1;
					boardCard.ChosenForMove = false;
					cardIsSelected = false;
					boardCard.currentState = 0;
					boardCard.empty = false;
					
					boardCard.square.Source = PlayerDeck[0].Name = ".png";
					boardCard.square.Scale = 1;
					boardCard.chosenForMove = false;
				}
			}

			foreach (CardBoardSquare boardCard in CardBoard)
			{
				boardCard.RemoveEvents();
			}

		}

		public void DeleteCard(Card card)
		{
			CardBoardSquare cbsq = null;

			if (card.location == "aifield")
			{
				cbsq = IdentifyCardBoardSquare(card.spot, "aiField");
				cbsq.square.Source = null;
				cbsq.empty = true;
				AiField.Remove(card);
				AiHealthNumber--;
				UpdateHealth(AiHealthNumber, playerHealthNumber);
			}
			if (card.location == "playerfield")
			{
				cbsq = IdentifyCardBoardSquare(card.spot, "PlayerField");
				cbsq.square.Source = null;
				cbsq.empty = true;
				PlayerField.Remove(card);
				playerHealthNumber--;
				UpdateHealth(AiHealthNumber, playerHealthNumber);
			}
		}

		public CardBoardSquare IdentifyCardBoardSquare (int spot, string location)
		{
			foreach (CardBoardSquare square in CardBoard)
			{
				if(square.spot == spot && square.location == location)
				{
					return square;
				}
			}

			return null;
		}

		public void AttackThis(CardBoardSquare targetBoard)
		{

			Card target = IdentifyCard(targetboard.spot, "aifield");

			Cards targetData = App.UserRepo.GetCard(target.Name);

			Card attackerCard = null;
			foreach (CardBoardSquare attacker in CardBoard)
			{
				if (attacker.chosenforattack)
				{
					attackerCard = IdentifyCard(attacker.spot, "playerfield");
					attacker.square.Scale = 1;
				}
			}
			Cards attackerdata = App.UserRepo.GetCard(attackerCard.Name);
			
			if(attackerdata.Hitpoint <= targetData.Attack && targetData.Hitpoint <= attackerdata.Attack)
		{
			DeleteCard(target);
			DeleteCard(attackerCard);
		}
		else
		{
			if(targetData.Hitpoint <= attackerdata.Attack)
			{
				DeleteCard(target);
			}
			else if (attackerdata.Hitpoint <= targetData.Attack)
			{
				DeleteCard(attackerCard);
			}
		}
			
			foreach (CardBoardSquare boardCard in CardBoard)
			{
				boardCard.RemoveEvents();
			}
		}

    private void EndTurnButton_Clicked(object sender, EventArgs e)
	{
		if (PlayerField.Count == 0)
		{
			foreach (CardBoardSquare bs in CardBoard)
			{
				bs.RemoveEvents();
			}
		}
		AiTurn();
	}

	public void AiTurn()
	{
		int cardsinField = AiField.Count;
		int playerlowestHitPoint = 1000;
		Cards playerCard = null;
		Card target = null;
		Card Aicard = null;
		Card Temp = null;
		List<Card> playableAiCard = new List<Card>();

		foreach (Card card in PlayerField)
		{
			playerCard = App.UserRepo.GetCard(card.Name);
			
			if(playerCard.Hitpoint < playerlowestHitPoint)
			{
				playerlowestHitPoint = playerCard.Hitpoint;
				target = card;
			}
		}

		foreach (Card card in AiHand)
		{
			Cards AiCardData = App.UserRepo.GetCard(Card.Name);
			CardBoardSquare moveTo = IdentifyCardBoardSquare(card.spot, "aifield");

			if (moveTo.empty)
			{
				if(AiCardData.Attack > playerlowestHitPoint)
				{
					playableAiCard.Add(card);
				}
				else
				{
					if(AiCardData.Hitpoint > playerlowestHitPoint)
					{
						playableAiCard.Add(card);
					}
					else
					{
						playableAiCard.Add(card);
					}
				}
			}	
		}

		if(cardsinField < 2 || PlayerField.Count == 0)
		{
			Temp = playableAiCard[0];
			foreach (Card card in playableAiCard)
			{
				int tempAtt = App.UserRepo.GetCard(Temp.Name).Attack;
				int cardAtt = App.UserRepo.GetCard(card.Name).Attack;
				if (tempAtt < cardAtt)
				{
					Temp = card;
				}
			}
			AiPlayCard(Aicard);
		}
		else
		{
			Temp = AiField[0];
			foreach (Card card in AiField)
			{
				int tempAtt = App.UserRepo.GetCard(Temp.Name).Attack;
				int cardAtt = App.UserRepo.GetCard(card.Name).Attack;
				if(tempAtt < cardAtt)
				{
					Temp = card;
				}
			}
			AiAttack(Temp, target);
		}

		List<CardBoardSquare> ignoreList = new List<CardBoardSquare>();

		foreach (CardBoardSquare cbs in CardBoard)
		{
			if (cbs.location = "playerfield" && cardIsSelected.empty == false)
			{
				CardBoardSquare ignoreCard = IdentifyCardBoardSquare(cbs.spot, "playerHand");
				ignoreList.Add(ignoreCard);
			}
			cbs.ToggleCard();
		}
		foreach (CardBoardSquare ignore in ignoreList)
		{
			ignore.RemoveEvents();
		}
	}

	public void AiPlayCard(Card card)
	{
		CardBoardSquare fromSquare = IdentifyCardBoardSquare(card.spot, "aihand");
		CardBoardSquare toSquare = IdentifyCardBoardSquare(card.spot, "aiField");

		int index = fromSquare.spot;
		AiHand.Remove(IdentifyCard(card.spot, "AiHand"));
		card.location = "aifield";
		AiField.Add(card);
		moveSquare.square.Source = card.Name + ".png";
		moveSquare.empty = false;

		Card newCard = AiDeck[0];
		newCard.location = "aiHand";
		newCard.spot = index;
		fromSquare.square.Source = AiDeck[0].Name + ".png";
		AiHand.Add(newCard);
		AiDeck.RemoveAt(0);
	}

	public void AiAttack(Card attack,Card target)
	{
		Card attacker = App.UserRepo.GetCard(attack.Name);
		Card defender = App.UserRepo.GetCard(target.Name);

		if(attacker.Attack >= defender.Hitpoint && attack.hitpoint <= defender.attack)
		{
			DeleteCard(target);
			DeleteCard(attack);
		}
		else
		{
			if(attacker.Attack >= defender.HitPoint)
			{
				DeleteCard(target);
			}
			else if (defender.Attack >= attacker.Hitpoint)
			{
				DeleteCard(attack);
			}
		}
	}

	public void UpdateHealth(int aH, int pH)
	{
		UserHealth.Text = pH.ToString();
		Aihealth.Text = aH.ToString();
	}


}

	public class Card
	{
		public string Name;
		public string location;
		public int spot;
		public Card(string name, int s, string l)
		{
			this.Name = name;
			spot = s;
			location = l;
		}
	}

	public class CardBoardSquare
	{
		Zoo p;
		public ImageButton square;
		public string location;
		public bool empty = true;
		public int spot = 0;
		public bool chosenForMove = false;
		public bool chosenforattack = false;
		public int currentState = 0;
		public EventHandler DoToggle;
        public EventHandler DoMove;
		public EventHandler CanAttack;

		public CardBoardSquare(Zoo page, ImageButton sq, int s, string l, bool e)
		{
			p = page;
			square = sq;
			spot = s;
			location = l;
			empty = e;
			ToggleCard();
		}

		public void ToggleCard()
		{
			if(Convert.ToString(square.Source).Length > 3) //if there is a card
			{
				if (empty == false) //if there is a card
				{
					
				if (IsUserCard())
				{
					DoToggle = (sender, args) =>
					{
						if(currentState == 0 && (p.cardIsSelected == false))
						{
							square.Scale = 1.1;
							currentState = 1;
							p.cardIsSelected = true;
							//check for attack or move class
							if(location == "playerhand")
							{
								chosenForMove=true;
							}
							if (location == "PlayerField")
							{
								chosenforattack=true;
							}
						}
						else if (chosenforattack || chosenForMove)
						{
							chosenForMove = false;
							chosenforattack = false;
							currentState = 0;
							p.cardIsSelected = false;
							square.Scale = 1;
						}
					};
					square.Clicked += DoToggle;
				}
				}
			}
			else
			{
				//there is no card (sw is empty)
				if(location == "PlayerField")
				{
					//user move here
					EmptySquare();
				}
				if(location == "AiField")
				{
					//user can attack here
					EnemySquare();
				}
			}
		}
	
	public bool IsUserCard()
	{
		if (location == "PlayerHand" || location == "PlayerField")
		{
			return true;
		}
		return false;
	}

	public void CheckMoveOrAttack(Card card)
	{
		if (card.currentLocation[1] == 3) // if card is in user hand
		{
			chosenForMove = true;
		}
		else //else 
		{
			chosenforattack = true;
		}
	}

	public void EmptySquare()
	{
		DoMove = (sender, args) =>
		{
			if(Convert.ToString(square.Source).Length == 0)
			{
				currentState = 0;
				chosenForMove = false;
				p.cardIsSelected = false;

				p.PlayerMoveCard(this);
			}
		};
		square.Clicked += DoMove;
	}
	// color = Color.FromRgb(255, 255, 255); //white

	public void EnemySquare()
	{
		CanAttack = (sender, args) =>
		{
			if(Convert.ToString(square.Source).Length > 0)
			{
				currentState = 0;
				chosenforattack = false;
				p.cardIsSelected = false;
				//player attack
				p.AttackThis(this);
			}
		};
		square.Clicked += CanAttack;
	}

	public void RemoveEvents()
	{
		square.Clicked -= DoToggle;
		square.Clicked -= DoMove;
	}

	public void CheckWin()
	{
		if(AiField.Count == 5 || PlayerField.Count == 5)
		{
			foreach(CardBoardSquare cbs in Cardboard)
			{
				cbs.RemoveEvents();
				cbs.square.IsEnabled = false;

			}
			if(Aifield.count == 5)
			{
				EndTurnButton.Text = "AI WINS";
			}
			else
			{
				EndTurnButton.Text = "YOU WIN"
			}
		}
		if(playerhealthNumber == 0 || AtHealthNumber == 0)
		{
			foreach(CardBoardSquare cbs in Cardboard)
			{
				cbs.RemoveEvents();
				cbs.square.IsEnabled = false;

			}
			if(Aifield.count == 0)
			{
				EndTurnButton.Text = "AI WINS";
			}
			else
			{
				EndTurnButton.Text = "YOU WIN"
			}
			endTurnButton.IsEnabled = false;
		}
	}


}
