using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Entities;

namespace MasterServer.Model
{
    public interface IModel
    {
        List<int> Cards { get; }
        List<int> returnCards(int x);
        Player returnPlayer(string username);
        IList<Game> returnGames();
        void addGame(Game x);
        bool addPlayer(string username, string password);
        Game checkGameName(string name, string maxcount, string usernames);
        Game joinGame(string username, string name);
        void exitGame(string name, string username);
        Game refresh(string name);
        void winCountInc(string name);
        Game returnGame(int id);
    }
}
