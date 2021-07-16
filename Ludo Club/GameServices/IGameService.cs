using System;
using System.Collections.Generic;
using System.Text;

namespace Ludo_Club.GameServices
{
    public interface IGameService
    {
        public  void PickColor(int player, Player[] players);
        public void PickPlayers(int playerCount, Player[] players);

        public void CheckTokenStatus(Token token, Square[] path, ICollection<Token> tokenFinished, int roll);
    }
}
