using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleGame
{

    partial class GameLogics
    {
        private readonly Random randomeCube;
        public GameStatus Status { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WidthPoint { get; set; }
        public int HeightPoint { get; set; }
        public int StartInitialSteps { get; }
        public Player TurnPlayer { get; private set; }
        public Player TurnPlayer1 { get; private set; }
        public Player TurnPlayer2 { get; private set; }
        public Convas gameConva { get; private set; }
        public int ReturnStepsPlayerOne { get; private set; }
        public int ReturnStepsPlayerTwo { get; private set; }
        public int[] ReturnBildPoint { get; private set; }
        
        public event EventHandler<int[]> PlayedPlayer1;
        
        public event EventHandler<int[]> PlayedPlayer2;
        
        public event Action<Player> EndOfGame;

        public GameLogics(Player playerOne, Player playerTwo, Convas gameConvaRec)
        {                                                                                                                                                                                                                                       
            randomeCube = new Random();
            ReturnBildPoint = new int[2];
            gameConva = gameConvaRec;
            Status = GameStatus.NotSarted;
            StartInitialSteps = playerOne.CountStep;
            ReturnStepsPlayerOne = playerOne.CountStep;
            ReturnStepsPlayerTwo = playerTwo.CountStep;
            TurnPlayer1 = playerOne;
            TurnPlayer2 = playerTwo;
            TurnPlayer = TurnPlayer1;

        }

        public void StartGame()
        {
            if (Status == GameStatus.GameIsOver)
            {
                ReturnStepsPlayerOne = StartInitialSteps;
                ReturnStepsPlayerTwo = StartInitialSteps;
            }

            if (Status == GameStatus.InprogresGame)
            {
                throw new ArgumentException("Игра уже запущена !!!");
            }

            Status = GameStatus.InprogresGame;
            Console.Clear();
            gameConva.DrowConva();
            while (Status == GameStatus.InprogresGame)
            {
                bool flagNextGame = false;
                while (!flagNextGame)
                {
                    try
                    {
                        if (TurnPlayer.Name == Player.PlayerName.Player1)
                        {
                            RollTheDice(TurnPlayer);
                            PlayOnPlayer1();    // ---> вызов метода для 1 игрока <--- //
                            GameLogicsCalculation(TurnPlayer);

                        }
                        else
                        {
                            RollTheDice(TurnPlayer);
                            PlayOnPlayer2();    // ---> вызов метода для 2 игрока <--- //
                            GameLogicsCalculation(TurnPlayer);

                        }
                        gameConva.DrowConva();
                        flagNextGame = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                FireEndOfGameIfRequired();
                TurnPlayer = TurnPlayer.Name == Player.PlayerName.Player1 ? TurnPlayer2 : TurnPlayer1;
            }

        }

        private static void RollTheDice(Player turnPlayer)
        {
            Random rend = new Random();
            //Console.Clear();
            turnPlayer.Cube1 = rend.Next(1, 6);
            turnPlayer.Cube2 = rend.Next(1, 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Кубик 1 ширина {turnPlayer.Cube1} : Кубик 2 длинна {turnPlayer.Cube2}");
            Console.ResetColor();
        }

        public int EnderWidthPoint(int point)
        {

            if (point < 1 || point > gameConva.Height)
            {
                throw new ArgumentException("Точка не лежит на игровом поле !");
            }
            if (point.ToString() is null)
            {
                throw new ArgumentException("Вы нечего не ввели !");
            }

            return point;

        }
        public int EnderHeightPoint(int point)
        {
            
            if (point < 1 || point > gameConva.Width)
            {
                throw new ArgumentException("Точка не лежит на игровом поле !");
            }

            if (point.ToString() is null)
            {
                throw new ArgumentException("Вы нечего не ввели !");
            }
            

            return point;

        }
        private void FireEndOfGameIfRequired()
        {
            if (ReturnStepsPlayerOne == 0 || ReturnStepsPlayerTwo == 0)
            {
                Status = GameStatus.GameIsOver;
                
                if (EndOfGame != null)
                {
                    
                    EndOfGame(TurnPlayer1.RezultSquare > TurnPlayer2.RezultSquare ? TurnPlayer1 : TurnPlayer2);
                }
            }
        }

        private void PlayOnPlayer1()
        {
            if (PlayedPlayer1 != null)
            {
                PlayedPlayer1(this, ReturnBildPoint);
            }
            ReturnStepsPlayerOne--;
            TurnPlayer1.CountStep--;
        }
        private void PlayOnPlayer2()
        {
            if (PlayedPlayer2 != null)
            {
                PlayedPlayer2(this, ReturnBildPoint);
            }
            ReturnStepsPlayerTwo--;
            TurnPlayer2.CountStep--;
        }


        public void GameLogicsCalculation(Player gamer)
        {
            string gamerColorConva = gamer.Name == Player.PlayerName.Player1 ? "▒" : "#";
            bool flag1 = true;
           

            if ((ReturnBildPoint[0] <= 0 || ReturnBildPoint[1] <= 0) && ((ReturnBildPoint[0] + gamer.Cube1) > gameConva.Height + 1 || (ReturnBildPoint[1] + gamer.Cube2) >= gameConva.Width + 1))
            {
                throw new ArgumentException("Точка не лежит на игровом поле");
            }
            
            for (int i = ReturnBildPoint[0] - 1; i < ReturnBildPoint[0] + gamer.Cube1; i++)
            {

                for (int j = ReturnBildPoint[1]; j < ReturnBildPoint[1] + gamer.Cube2; j++)
                {
                    if (!string.IsNullOrEmpty(gameConva.ResultConva[i][j]))
                    {
                        flag1 = false;
                    }
                }

            }
            if (!flag1)
            {
                throw new ArgumentException("С данной позиции нельзя рисовать");
            }
            else
            {
                for (int i = ReturnBildPoint[0] - 1; i < ReturnBildPoint[0] + gamer.Cube1 - 1; i++)
                {

                    for (int j = ReturnBildPoint[1]; j < ReturnBildPoint[1] + gamer.Cube2; j++)
                    {
                        gameConva.ResultConva[i][j] = gamerColorConva;
                    }

                }
                //gamer.CountStep--;
                gamer.RezultSquare += gamer.Cube1 * gamer.Cube2;
                Console.WriteLine($"Осталось ходов {gamer.CountStep}");
            }

        }
    }
}
