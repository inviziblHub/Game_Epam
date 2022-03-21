using System;


namespace ConsoleGame
{
    class Program
    {
        static void Main()
        {

            int stepGame = 20;
            int xConva = 20;
            int yConva = 30;

            GameLogics game;

            Convas convas;

            EnteringSizeConva(ref xConva, ref yConva);
            convas = new Convas(xConva, yConva);
            convas.Width = xConva;
            convas.Height = yConva;
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("Введите количество ходов (миниммум 20) = ");
            //stepGame = Convert.ToInt32(Console.ReadLine());
            bool enteryStartStep = false;
            while (!enteryStartStep)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите количество ходов (миниммум 20) = ");
                if (int.TryParse(Console.ReadLine(), out int startStepGame))
                {
                    try
                    {
                        //stepGame = startStepGame
                        if (startStepGame < 20)
                            throw new ArgumentException("Количество ходов не может быть меньше 20 !"); ;
                        stepGame = startStepGame;
                        enteryStartStep = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.ResetColor();
            }
            Player player1 = new Player(stepGame);
            Player player2 = new Player(stepGame);
            player1.Name = Player.PlayerName.Player1;
            player2.Name = Player.PlayerName.Player2;
            game = new GameLogics(player1, player2, convas);
            game.Width = convas.Width;
            game.Height = convas.Height;
            game.PlayedPlayer1 += Game_PlayedPlayer1;
            game.PlayedPlayer2 += Game_PlayedPlayer2;
            game.EndOfGame += Game_EndOfGame;

            game.StartGame();
            Console.Read();
        }

        private static void EnteringSizeConva(ref int xConva, ref int yConva)
        {
            bool entersizeCorrectly = false;
            while (!entersizeCorrectly)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите размер поля Х = ");
                    if (int.TryParse(Console.ReadLine(), out int sizeConvaX))
                    {
                        try
                        {
                            xConva = sizeConvaX;
                            if (sizeConvaX < 20)
                            {
                                throw new ArgumentException("Размер игрового поля долже быть не менше чем 20х30 !");
                            }
                            //entersizeCorrectly = true;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Размер игрового поля долже быть не менше чем 20х30 !");

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Write("Введите размер поля Y = ");
                if (int.TryParse(Console.ReadLine(), out int sizeConvaY))
                {
                    try
                    {

                        yConva = sizeConvaY;
                        if (sizeConvaY < 30)
                        {
                            throw new ArgumentException("Размер игрового поля долже быть не менше чем 20х30 !");
                        }
                        entersizeCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.ResetColor();
            }
        }

        private static void Game_EndOfGame(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Победил: {player.Name} занятая площать {player.RezultSquare}");
            Console.ResetColor();
        }

        private static void Game_PlayedPlayer2(object sender, int[] returnSteps)
        {
            EntaringInsertPoint(sender, returnSteps);
        }

        private static void Game_PlayedPlayer1(object sender, int[] returnSteps)
        {
            EntaringInsertPoint(sender, returnSteps);
        }

        private static void EntaringInsertPoint(object sender, int[] returnSteps)
        {
            bool enterCorrectly = false;
            while (!enterCorrectly)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите координату Y");
                if (int.TryParse(Console.ReadLine(), out int pointsX))
                {
                    var game = (GameLogics)sender;
                    try
                    {
                        returnSteps[0] = game.EnderWidthPoint(pointsX);
                        enterCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("Введите координату X");

                if (int.TryParse(Console.ReadLine(), out int pointsY))
                {
                    var game = (GameLogics)sender;
                    try
                    {

                        returnSteps[1] = game.EnderHeightPoint(pointsY);

                        enterCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}
