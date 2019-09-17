using System;

namespace Cards
{
    public class Card
    {
        private string number;
        private string color; // 0 red 1 orange 2 green 3 blue 4 wild
        private bool onTheField;
        private int buy;
        private string type;

        #region get-set
        public string Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public bool OnTheField
        {
            get { return this.onTheField; }
            set { this.onTheField = value; }
        }

        public int Buy
        {
            get { return this.buy; }
            set { this.buy = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        #endregion

        public Card()
        {
            this.buy = 0;
        }

        public Card(string number, string sign) 
        {
            this.number = number;
            this.color = sign;
            this.onTheField = false;
            this.buy = 0;
            this.type = "";
        }
        
        public string GetPath()
        {
            return "Pictures\\" + this.number + this.color + ".PNG";
        }
    }
}