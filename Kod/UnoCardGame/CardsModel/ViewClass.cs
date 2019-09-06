using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Entities;

namespace Cards
{
    public class ViewClass
    {
        public virtual Player player { get; set; }
        public virtual IList<Game> games { get; set; }

        public ViewClass()
        {
            games = new List<Game>();
        }
    }
}
