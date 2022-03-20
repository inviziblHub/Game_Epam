using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Convas
    {
        public int Width { get; set; }
        public int Height { get; set ; }
        public string[] Heder { get; set; }
        public string[][] ResultConva { get; set; }

        public Convas(int x, int y)
        {
            Width = x;
            Height = y;

            if (Width < 20 || Height < 30)
            {
                throw new ArgumentException("Размер игрового поля долже быть не менше чем 20х30 !");
            }

            Heder = new string[Width + 1];// { " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            ResultConva = new string[Height + 1][];
            Heder[0] = "";
            for (int i = 1; i < Width + 1; i++)
            {
                Heder[i] = i.ToString();
            }

            for (int i = 0; i < Height + 1; i++)
            {
                ResultConva[i] = new string[Width + 1];
                ResultConva[i][0] = (i + 1).ToString();

                for (int j = 1; j < Width + 1; j++)
                {
                    ResultConva[i][j] = "";
                }

            }
            ResultConva[Height] = Heder;
            Console.CursorVisible = false;
        }
        public void DrowConva()//, int w, int h )
        {

            var table = new Table();
            table.SetHeaders(Heder);
            
            for (int i = 0; i < Height + 1; i++)
            {
                table.AddRow(ResultConva[i]);
            }
            
            Console.WriteLine(table.ToString());
        }

    }
}
