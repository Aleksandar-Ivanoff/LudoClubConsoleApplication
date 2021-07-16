using System;
using System.Collections.Generic;
using System.Text;

namespace Ludo_Club
{
    public static class Dice
    {
        public  static int Roll()
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }
    }
}
