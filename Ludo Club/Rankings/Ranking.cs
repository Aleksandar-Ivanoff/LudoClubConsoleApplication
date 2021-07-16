using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ludo_Club.Rankings
{
   public class Ranking
    {
        private static List<Token> tokenRank;
        
        
        static  Ranking()
        {
            tokenRank = new List<Token>();
            readOnlyPlayersRanks = new ReadOnlyCollection<Token>(tokenRank);
        }
        public static void Add(Token token)
        {
            tokenRank.Add(token);
        }
        public static bool CheckTokenPlace(int number,Token token)
        {
           var res= token == tokenRank[number -1];

            return res;
        }

        public  static IReadOnlyCollection<Token> readOnlyPlayersRanks { get; private set; }
        
    }

    

   
}
