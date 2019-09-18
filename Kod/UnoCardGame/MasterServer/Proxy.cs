using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MasterServer;
using Cards.Entities;
using MasterServer.Model;

namespace MasterServer
{
    class Proxy : Modell
    {
        private IModel model;

        public Proxy()
        {
            model = new Modell();
        }

        public Player ReturnPlayer(string username)
        {
            return model.returnPlayer(username);
        }

        public Game ReturnGame(int id)
        {
            return model.returnGame(id);
        }

        public IList<Game> ReturnGames()
        {
            return model.returnGames();
        }

        public bool AddPlayer(string username, string password)
        {
            return model.addPlayer(username, password);
        }

        public Game CheckGameName(string name, string maxcount, string username)
        {
            return model.checkGameName(name, maxcount, username);
        }

        public Game JoinGame(string username, string name)
        {
            return model.joinGame(username, name);
        }

        public void ExitGame(string name, string username)
        {
            model.exitGame(name, username);
        }

        public void WinCountInc(string username)
        {
            model.winCountInc(username);
        }
    }
}