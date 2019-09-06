using System;

namespace Cards
{
    public class Card
    {
        public string number { get; set; }
        public string color { get; set; } // 0 red 1 orange 2 green 3 blue 4 wild
        public bool OnTheField { get; set; }
        public int buy { get; set; }

        public Card()
        {
            buy = 0;
        }

        public Card(string number, string sign) 
        {
            this.number = number;
            this.color = sign;
            OnTheField = false;
            buy = 0;
        }
        
        public string GetPath()
        {
            return "Pictures\\" + number + color + ".PNG";
        }

        /*public virtual void Action()
        {
            GameLogic.GetGameLogic().NextPlayer();
        }
        */
        public virtual String Special()
        {
            return "";
        }
    }
}