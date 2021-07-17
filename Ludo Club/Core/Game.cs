namespace Ludo_Club
{
    using Ludo_Club.GameValidationMethods;
    using Ludo_Club.Models;
    using System;
    

    public class Game
    {
        
        private void StartScreen(GameService service,Path path)
        {
            Console.WriteLine("\n#### Welcome to Ludo Club ###\n");//First Screen

            Console.Write("\nEnter the number of players: ");
            int playerCount = 0;

            playerCount=GameValidator.ValidateNumberOfPlayers();

            Player[] players = new Player[playerCount];
            GameService.PickPlayers(playerCount, players);
            Console.Clear();

            Console.WriteLine("\n#### Welcome to Ludo Club ###\n");
            GameService.PickColor(playerCount, players);
            Console.Clear();

            Token token = new Token();

            
            service.MoveTokens(players,token,path);
        }
        
        public void StartGame(GameService service,Path path)
        {
            StartScreen(service,path);
            
        }
    }
}
