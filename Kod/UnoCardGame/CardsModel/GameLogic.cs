using Cards;
using Cards.Entities;
using CardsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public class GameLogic
    {
        private int myGame;
        private string me;  
        private const int StartingCards = 6;
        private static GameLogic Instance;
        private List<Card> Deck;
        private List<Card> Field;
        private List<Player> players;
        private int IndexPlaying;  
        private int MyIndex;
        private string winnerName; 
        private List<Card> myHand;
        private int fieldColor;
        private string onTurnPlayer;
        private ViewClass vc;
        private GameStatus gs;

        public GameLogic()
        {
            this.players = new List<Player>();
            this.IndexPlaying = 0;
            this.winnerName = "";
            this.Deck = new List<Card>();
            this.Field = new List<Card>();
            InicDeck();
            this.myHand = new List<Card>();
        }

        public List<Card> GetDeck()
        {
            return this.Deck;
        }

        public GameStatus ReturnGameStatus()
        {
            return this.gs;
        }

        public string ReturnWinner()
        {
            return this.winnerName;
        }

        public string GetOnTurn()
        {
            return this.onTurnPlayer;
        }

        public void SetVC(ViewClass v)
        {
            this.vc = v;
        }

        public ViewClass GetVC()
        {
            return this.vc;
        }

        public void SetMyIndex(int index)
        {
            this.MyIndex = index;
        }

        private static Random rng = new Random();

        public static void Shuffle(List<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void AddTopCardToDeck(Card card)
        {
            Deck.Add(card);
            Shuffle(Deck);
        }

        private void InicDeck()
        {
            Deck.Clear(); 
            Card c0 = new Card("0", "0");
            Card c1 = new Card("1", "0");
            Card c2 = new Card("2", "0");
            Card c3 = new Card("3", "0");
            Card c4 = new Card("4", "0");
            Card c5 = new Card("5", "0");
            Card c6 = new Card("6", "0");
            Card c7 = new Card("7", "0");
            Card c8 = new Card("8", "0");
            Card c9 = new Card("9", "0");
            Card c10 = new SkipingCard("10", "0");
            Card c11 = new ReversingCard("11", "0");
            Card c12 = new BuyingCard("12", "0", 2);
            Card c13 = new Card("1", "0");
            Card c14 = new Card("2", "0");
            Card c15 = new Card("3", "0");
            Card c16 = new Card("4", "0");
            Card c17 = new Card("5", "0");
            Card c18 = new Card("6", "0");
            Card c19 = new Card("7", "0");
            Card c20 = new Card("8", "0");
            Card c21 = new Card("9", "0");
            Card c22 = new SkipingCard("10", "0");
            Card c23 = new ReversingCard("11", "0");
            Card c24 = new BuyingCard("12", "0", 2);
            Card c25 = new Card("0", "1");
            Card c26 = new Card("1", "1");
            Card c27 = new Card("2", "1");
            Card c28 = new Card("3", "1");
            Card c29 = new Card("4", "1");
            Card c30 = new Card("5", "1");
            Card c31 = new Card("6", "1");
            Card c32 = new Card("7", "1");
            Card c33 = new Card("8", "1");
            Card c34 = new Card("9", "1");
            Card c35 = new SkipingCard("10", "1");
            Card c36 = new ReversingCard("11", "1");
            Card c37 = new BuyingCard("12", "1", 2);
            Card c38 = new Card("1", "1");
            Card c39 = new Card("2", "1");
            Card c40 = new Card("3", "1");
            Card c41 = new Card("4", "1");
            Card c42 = new Card("5", "1");
            Card c43 = new Card("6", "1");
            Card c44 = new Card("7", "1");
            Card c45 = new Card("8", "1");
            Card c46 = new Card("9", "1");
            Card c47 = new SkipingCard("10", "1");
            Card c48 = new ReversingCard("11", "1");
            Card c49 = new BuyingCard("12", "1", 2);

            Card c50 = new Card("0", "2");
            Card c51 = new Card("1", "2");
            Card c52 = new Card("2", "2");
            Card c53 = new Card("3", "2");
            Card c54 = new Card("4", "2");
            Card c55 = new Card("5", "2");
            Card c56 = new Card("6", "2");
            Card c57 = new Card("7", "2");
            Card c58 = new Card("8", "2");
            Card c59 = new Card("9", "2");
            Card c60 = new SkipingCard("10", "2");
            Card c61 = new ReversingCard("11", "2");
            Card c62 = new BuyingCard("12", "2", 2);
            Card c63 = new Card("1", "2");
            Card c64 = new Card("2", "2");
            Card c65 = new Card("3", "2");
            Card c66 = new Card("4", "2");
            Card c67 = new Card("5", "2");
            Card c68 = new Card("6", "2");
            Card c69 = new Card("7", "2");
            Card c70 = new Card("8", "2");
            Card c71 = new Card("9", "2");
            Card c72 = new SkipingCard("10", "2");
            Card c73 = new ReversingCard("11", "2");
            Card c74 = new BuyingCard("12", "2", 2);

            Card c75 = new Card("0", "3");
            Card c76 = new Card("1", "3");
            Card c77 = new Card("2", "3");
            Card c78 = new Card("3", "3");
            Card c79 = new Card("4", "3");
            Card c80 = new Card("5", "3");
            Card c81 = new Card("6", "3");
            Card c82 = new Card("7", "3");
            Card c83 = new Card("8", "3");
            Card c84 = new Card("9", "3");
            Card c85 = new SkipingCard("10", "3");
            Card c86 = new ReversingCard("11", "3");
            Card c87 = new BuyingCard("12", "3",2);
            Card c88 = new Card("1", "3");
            Card c89 = new Card("2", "3");
            Card c90 = new Card("3", "3");
            Card c91 = new Card("4", "3");
            Card c92 = new Card("5", "3");
            Card c93 = new Card("6", "3");
            Card c94 = new Card("7", "3");
            Card c95 = new Card("8", "3");
            Card c96 = new Card("9", "3");
            Card c97 = new SkipingCard("10", "3");
            Card c98 = new ReversingCard("11", "3");
            Card c99 = new BuyingCard("12", "3",2);

            Card c100 = new ChangingCard("0", "4");
            Card c101 = new BuyingCard("12", "4", 4);
            Card c102 = new ChangingCard("0", "4");
            Card c103 = new BuyingCard("12", "4", 4);
            Card c104 = new ChangingCard("0", "4");
            Card c105 = new BuyingCard("12", "4", 4);
            Card c106 = new ChangingCard("0", "4");
            Card c107 = new BuyingCard("12", "4", 4);
            Deck.Add(c1);
            Deck.Add(c2);
            Deck.Add(c3);
            Deck.Add(c4);
            Deck.Add(c5);
            Deck.Add(c6);
            Deck.Add(c7);
            Deck.Add(c8);
            Deck.Add(c9);
            Deck.Add(c10);
            Deck.Add(c11);
            Deck.Add(c12);
            Deck.Add(c13);
            Deck.Add(c14);
            Deck.Add(c15);
            Deck.Add(c16);
            Deck.Add(c17);
            Deck.Add(c18);
            Deck.Add(c19);
            Deck.Add(c20);
            Deck.Add(c21);
            Deck.Add(c22);
            Deck.Add(c23);
            Deck.Add(c24);
            Deck.Add(c25);
            Deck.Add(c26);
            Deck.Add(c27);
            Deck.Add(c28);
            Deck.Add(c29);
            Deck.Add(c30);
            Deck.Add(c31);
            Deck.Add(c32);
            Deck.Add(c33);
            Deck.Add(c34);
            Deck.Add(c35);
            Deck.Add(c36);
            Deck.Add(c37);
            Deck.Add(c38);
            Deck.Add(c39);
            Deck.Add(c40);
            Deck.Add(c41);
            Deck.Add(c42);
            Deck.Add(c43);
            Deck.Add(c44);
            Deck.Add(c45);
            Deck.Add(c46);
            Deck.Add(c47);
            Deck.Add(c48);
            Deck.Add(c49);
            Deck.Add(c50);
            Deck.Add(c51);
            Deck.Add(c52);
            Deck.Add(c53);
            Deck.Add(c54);
            Deck.Add(c55);
            Deck.Add(c56);
            Deck.Add(c57);
            Deck.Add(c58);
            Deck.Add(c59);
            Deck.Add(c60);
            Deck.Add(c61);
            Deck.Add(c62);
            Deck.Add(c63);
            Deck.Add(c64);
            Deck.Add(c65);
            Deck.Add(c66);
            Deck.Add(c67);
            Deck.Add(c68);
            Deck.Add(c69);
            Deck.Add(c70);
            Deck.Add(c71);
            Deck.Add(c72);
            Deck.Add(c73);
            Deck.Add(c74);
            Deck.Add(c75);
            Deck.Add(c76);
            Deck.Add(c77);
            Deck.Add(c78);
            Deck.Add(c79);
            Deck.Add(c80);
            Deck.Add(c81);
            Deck.Add(c82);
            Deck.Add(c83);
            Deck.Add(c84);
            Deck.Add(c85);
            Deck.Add(c86);
            Deck.Add(c87);
            Deck.Add(c88);
            Deck.Add(c89);
            Deck.Add(c90);
            Deck.Add(c91);
            Deck.Add(c92);
            Deck.Add(c93);
            Deck.Add(c94);
            Deck.Add(c95);
            Deck.Add(c96);
            Deck.Add(c97);
            Deck.Add(c98);
            Deck.Add(c99);
            Deck.Add(c100);
            Deck.Add(c101);
            Deck.Add(c102);
            Deck.Add(c103);
            Deck.Add(c104);
            Deck.Add(c105);
            Deck.Add(c106);
            Deck.Add(c107);
            Shuffle(Deck);
        }
        
        public static GameLogic GetGameLogic()
        {
            if (Instance == null)
                Instance = new GameLogic();
            return Instance;
        }
        
        public Card GetTopCard()
        {
            Card card;
            card = Deck.ElementAt(0);
            Deck.RemoveAt(0);
            return card;
        }

        public List<Card> GetHand()
        {
            return myHand;
        }

        public Card GetTopCardField()
        {
            Card card = Field[Field.Count - 1];
            card.OnTheField=true;
            return card;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public void SetPlayers(List<Player> ps)
        {
            players = ps;
        }

        public void SetGameId(int gameid)
        {
            this.myGame = gameid;
        }

        public void SetMyName(string username)
        {
            this.me = username;
        }

        public void CurrentPlayerBuy(int n)
        {
            if (myHand.Count < 30) 
            {
                for (int i = 0; i < n; i++)
                {
                    myHand.Add(GetTopCard());
                }
            }
        }

        public void NextPlayerBuy(int n)
        {
            for(int i=0;i<n;i++)
                gs.playerCards[NextId()].AddCard(GetTopCard());

        }

        public void NextPlayer()
        {
            if (gs.reversed)
            {
                gs.currentPlayerId--;
                if (gs.currentPlayerId == -1)
                {
                    gs.currentPlayerId = gs.playerCards.Count - 1;
                }
            }
            else
            {
                gs.currentPlayerId++;
                if (gs.currentPlayerId == gs.playerCards.Count)
                {
                    gs.currentPlayerId = 0;
                }
            }
            IndexPlaying = gs.currentPlayerId;
        }
        
        public int NextId()
        {
            int id = gs.currentPlayerId;
            if(gs.reversed)
            {
                if (id == 0)
                {
                    id = gs.playerCards.Count - 1;
                }
                else
                {
                    id--;
                }
            }
            else
            {
                if (id == gs.playerCards.Count-1)
                {
                    id = 0;
                }
                else
                {
                    id++;
                }
            }
            return id;
        }

        public bool IsMyTurn()
        {
            if (onTurnPlayer == me)
                return true;
            else
                return false;
        }

        public void CurrentPlayerThrowsCard(Card card)
        {
            var itemToRemove = myHand.FirstOrDefault(u => u.Color == card.Color && u.Number == card.Number);
            myHand.Remove(itemToRemove);
            ThrowCardOnTheField(card);

            switch (card.Type)
            {
                case "SkippingCard": //Skiping card
                    {
                        NextPlayer();
                        break;
                    }
                case "ReversingCard": //Reverse card
                    {
                        ChangeReverse();
                        break;
                    }
                case "BuyingCard": //Buying card
                    {
                        NextPlayerBuy(card.Buy);
                        break;
                    }
                case "ChangingCard":
                    {
                        using (var form = new ColorForm())
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                SetFieldColor(form.ReturnColor);
                            }
                            else
                                SetFieldColor(0);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            NextPlayer();
        }

        private void ThrowCardOnTheField(Card card)
        {
            Field.Add(card);
        }

        public bool CanthrowCard(Card card)
        {
            bool ret = false;
            Card top = GetTopCardField();
            if(card.Color.Equals("4"))
            {
                ret = true;
            }
            else if(top.Color.Equals("4"))
            {
                if (top.Number.Equals("0"))
                {
                    if (card.Color.Equals(gs.fieldColor.ToString()))
                    {
                        ret = true;
                    }
                }
                else
                {
                    ret = true;
                }
            }
            else if (card.Number.Equals(top.Number) || card.Color.Equals(top.Color))
            {
                ret = true;
            }
            return ret;
        }

        public void ChangeReverse()
        {
            gs.reversed = !gs.reversed;
        }

        public void SetFieldColor(int col)
        {
            fieldColor = col;
            gs.fieldColor = col;
        }

        public GameStatus CreateStatus()
        {
            gs = new GameStatus();
            InicDeck();
            gs.currentPlayerId = IndexPlaying;
            gs.deck = Deck;
            gs.gameId = myGame;
            gs.maxPlayers = players.Count;

            gs.fieldCard = GetTopCard();
            gs.field.Add(gs.fieldCard);
            List<Card> tempCards = new List<Card>();
            for (int pi = 0; pi < players.Count; pi++)
            {
                for (int i = 0; i < StartingCards; i++) 
                {
                    tempCards.Add(GetTopCard());
                }
                gs.playerCards.Add(new PlayerCards(players[pi].username, tempCards.ToList()));
                if (players[pi].username == me)
                    myHand = tempCards.ToList();
                tempCards.Clear();
            }
            gs.special = false;
            gs.reversed = false;
            gs.winner = "";
            winnerName = "";
            return gs;
        }

        public void GetStatus(GameStatus gs1)
        {
            gs = gs1;
            
            if (gs.gameId == myGame)
            {
                if(!gs.winner.Equals(""))
                {
                    this.winnerName = gs.winner;
                }
                else
                {
                    foreach(PlayerCards cards in gs.playerCards)
                    {
                        if(cards.Name == this.me)
                        {
                            this.myHand = cards.Cards;
                        }
                    }
                    Deck = gs.deck;
                    Field = gs.field;
                    fieldColor = gs.fieldColor;
                    onTurnPlayer = gs.playerCards[gs.currentPlayerId].Name;
                    IndexPlaying = gs.currentPlayerId;
                }
            }
        }

        public GameStatus SendStatus()
        {
            gs.deck = Deck;
            gs.field = Field;
            gs.fieldCard = GetTopCardField();
            gs.fieldColor = fieldColor;
            return gs;
        }
    }
}