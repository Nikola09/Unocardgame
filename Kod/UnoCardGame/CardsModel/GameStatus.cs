using System.Collections.Generic;

namespace Cards
{
    public class GameStatus
    {
        public int gameId { get; set; }
        public List<PlayerCards> playerCards { get; set; } = new List<PlayerCards>();
        public string winner { get; set; }
        public List<Card> deck { get; set; } = new List<Card>();
        public List<Card> field { get; set; } = new List<Card>();
        public Card fieldCard { get; set; }
        public int fieldColor { get; set; }
        public bool reversed { get; set; }
        public int currentPlayerId { get; set; }
        public int maxPlayers { get; set; }
        public bool special { get; set; }
    }
}
