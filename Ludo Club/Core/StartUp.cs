using Ludo_Club.GameValidationMethods;
using Ludo_Club.Models;
using Ludo_Club.Rankings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ludo_Club
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            GameService gameService = new GameService();
            Path path = new Path();

            game.StartGame(gameService,path);





        } 
    }
}
