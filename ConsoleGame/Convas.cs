using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Convas
    {
        public int Width { get; set; }
        public int Height { get; set; }


        public Convas()
        {
            Width = 20;
            Height = 30;
            Console.CursorVisible = false;
        }
        public void DrowConva(string[] heder, string[][] rezultConva)//, int w, int h )
        {

            var table = new Table();
            table.SetHeaders(heder);
            
            for (int i = 0; i < Height + 1; i++)
            {
                table.AddRow(rezultConva[i]);
            }
            
            Console.WriteLine(table.ToString());
        }

    }
}
