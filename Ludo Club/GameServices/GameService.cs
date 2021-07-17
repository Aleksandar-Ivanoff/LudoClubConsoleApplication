
namespace Ludo_Club
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.Enum;
    using Enums;
    using Ludo_Club.Models;
    using Ludo_Club.Rankings;
    using Ludo_Club.GameValidationMethods;
    using System.Text;

    public  class GameService
    {
        /// <summary>
        /// This function let you to pick a color.
        /// </summary>
        /// <param name="players"></param>
        /// 


      
        public static void PickColor(int p, Player[] players)
        {
            
            while (true)
            {
                if (p >= 2 && p <= 4)
                {
                    bool[] IsUsed = new bool[4];
                    for (int i = 0; i < p; i++)
                    {
                        string color;
                        Color enumType;

                        Console.Write($"Player {i + 1} color: ");
                        Console.WriteLine("\n Blue,\n Red,\n Green,\n Yellow");
                        Console.WriteLine();
                        Console.Write("Enter a color: ");

                        color = Console.ReadLine();

                        string validatedColor=GameValidator.ValidateColor(color);


                        while (!Enum.TryParse(validatedColor, true, out enumType))
                        {
                            if (!(validatedColor.ToLower() == "blue" || validatedColor.ToLower() == "red" || validatedColor.ToLower() == "green" || validatedColor.ToLower() == "yellow")) // red is not available
                            {
                                Console.WriteLine("Wrong color! Pick again");
                                Console.Write("Enter a color: ");
                                validatedColor = new string(Console.ReadLine());
                            }
                            else
                            {
                                break;
                            }
                        }

                        while (true)
                        {
                            if (enumType == Color.Blue)
                            {
                                if (IsUsed[0] == true)
                                {
                                    Console.WriteLine("This color is not availabel");
                                    Console.Write("Enter a color: ");
                                    validatedColor = Console.ReadLine();
                                    while (Enum.TryParse(validatedColor, true, out enumType) == false)
                                    {
                                        Console.WriteLine("Wrong color! Pick again");
                                        Console.Write("Enter a color: ");
                                        validatedColor = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    IsUsed[0] = true;
                                    break;
                                }

                            }
                            else if (enumType == Color.Red)
                            {
                                if (IsUsed[1] == true)
                                {
                                    Console.WriteLine("This color is not availabel");
                                    Console.Write("Enter a color: ");
                                    validatedColor = Console.ReadLine();
                                    while (Enum.TryParse(validatedColor, true, out enumType) == false)
                                    {
                                        Console.WriteLine("Wrong color! Pick again");
                                        Console.Write("Enter a color: ");
                                        validatedColor = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    IsUsed[1] = true;
                                    break;
                                }
                            }
                            else if (enumType == Color.Green)
                            {
                                if (IsUsed[2] == true)
                                {
                                    Console.WriteLine("This color is not availabel");
                                    Console.Write("Enter a color: ");
                                    validatedColor = Console.ReadLine();
                                    while (Enum.TryParse(validatedColor, true, out enumType) == false)
                                    {
                                        Console.WriteLine("Wrong color! Pick again");
                                        Console.Write("Enter a color: ");
                                        validatedColor = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    IsUsed[2] = true;
                                    break;
                                }
                            }
                            else if (enumType == Color.Yellow)
                            {
                                if (IsUsed[3] == true)
                                {
                                    Console.WriteLine("This color is not availabel");
                                    Console.Write("Enter a color: ");
                                    validatedColor = Console.ReadLine();
                                    while (Enum.TryParse(validatedColor, true, out enumType) == false)
                                    {
                                        Console.WriteLine("Wrong color! Pick again");
                                        Console.Write("Enter a color: ");
                                        validatedColor = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    IsUsed[3] = true;
                                    break;
                                }
                            }
                        }

                        var player = players[i];
                        player.Color = enumType;
                        player.PlayerTokens.ForEach(x => { x.Color = enumType; });//gtovo dai sh debugna pak da vidim davai mu sloncheto :D
                    }
                }

                break;
            }
        }

        /// <summary>
        /// This. function let you to pick number of the players.
        /// </summary>
        /// <param name="players"></param>
        public static void PickPlayers(int playerCount, Player[] players)
        {
            while (true)
            {
                if (playerCount >= 2 && playerCount <= 4)
                {
                    for (int i = 0; i < playerCount; i++)
                    {
                        Console.Write($"Player{i + 1} name: ");

                        string name = Console.ReadLine(); //Fix  Ex. -1 can be a name

                        var validatedName = GameValidator.ValidateName(name);

                        var player = new Player(name); // TO CHECK
                        player.Name = name;
                        players[i] = player;
                        players[i].PlayerTokens.ForEach(x => x.Name = player.Name);
                    }

                    break;
                }
                else if (playerCount < 2)
                {
                    Console.WriteLine("Players must be minimum 2");
                    int.TryParse(Console.ReadLine(), out playerCount);
                }
                else if (playerCount > 4)
                {
                    Console.WriteLine("Players must be maximum 4");
                    int.TryParse(Console.ReadLine(), out playerCount);
                }
            }
        }

        
        public static void CheckTokenStatus(Token token,Square[] path,ICollection<Token> tokenFinished,int roll)
        {
            Square pathPosition = null;

  
                if (token.Status == Status.Home)
                {
                    token.Status = Status.InGame;
                    token.CurrentPosition = 0;
                    path[0].squareTokens.Add(token);

                }
                else if (token.Status == Status.InGame)
                {
                    if (token.CurrentPosition + roll > 31)
                    {
                        token.Status = Status.Finished;
                        token.CurrentPosition = null;

                        if (tokenFinished.Count == 4)
                        {
                            Ranking.Add(token);
                        }
                        

                    }
                    else if (path[(int)token.CurrentPosition + roll] == null)
                    {
                        pathPosition = MoveToNextPath(path[(int)token.CurrentPosition + roll]);
                    }

                    pathPosition.squareTokens.Add(token);
                    token.CurrentPosition += roll;
    
                }
                else
                {
                Console.WriteLine("The token you choosed is Finished! Please pick another!");
                }
            
        }

        public static Square MoveToNextPath(Square pathPosition)
        {
            return pathPosition = new Square();
        }

        public static void ChooseToken(Token token,Player player,Square[] squares,List<Token>tokenFinished,int roll,Path path)
        {
            int chooseToken =0;

            while (true)
            {
                Console.Write("Pick a Token : ");
                chooseToken = int.Parse(Console.ReadLine());

                token = player.PlayerTokens.Where(t => t.UniqueIdentifier == chooseToken).FirstOrDefault();

                if (token.Status == Status.Home)
                {
                    squares[0].squareTokens.Add(token);
                    token.Status = Status.InGame;
                    token.CurrentPosition = 0;
                    break;
                }
                else if (token.Status == Status.InGame)
                {
                    if ((int)token.CurrentPosition + roll > 31)
                    {
                        tokenFinished.Add(token);
                        token.Status = Status.Finished;
                        token.CurrentPosition = null;

                        if (tokenFinished.Count == 4)
                        {
                            Ranking.Add(token);
                            break;
                        }
                        Console.WriteLine("Your token is finished!/n");
                        Console.WriteLine("It's your turn again!");
                        continue;
                    }
                    if (squares[(int)token.CurrentPosition + roll] == null)
                    {
                        squares[(int)token.CurrentPosition + roll] = new Square();
                    }

                    squares[(int)token.CurrentPosition + roll].squareTokens.Add(token);
                    token.CurrentPosition = token.CurrentPosition + roll;
                    BlueTokenAttack(token,path);
                    break;
                }

            }
        }


        public static void BlueTokenAttack(Token token,Path path)
        {
            if (path.redPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.redPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.greenPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.greenPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.yellowPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.yellowPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
        }
        public static void RedTokenAttack(Token token,Path path)
        {
            if (path.bluePlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.bluePlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.greenPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.greenPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.yellowPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.yellowPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
        }
        public static void GreenTokenAttack(Token token,Path path)
        {
            if (path.bluePlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.bluePlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.redPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.redPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.yellowPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.yellowPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
        }
        public static void YellowTokenAttack(Token token,Path path)
        {
            if (path.bluePlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.bluePlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.redPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.redPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
            else if (path.greenPlayerPath[(int)token.CurrentPosition] != null)
            {
                foreach (var item in path.greenPlayerPath[(int)token.CurrentPosition].squareTokens)
                {
                    if (item.CurrentPosition == (int)token.CurrentPosition)
                    {
                        item.CurrentPosition = null;
                        item.Status = Status.Home;
                        break;
                    }
                }
            }
        }


        public static void  MoveBlueToken(int roll, Path path,Token token,int chooseToken,Player player,ICollection<Token> tokenFinished)
        {
            chooseToken = 0;
            if (roll == 6)
            {
                ShowPlayerTokens(player);
                if (path.bluePlayerPath[0] == null)
                {
                    path.bluePlayerPath[0] = new Square();
                }
                //SHOW PLAYER TOKENS!!!!!! TO DOO

                Console.Write($"{player.Name} - Pick a Token : ");
                chooseToken = int.Parse(Console.ReadLine());
                while (chooseToken > 4)
                {
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());
                }
                token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();

                CheckTokenStatus(token, path.bluePlayerPath, tokenFinished,roll);
                //check if token is null (do some logic)
            }
            else if (player.PlayerTokens.Any(x => x.Status == Status.InGame))
            {
                
                while (true)
                {
                    ShowPlayerTokens(player);
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());

                    if ((chooseToken >= 1 && chooseToken <= 4))
                    {
                        token = player.PlayerTokens.Where(t => t.UniqueIdentifier == chooseToken).FirstOrDefault();

                        if (token.Status != Status.InGame)
                        {
                            Console.WriteLine("The token you choosed is not InGame!!!!");
                            continue;
                        }
                        
                        
                        break;
                    }

                }
         
                if ((int)token.CurrentPosition + roll > 31)
                {
                    token.Status = Status.Finished;
                    token.CurrentPosition = null;
                    tokenFinished.Add(token);
                    

                    if (tokenFinished.Count == 4)
                    {
                        Ranking.Add(token);
                    }
                    return;
                }
                if (path.bluePlayerPath[(int)token.CurrentPosition + roll] == null)
                {
                    path.bluePlayerPath[(int)token.CurrentPosition + roll] = new Square();
                }

                path.bluePlayerPath[(int)token.CurrentPosition + roll].squareTokens.Add(token);
                token.CurrentPosition = token.CurrentPosition + roll;
                BlueTokenAttack(token,path);
            }
           
        }

        public static void MoveRedToken(int roll, Path path, Token token, int chooseToken, Player player, ICollection<Token> tokenFinished)
        {
            chooseToken = 0;
            if (roll == 6)
            {
                ShowPlayerTokens(player);
                if (path.redPlayerPath[0] == null)
                {
                    path.redPlayerPath[0] = new Square();
                }
                //SHOW PLAYER TOKENS!!!!!! TO DOO

                

                Console.Write($"{player.Name} - Pick a Token : ");
                chooseToken = int.Parse(Console.ReadLine());
                while (chooseToken > 4)
                {
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());
                }
                token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();

                CheckTokenStatus(token, path.redPlayerPath, tokenFinished, roll);
                //check if token is null (do some logic)
            }
            else if (player.PlayerTokens.Any(x => x.Status == Status.InGame))
            {

                while (true)
                {
                    ShowPlayerTokens(player);
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());

                    if ((chooseToken >= 1 && chooseToken <= 4))
                    {
                        token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();
                        if (token.Status != Status.InGame)
                        {
                            Console.WriteLine("The token you choosed is not InGame!!!!");
                            continue;
                        }

                        
                        break;
                    }

                }

                if ((int)token.CurrentPosition + roll > 31)
                {
                    token.Status = Status.Finished;
                    token.CurrentPosition = null;
                    tokenFinished.Add(token);


                    if (tokenFinished.Count == 4)
                    {
                        Ranking.Add(token);
                    }
                    return;
                }
                if (path.redPlayerPath[(int)token.CurrentPosition + roll] == null)
                {
                    path.redPlayerPath[(int)token.CurrentPosition + roll] = new Square();
                }

                path.redPlayerPath[(int)token.CurrentPosition + roll].squareTokens.Add(token);
                token.CurrentPosition = token.CurrentPosition + roll;
                RedTokenAttack(token,path);
            }
            
        }

        public static void MoveGreenToken(int roll, Path path, Token token, int chooseToken, Player player, ICollection<Token> tokenFinished)
        {
            chooseToken = 0;
            if (roll == 6)
            {
                ShowPlayerTokens(player);
                if (path.greenPlayerPath[0] == null)
                {
                    path.greenPlayerPath[0] = new Square();
                }
                //SHOW PLAYER TOKENS!!!!!! TO DOO

                Console.Write($"{player.Name} - Pick a Token : ");
                chooseToken = int.Parse(Console.ReadLine());
                while (chooseToken > 4)
                {
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());
                }
                token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();

                
                CheckTokenStatus(token, path.greenPlayerPath, tokenFinished, roll);
                //check if token is null (do some logic)
            }
            else if (player.PlayerTokens.Any(x => x.Status == Status.InGame))
            {

                while (true)
                {
                    ShowPlayerTokens(player);
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());

                    if ((chooseToken >= 1 && chooseToken <= 4))
                    {
                        token = player.PlayerTokens.Where(t => t.UniqueIdentifier == chooseToken).FirstOrDefault();
                        if (token.Status != Status.InGame)
                        {
                            Console.WriteLine("The token you choosed is not InGame!!!!");
                            continue;
                        }

                       
                        break;
                    }

                }

                if ((int)token.CurrentPosition + roll > 31)
                {
                    token.Status = Status.Finished;
                    token.CurrentPosition = null;
                    tokenFinished.Add(token);


                    if (tokenFinished.Count == 4)
                    {
                        Ranking.Add(token);
                    }
                    return;
                }
                if (path.greenPlayerPath[(int)token.CurrentPosition + roll] == null)
                {
                    path.greenPlayerPath[(int)token.CurrentPosition + roll] = new Square();
                }

                path.greenPlayerPath[(int)token.CurrentPosition + roll].squareTokens.Add(token);
                token.CurrentPosition = token.CurrentPosition + roll;
                GreenTokenAttack(token,path);
            }

        }
        public static void MoveYellowToken(int roll, Path path, Token token, int chooseToken, Player player, ICollection<Token> tokenFinished)
        {
            chooseToken = 0;
            if (roll == 6)
            {
                ShowPlayerTokens(player);

                if (path.yellowPlayerPath[0] == null)
                {
                    path.yellowPlayerPath[0] = new Square();
                }
                //SHOW PLAYER TOKENS!!!!!! TO DOO

                Console.Write($"\n{player.Name} - Pick a Token : ");
                chooseToken = int.Parse(Console.ReadLine());
                while (chooseToken > 4)
                {
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());
                }
                token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();

                CheckTokenStatus(token, path.yellowPlayerPath, tokenFinished, roll);
                //check if token is null (do some logic)
            }
            else if (player.PlayerTokens.Any(x => x.Status == Status.InGame))
            {

                while (true)
                {

                    ShowPlayerTokens(player);
                    
                    Console.Write("Pick a Token : ");
                    chooseToken = int.Parse(Console.ReadLine());

                    if ((chooseToken >= 1 && chooseToken <= 4))
                    {
                        token = player.PlayerTokens.Where(x => x.UniqueIdentifier == chooseToken).FirstOrDefault();

                        if (token.Status != Status.InGame)
                        {
                            Console.WriteLine("The token you choosed is not InGame!!!!");
                            continue;
                        }

                       
                        break;
                    }

                }

                if ((int)token.CurrentPosition + roll > 31)
                {
                    token.Status = Status.Finished;
                    token.CurrentPosition = null;
                    tokenFinished.Add(token);


                    if (tokenFinished.Count == 4)
                    {
                        Ranking.Add(token);
                    }
                    return;
                }
                if (path.yellowPlayerPath[(int)token.CurrentPosition + roll] == null)
                {
                    path.yellowPlayerPath[(int)token.CurrentPosition + roll] = new Square();
                }

                path.yellowPlayerPath[(int)token.CurrentPosition + roll].squareTokens.Add(token);
                token.CurrentPosition = token.CurrentPosition + roll;
                YellowTokenAttack(token,path);
            }

        }

        public void MoveTokens(Player[] players,Token token,Path path)
        {
            int roll = 0;
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
                    if (token.blueFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (token.redFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (token.greenFinished.Count == 4)
                    {
                        continue;
                    }
                    else if (token.yellowFinished.Count == 4)
                    {
                        continue;
                    }

                    roll = Dice.Roll();

                    Console.WriteLine($"Player{i + 1} rolled : {roll}");

                    if (players[i].Color == Color.Blue)
                    {
                        Console.Write($"Player {players[i].Name}, picks a token : "); //TO CHECK
                        GameService.MoveBlueToken(roll, path, token, chooseToken, players[i], token.blueFinished);

                    }

                    else if (players[i].Color == Color.Red)
                    {
                        GameService.MoveRedToken(roll, path, token, chooseToken, players[i], token.redFinished);
                    }

                    else if (players[i].Color == Color.Green)
                    {
                        GameService.MoveBlueToken(roll, path, token, chooseToken, players[i], token.greenFinished);
                    }

                    else if (players[i].Color == Color.Yellow)
                    {
                        GameService.MoveYellowToken(roll, path, token, chooseToken, players[i], token.yellowFinished);
                    }
                }
            }
            Console.Clear();

            Console.WriteLine("\n#### Welcome to Ludo Club ####\n");
            Console.WriteLine("\n#### Ranks ####\n");
            foreach (var t in Ranking.readOnlyPlayersRanks)
            {
                if (Ranking.CheckTokenPlace(1, t))
                {
                    Console.WriteLine($"1.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(2, t))
                {
                    Console.WriteLine($"2.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(3, t))
                {
                    Console.WriteLine($"3.{t.Name}");
                }
                else if (Ranking.CheckTokenPlace(4, t))
                {
                    Console.WriteLine($"4.{t.Name}");
                }

            }
        }


        private static void ShowPlayerTokens(Player player)
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($"{player.Name} tokens:");
            foreach (var token in player.PlayerTokens)
            {

                sb.AppendLine($"Token({token.UniqueIdentifier}) - {token.Status} status");
                
            }

            Console.WriteLine(sb.ToString());
        }
    }

}
