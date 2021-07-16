
using System;
using System.Collections.Generic;

namespace Ludo_Club
{
  using Enums;

    public class Player
    {
        public Player(string name)
        {
            this.Name = name;

            this.PlayerTokens = new List<Token>() {
                new Token { UniqueIdentifier = 1 },
                new Token { UniqueIdentifier = 2 },
                new Token { UniqueIdentifier = 3 },
                new Token { UniqueIdentifier = 4 },
            };
        }
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Token> PlayerTokens = null;

       
    }
}