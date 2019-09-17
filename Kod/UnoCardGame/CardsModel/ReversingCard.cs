using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class ReversingCard : Card
    {

        public ReversingCard(string number, string color)
            : base(number, color)
        {
            base.Type = "ReversingCard";
        }
    }
}