using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{

    partial class GameLogics
    {
        public GameStatus Status { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public void GameLogicsCalculation(int widthPoint, int heightPoint, string[][] gameRezultConva, Player.PlayerName gamer)
        {
            string gamerColorConva = "";
            bool flag1 = true;
            gamerColorConva = gamer == Player.PlayerName.Player1 ? "▒" : "#";
            Random rend = new Random();
            int cube1 = rend.Next(1, 6);
            int cube2 = rend.Next(1, 6);

            if (widthPoint <= 0 || heightPoint <= 0)
            {
                throw new ArgumentException("Точка не лежит на игровом поле");
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Кубик 1 {cube1} : Кубик 2 {cube2}");
            Console.ResetColor();
            for (int i = heightPoint - 1; i < heightPoint + cube1; i++)
            {

                for (int j = widthPoint; j < widthPoint + cube2; j++)
                {
                    if (!string.IsNullOrEmpty(gameRezultConva[i][j]))
                    {
                        flag1 = false;
                    }
                }

            }
            if (!flag1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("С данной позиции нельзя рисовать");
                Console.ResetColor();
                gamer = gamer == Player.PlayerName.Player1 ? gamer = Player.PlayerName.Player2 : Player.PlayerName.Player1;
            }
            else
            {
                for (int i = heightPoint - 1; i < heightPoint + cube1; i++)
                {

                    for (int j = widthPoint; j < widthPoint + cube2; j++)
                    {
                        gameRezultConva[i][j] = gamerColorConva;
                    }

                }
            }
        }
    }
}
