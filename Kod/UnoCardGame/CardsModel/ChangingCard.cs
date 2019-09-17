using CardsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public class ChangingCard : Card
    {

        public ChangingCard(string number,string color) : base(number,color)
        {
            base.Type = "ChangingCard";
        }
    }
}