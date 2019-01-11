using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterServer.Entities;

namespace MasterServer.Model
{
    public interface IModel
    {
        List<int> Cards { get; }
        List<int> returnCards(int x);
        Player returnPlayer(string username);
        IList<Game> returnGames();
        void addGame(Game x);
    }
}
