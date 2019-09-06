using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Entities
{
    public class Game
    {
        public virtual int id { get; set; }
        public virtual int maxPlayerCount { get; set; }
        public virtual int currentPlayerCount { get; set; }
        public virtual string name { get; set; }
        public virtual int status { get; set; }
        public virtual IList<Player> players { get; set; }
        public Game()
        {
            players = new List<Player>();
        }
    }
}
