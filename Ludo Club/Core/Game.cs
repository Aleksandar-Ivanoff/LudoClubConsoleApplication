using Ludo_Club.GameServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludo_Club
{
    public class Game
    {
        private void StartScreen()
        {
            Console.WriteLine("\n#### Welcome to Ludo Club ###\n");//First Screen

            Console.Write("\nEnter the number of players: ");
            int playerCount = 0;

            while (!int.TryParse(Console.ReadLine(), out playerCount) || !(playerCount >= 2 && playerCount <= 4))
            {
                Console.Write("Enter the number of players: ");
            }

            Player[] players = new Player[playerCount];
            GameService.PickPlayers(playerCount, players);
            Console.Clear();

            Console.WriteLine("\n#### Welcome to Ludo Club ###\n");
            GameService.PickColor(playerCount, players);
            Console.Clear();

            

            Token token = new Token();
            token.MoveTokens(players);
        }
        
        public void StartGame()
        {
            StartScreen();
            
        }
    }
}
