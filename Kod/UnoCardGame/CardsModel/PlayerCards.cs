using System;
using System.Collections.Generic;

namespace Cards
{
    public class PlayerCards
    {
        private String name;
        private List<Card> cards;

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<Card> Cards
        {
            get { return this.cards; }
            set { this.cards = value; }
        }

        public PlayerCards(String n,List<Card> cs)
        {
            this.name = n;
            this.cards = cs;
        }

        public void AddCard(Card c)
        {
            this.cards.Add(c);
        }

        public void RemoveCard(Card c)
        {
            this.cards.Remove(c);
        }

        public void ReplaceCards(List<Card> cs)
        {
            this.cards.Clear();
            this.cards = cs;
        }
    }
}