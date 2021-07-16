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
            while (int.TryParse(name, out nameParsed) || char.TryParse(name,out nameParsedChar) || name == " ")
            {
                Console.WriteLine("The name must be a text!");
                Console.Write("Write your Name Again:");

                name = Console.ReadLine();


            }

            return name;
        }
    }
}
