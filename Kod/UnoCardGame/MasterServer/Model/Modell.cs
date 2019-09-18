using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MasterServer;
using Cards.Entities;

namespace MasterServer.Model
{
    public class Modell : IModel
    {

        public Player returnPlayer(string username)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", username);
            Player p = q.UniqueResult<Player>();
            s.Close();
            return p;
        }

        public Game returnGame(int id)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Game g where g.id=:id");
            q.SetParameter("id", id);
            Game g = q.UniqueResult<Game>();
            return g;
        }

        public IList<Game> returnGames()
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Game");
            IList<Game> res = q.List<Game>();
            s.Close();
            return res;
        }

        public bool addPlayer(string username, string password)
        {
            ISession s = DataLayer.GetSession();

            Cards.Entities.Player p = new Cards.Entities.Player();
            p.username = username;
            p.password = password;
            p.winCount = 0;

            string name = username;
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", name);
            Player pt = q.UniqueResult<Player>();
            if (pt == null)
            {
                s.Save(p);
                s.Flush();

                s.Close();
                return true;
            }
            else
            {
                s.Close();
                return false;
            }

        }

        public Game checkGameName(string name, string maxcount, string username)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", username);
            Player p = q.UniqueResult<Player>();
            
            string n = name;
            IQuery q2 = s.CreateQuery("from Game g where g.name=:name");
            q2.SetString("name", n);
            Game g = q2.UniqueResult<Game>();
            if (g != null)
            {
                g = null;
            }
            else
            {
                Game gNew = new Game();
                gNew.name = name;
                gNew.maxPlayerCount = Int32.Parse(maxcount);
                gNew.players.Add(p);
                gNew.currentPlayerCount = 1;
                gNew.status = 0;
                p.game = gNew;
                s.Update(p);
                s.Save(gNew);
                s.Flush();
                g = gNew;
            }

            s.Close();
            return g;
        }

        public void exitGame(string name, string username)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", username);
            Player p = q.UniqueResult<Player>();
            
            q = s.CreateQuery("from Game g where g.name=:name");
            q.SetString("name", name);
            Game g = q.UniqueResult<Game>();
            g.players.Remove(p);
            g.currentPlayerCount--;
            p.game = null;
            s.Update(p);
            if (g.currentPlayerCount == 0)
            {
                s.Delete(g);
                s.Flush();
            }
            else
            {
                s.Update(g);
                s.Flush();
            }
            s.Close();
        }

        public Game joinGame(string username, string name)
        {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from Player p where p.username=:username");
                q.SetString("username", username);
                Player p = q.UniqueResult<Player>();
                
            
                IQuery q2 = s.CreateQuery("from Game g where g.name=:name");
                q2.SetString("name", name);
                Game g = q2.UniqueResult<Game>();

                if (g != null && g.status == 0)
                {
                    g.players.Add(p);
                    g.currentPlayerCount++;
                    if(g.currentPlayerCount == g.maxPlayerCount)
                    {
                        g.status = 1;
                    }
                    p.game = g;
                    s.Update(p);
                    s.Update(g);
                    s.Flush();
                }
                else
                {
                    g = null;
                }
                s.Close();
                
                return g;
        }   

        public void winCountInc(string name)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Player p where p.username=:username");
            q.SetString("username", name);
            Player p = q.UniqueResult<Player>();
            p.winCount++;
            s.Update(p);
            s.Flush();
            s.Close();
        }
    }
}