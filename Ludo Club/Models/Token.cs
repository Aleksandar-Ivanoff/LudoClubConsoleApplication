namespace Ludo_Club
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Ludo_Club.Models;
    using Ludo_Club.Rankings;
 
    public class Token
    {

        private readonly Path path;

        List<Token> blueFinished;
        List<Token> redFinished;
        List<Token> greenFinished;
        List<Token> yellowFinished;

        public Token()
        {
            this.path = new Path();


            this.redFinished= new List<Token>(4);
            this.blueFinished= new List<Token>(4);
            this.greenFinished= new List<Token>(4);
            this.yellowFinished= new  List<Token>(4);
        }

        

        public int UniqueIdentifier { get; set; } 
        public string Name { get; set; }
        public Color Color { get; set; }
        public int? CurrentPosition { get; set; } = null;
        public Status Status { get; set; }
        public List<Token> tokens = new List<Token>();

        public void MoveTokens(Player[] players)
        {
            Token token = null;

            int roll =0;
            int chooseToken = 0;
            
            Console.WriteLine("\n#### Welcome to Ludo Club ####\n");
            while (true)
            {
                if (Ranking.readOnlyPlayersRanks.Count == players.Length)
                {
                    break;
                }
                for (int i = 0; i < players.Length; i++)
                {
                    if (blueFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (redFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (greenFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (yellowFinished.Count == 4)
                    {
                        continue;
                    }
                    
                    roll = Dice.Roll();
                    
                    Console.WriteLine($"Player{i + 1} rolled : {roll}");

                    if (players[i].Color == Color.Blue)
                    {
                        Console.Write($"Player {players[i + 1]}, picks a token : ");
                        GameService.MoveBlueToken(roll, path, token, chooseToken, players[i],blueFinished);
                      
                    }

                    else if (players[i].Color == Color.Red)
                    {
                        GameService.MoveRedToken(roll, path, token, chooseToken, players[i], redFinished);
                    }

                    else if (players[i].Color == Color.Green)
                    {
                        GameService.MoveBlueToken(roll, path, token, chooseToken, players[i], greenFinished);
                    }

                    else if (players[i].Color == Color.Yellow)
                    {
                        GameService.MoveYellowToken(roll, path, token, chooseToken, players[i], yellowFinished);
                    }
                }
            }
            Console.Clear();

            Console.WriteLine("\n#### Welcome to Ludo Club ####\n");
            Console.WriteLine("\n#### Ranks ####\n");
            foreach (var t in Ranking.readOnlyPlayersRanks) 
            {
                if (Ranking.CheckTokenPlace(1,t))
                {
                    Console.WriteLine($"1.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(2,t))
                {
                    Console.WriteLine($"2.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(3,t))
                {
                    Console.WriteLine($"3.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(4,t))
                {
                    Console.WriteLine($"4.{t.Name}");
                }

            }
        }

        
       
    }
}
