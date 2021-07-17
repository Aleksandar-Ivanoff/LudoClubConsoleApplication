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

        public List<Token> blueFinished;
        public List<Token> redFinished;
        public List<Token> greenFinished;
        public List<Token> yellowFinished;

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

       

        
       
    }
}
