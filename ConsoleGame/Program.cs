using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main()
        {
            int tempW = 0;
            int tempH = 0;
            int stepGame;
            Console.Write("Введите количество ходов (сейчас 20) = ");
            stepGame = Convert.ToInt32(Console.ReadLine());
            Player Pl = new Player(stepGame);
            Player P2 = new Player(stepGame);
            Player.PlayerName eneblePlayer = Player.PlayerName.Player1;
            Convas convas = new Convas();
            Console.Write("Введите размер поля Х = ");
            convas.Width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размер поля Y = ");
            convas.Height = Convert.ToInt32(Console.ReadLine());
            GameLogics game = new GameLogics();
            string[] hederStr = new string[convas.Width + 1];// { " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            string[][] convaStrStart = new string[convas.Height + 1][];
            hederStr[0] = "";
            for (int i = 1; i < convas.Width + 1; i++)
            {
                hederStr[i] = i.ToString();
            }
                for (int i = 0; i < convas.Height + 1; i++)
            {
                convaStrStart[i] = new string[convas.Width + 1];
                convaStrStart[i][0] = (i + 1).ToString();
                
                for (int j = 1; j < convas.Width + 1; j++)
                {
                    convaStrStart[i][j] = "";
                }

            }
            convaStrStart[convas.Height] = hederStr;


            int countStepEnded = 5;
            //WriteNormalTable(0,0);
            convas.DrowConva(hederStr, convaStrStart);//, 0, 0);
            //Console.Read();
            while(Pl.CountStep > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите координату Х");
                tempW = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите координату У");
                tempH = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                if (tempW <= 0 || tempH <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Точка не лежит на игровом поле");
                    Console.ResetColor();
                }
                Console.Clear();
                game.GameLogicsCalculation(tempW, tempH, convaStrStart, eneblePlayer);
                convas.DrowConva(hederStr, convaStrStart);
                Pl.CountStep--;
                eneblePlayer = eneblePlayer == Player.PlayerName.Player1 ? eneblePlayer = Player.PlayerName.Player2 : Player.PlayerName.Player1;
            }

            Console.Read();


            //convas.DrowConva();
            //Console.Read();
            //Console.WriteLine("Hello World!");

        }

        private static void WriteNormalTable(int w, int h)
        {
            Console.WriteLine("Normal table:");

            var table = new Table();
            string[] str = new string[] { " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            string[][] str1 = new string[21][];
            Random rend = new Random();
            int cube1 = rend.Next(1, 6);
            int cube2 = rend.Next(1, 6);
            table.SetHeaders(str);
                for (int i = 0; i < 21; i++)
                {
                    str1[i] = new string[21];

                    for (int j = 0; j < 21; j++)
                    {
                        str1[i][j] = "";
                    }

                }
            if (w == 0 && h == 0)
            {
                for (int i = 0; i < 21; i++)
                {
                    str1[i][0] = (i + 1).ToString();
                    //if (i % 2 == 0)
                    table.AddRow(str1[i]);
                    // else
                    //    table.AddRow(str1);
                }
            }
            else
            {
                for (int i = w; i < w + cube1; i++)
                {
                    
                    for (int j = h; j < h + cube2; j++)
                    {
                        str1[i][j] = "▒";
                    }

                }
                //str1[w][h] = "*";
                for (int i = 0; i < 21; i++)
                {
                    str1[i][0] = (i + 1).ToString();
                    //if (i % 2 == 0)
                    table.AddRow(str1[i]);
                    // else
                    //    table.AddRow(str1);
                }
            }
            Console.WriteLine($"W {cube1}, H {cube2}");
            Console.WriteLine(table.ToString());
        }

    }
}
