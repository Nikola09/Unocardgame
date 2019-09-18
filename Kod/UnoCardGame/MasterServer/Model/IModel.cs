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
        Player returnPlayer(string username);
        Game returnGame(int id);
        IList<Game> returnGames();
        bool addPlayer(string username, string password);
        Game checkGameName(string name, string maxcount, string username);
        Game joinGame(string username, string name);
        void exitGame(string name, string username);
        void winCountInc(string name);
    }
}