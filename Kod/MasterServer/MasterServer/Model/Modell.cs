using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using MasterServer.Entities;

namespace MasterServer.Model
{
    public class Modell : IModel
    {
        List<int> cards = new List<int>();

        List<int> IModel.Cards
        {
            get
            {
                return cards;
            }
        }

        public void addGame(Game x)
        {
            ISession s = DataLayer.GetSession();
            s.Save(x);
            s.Flush();
            s.Close();
        }

        public List<int> returnCards(int x)
        {
            throw new NotImplementedException();
        }

        public IList<Game> returnGames()
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Game");
            IList<Game> res = q.List<Game>();
            s.Close();
            return res;
        }

        public Player returnPlayer(string username)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", username);
            Player p = q.UniqueResult<Player>();
            s.Close();
            return p;
        }
    }
}
