﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Victors Haunted Mansion";
            Game game = new Game();
            game.PlayGame();
        }
    }
}
