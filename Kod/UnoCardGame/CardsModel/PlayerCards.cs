using System;
using System.Collections.Generic;

namespace Cards
{
    public class PlayerCards
    {
        public String name { get; set; }
        public List<Card> cards { get; set; }
        public PlayerCards(String n,List<Card> cs)
        {
            name = n;
            cards = cs;

        }
        public void AddCard(Card c)
        {
            cards.Add(c);

        }
        public void RemoveCard(Card c)
        {
            cards.Remove(c);

        }
        public void ReplaceCards(List<Card> cs)
        {
            cards.Clear();
            cards = cs;
        }
    }

    
}
