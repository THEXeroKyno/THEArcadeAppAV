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

				if (j == 0) //ai AiHand
				{
					sq.Source = AiDeck[i].Name + ".png";
					Card newCard = new Card(AiDeck[i].Name, i , j);
					AiHand.Add(newCard);
					AiDeck.RemoveAt(i);
				}

				if (j == 3) //player hand
				{
					sq.Source = PlayerDeck[i].Name + ".png";
					Card newCard = new Card(PlayerDeck[i].Name, i , j);
					PlayerHand.Add(newCard);
					PlayerDeck.RemoveAt(i);
				}

				GameBoard.Add(sq , i , j);
				CardBoard.Add(new CardBoardSquare(this, sq, i ,j));
			}
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
			Card newCard = new Card(result.Name, 0, 0);

			//the new card will be added to the Deck
			Deck.Add(newCard);
		}

		for(int i = 0; i < rare; i++)
		{
			//rand num genderated
			int randNum = rand.Next(rareList.Count());

			//card will drawn from the rar list
			string name = rareList[randNum];

			//a card will be drawn from the darabase
			Cards result = App.UserRepo.GetCard(name);

			//a new card objet will be Created
			Card newCard = new Card(result.Name, 0, 0);

			//the new card will be added to the Deck
			Deck.Add(newCard);
		}

		for(int i = 0; i < legendary; i++)
		{
			//rand num genderated
			int randNum = rand.Next(legendaryList.Count());

			//card will drawn from the rar list
			string name = legendaryList[randNum];

			//a card will be drawn from the darabase
			Cards result = App.UserRepo.GetCard(name);

			//a new card objet will be Created
			Card newCard = new Card(result.Name, 0, 0);

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

		public Card IdentifyCard(int[] location)
		{
			foreach (Card card in PlayerHand)
			{
				if (card.currentLocation[0] == location[0] && card.currentLocation[1] == location[1])
				{
					return card;
				}
			}
			foreach(Card card in AiHand)
			{
				if (card.currentLocation[0] == location[0] && card.currentLocation[1] == location[1])
				{
					return card;	
				}
			}
			return null;
		}

		public void PlayerMoveCard(CardBoardSquare newSquare)
		{
			newSquare.isActive = true;
			int[] fromLocation = new int[2];

			foreach (CardBoardSquare boardCard in CardBoard)
			{
				if (boardCard.chosenForMove)
				{
					fromLocation = boardCard.location;

					foreach (Card card in PlayerHand)
					{
						if (card.currentLocation[0] == fromLocation[0] && card.currentLocation[1] == fromLocation[1])
						{
							card.currentLocation[0] = newSquare.location[0];
							card.currentLocation[1] = newSquare.location[1];

							newSquare.square.Source = card.Name + ".png";

							PlayerField.Add(card);
						}
					}

					boardCard.square.Source = PlayerDeck[0].Name = ".png";
					boardCard.square.Scale = 1;
					boardCard.chosenForMove = false;
				}
			}

			foreach (CardBoardSquare boardCard in CardBoard)
			{
				boardCard.RemoveEvents();
			}

			//DrawCard(PlayerDeck, fromLocation, PlayerHand);
		}

		public void DrawCard(List<Card> deck, int[] fromLocation, List<Card> hand)
		{
			Card newCard = new Card(deck[0].Name, fromLocation[0], fromLocation[1]);

			hand.Add(newCard);

			deck.RemoveAt(0);
		}

		public void DeleteCard(Card card)
		{
			CardBoardSquare effectedSquare = IdentifyCardBoardSquare(card.currentLocation);

			effectedSquare.square.Source = null;
			effectedSquare.square.BackgroundColor = Color.FromRgb(255, 255, 255);

			if (card.currentLocation[1] == 1)
			{
				AiField.Remove(card);
				AiHealthNumber--;
				UpdateHealth(AiHealthNumber, playerHealthNumber);
			}
			if (card.currentLocation[1] == 2)
			{
				PlayerField.Remove(card);
				playerHealthNumber--;
				UpdateHealth(AiHealthNumber, playerHealthNumber);
			}
		}

		public CardBoardSquare IdentifyCardBoardSquare (int[] location)
		{
			foreach (CardBoardSquare square in CardBoard)
			{
				if(square.location[0] == location[0] && square.location[1] == location[1])
				{
					return square;
				}
			}

			return null;
		}

		public void AttackThis(CardBoardSquare targetBoard)
		{
			int[] targetLocation = new int[2] { targetBoard.location[0], targetBoard.location[1] };

			Card target = IdentifyCard(targetLocation);

			Cards targetData = App.UserRepo.GetCard(target.Name);

			foreach (CardBoardSquare playerCard in CardBoard)
			{
				if (playerCard.chosenforattack)
				{
					Card attacker = IdentifyCard(playerCard.location);

					Cards attackerData = App.UserRepo.GetCard(attacker.Name);

					if(attackerData.Attack > targetData.Hitpoint)
					{
						DeleteCard(target);
					}
					if(attackerData.Attack < targetData.Hitpoint)
					{
						DeleteCard(attacker);
					}
					playerCard.square.Scale = 1;
				}
			}

			foreach (CardBoardSquare boardCard in CardBoard)
			{
				boardCard.ToggleCard();
			}
		}

    private void EndTurnButton_Clicked(object sender, EventArgs e)
	{
		AiTurn();
	}

	public void AiTurn();
	{
		int cardsinField = AiField.Count;
		int playerHighestHitPoint = 0;
		Cards playerCard = null;
		Card target = null;
		Card Aicard = null;
		bool endTurn = false;
		List<Card> playerAiCard = new List<Card>();

		foreach (Card card in PlayerField)
		{
			playerCard = App.UserRepo.GetCard(card.Name);
			
			if(playerCard.Hitpoint > playerHighestHitpointCard)
			{
				playerHighestHitPointCard = playerCard.Hitpoint;
				target = card;
			}
		}

		foreach (Card card in Aihand)
		{
			Cards AiCardData = App.UserRepo.GetCard(Card.Name);
			
			if(AiCardData.Attack > playerHighestHitpointCard)
			{
				playableAiCard.Add(card);
			}
			else
			{
				if(AiCardData.Hitpoint > playerHighestHitpointCard)
				{
					playableAiCard.Add(card);
				}
			}
		}
		foreach (Card card in playableAiCard)
		{
			AiCard = card;
			int currentCardAttack = App.UserRepo.GetCard(AiCard.Name).Attack;
			int CardInListAttack = App.UserRepo.GetCard(card.Name).Attack;

			if(currentCardAttack >= cardInListAttack)
			{
				AiCard = card;
			}
		}

		if(cardsinField < 2)
		{
			
		}
		else
		{
			
			foreach (Card card in AiField)
			{
				Cards cardData = App.UserRepo.GetCard(card.Name);

				if(cardData.Attack > playerCard.HitPoint)
				{
					
				}
			}
		}
		foreach (CardBoardSquare cbs in CardBoard)
		{
			cbs.ToggleCard();
		}
	}

	public void AiPlayCard(Card card)
	{
		int[] currentLocation = new int[2] { card.currentLocation[0], card.currentLocation[1] };
		int[] downMove = new int[2] { card.currentLocation[0], card.currentLocation[1] + 1};
		int[] downRightMove new int[2] { card.currentLocation[0] + 1, card.currentLocation[1] + 1};
		int[] downLeftMove = new int[2] { card.currentLocation[0] - 1, card.currentLocation[1] - 1};
		CardBoardSquare fromSquare = IdentifyCardBoardSquare(currentLocation);
		CardBoardSquare toSquare = IdentifyCardBoardSquare(downMove);

		if(Convert.ToString(toSquare.square.Source).Length > 2)
		{
			toSquare = IdentifyCardBoardSquare(downLeftMove);

			if(Convert.ToString(toSquare.square.Source).Length > 2)
			{
				toSquare = IdentifyCardBoardSquare(downRightMove);
				
				card.currentLocation = toSquare.location;
				fromSquare.square.Source = AiDeck[0].Name + ".png";
				toSquare.square.Source = card.Name + ".png";
				Card newCard = new Card(card.Name, toSquare.location[0])
				AiField.Add(newCard);
			}
			else
			{
				card.currentLocation = toSquare.location;
				fromSquare.square.Source = AiDeck[0].Name + ".png";
				toSquare.square.Source = card.Name + ".png";
				Card newCard = new Card(Card.Name, toSquare.location[0], toSquare.location[1]);
				AiField.Add(newCard);
			}
		}
		else
		{
			card.currentLocation = toSquare.location;
			fromSquare.square.Source = AiDeck[0].Name + ".png";
			toSquare.square.Source = card.Name + ".png";
			Card newcard = new Card(card.Name, toSquare.location[0], toSquare.location[1]);
			AiField.Add(newCard);
		}
	}


}

	public class Card
	{
		public string Name;
		public int[] currentLocation = new int[2];
		public Card(string name, int i, int j)
		{
			this.Name = name;
			currentLocation[0] = i;
			currentLocation[1] = j;
		}
	}

	public class CardBoardSquare
	{
		Zoo p;
		public ImageButton square;
		public int[] location = new int[2];
		public bool isActive = false;
		public bool chosenForMove = false;
		public bool chosenforattack = false;
		public int currentState = 0;
		public EventHandler DoToggle;
        public EventHandler DoMove;
		public EventHandler CanAttack;

		public CardBoardSquare(Zoo page, ImageButton sq, int i, int j)
		{
			p = page;
			square = sq;
			location[0] = i;
			location[1] = j;
			ToggleCard();
		}

		public void ToggleCard()
		{
			if(Convert.ToString(square.Source).Length > 3) //if there is a card
			{
				isActive = true;
				if (IsUserCard())
				{
					DoToggle = (sender, args) =>
					{
						Card currentCard = p.IdentifyCard(location); //get current card
						if(currentState == 0 && (p.cardIsSelected == false))
						{
							square.Scale = 1.1;
							currentState = 1;
							p.cardIsSelected = true;
							//check for attack or move class
							CheckMoveOrAttack(currentCard);
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
			else
			{
				//there is no card (sw is empty)
				if(location[1] == 2)
				{
					//user move here
					EmptySquare();
				}
				if(location[1] == 2)
				{
					//user can attack here
					EnemySquare();
				}
			}
		}
	
	public bool IsUserCard()
	{
		if (location[1] == 2 || location[1] == 3)
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
			if(Convert.ToString(square.BackgroundColor) == Convert.ToString(Color.FromRgb(255, 255, 255)) || Convert.ToString(square.Source).Length == 0)
			{
				currentState = 0;
				chosenForMove = false;
				p.cardIsSelected = false;
				square.BackgroundColor = Color.FromRgb(0, 0, 0); //black

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
			if(Convert.ToString(square.Source).Length > 1)
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

}
