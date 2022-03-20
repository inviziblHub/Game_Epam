using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    partial class Player
    {
        
        public PlayerName Name { get;  private set; }
        
        public int CountStep { get; set; }
        public int RezultSquare { get; set; }

        //public Player()
        //{
        //    CountStep = 20;
        //    RezultSquare = 0;
        //    Console.CursorVisible = false;
        //}
        public Player(int countStep = 20)
        {
            //if (countStep < 20)
            //    throw new ArgumentException("Количество ходов не может быть меньше 20 !");
            CountStep = countStep;
            RezultSquare = 0;
            Console.CursorVisible = false;
        }

    }
}
