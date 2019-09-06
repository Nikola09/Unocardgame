using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class SkipingCard : Card
    {
        public int buy { get; set; }

        public SkipingCard()
        {

        }

        public SkipingCard(string number,string color) : base(number,color)
        {

        }
        
        public override string Special()
        {
            return "SkipingCard";
        }
    }
}