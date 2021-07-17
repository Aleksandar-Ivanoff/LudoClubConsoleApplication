using System;
using System.Collections.Generic;
using System.Text;

namespace Ludo_Club.GameValidationMethods
{
    public static class GameValidator
    {
       public static  string ValidateName(string name)
        {
            int nameParsed;
            char nameParsedChar;
            while (int.TryParse(name, out nameParsed) || char.TryParse(name,out nameParsedChar) || name == "")
            {
                Console.WriteLine("The name must be a text!");
                Console.Write("Write your Name Again:");

                name = Console.ReadLine();


            }

            return name;
       }

        public static int ValidateNumberOfPlayers()
        {
            int playerCount = 0;

            while (!int.TryParse(Console.ReadLine(), out playerCount) || !(playerCount >= 2 && playerCount <= 4))
            {
                Console.Write("Enter the number of players: ");
            }

            return playerCount;
        }

        public static string ValidateColor(string color)
        {
            while (color == "" || int.TryParse(color, out _))  //discarding out parameter
            {
                Console.Write(" Error! Enter a color again: ");
                color = Console.ReadLine();
            }

            return color;
        }
       
    }
}
