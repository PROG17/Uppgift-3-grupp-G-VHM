using System;
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
            bool playing = true;
            bool validAnswer = true;

            do
            {
            Console.Clear();
                Game game = new Game();
                game.PlayGame();
                while (validAnswer)
                {
                    Console.WriteLine("Would you like to try again? (Yes/No)");

                    string yesNo = Console.ReadLine();

                    if (yesNo.ToLower() == "yes")
                        validAnswer = false;
                    if (yesNo.ToLower() == "no")
                    {
                        playing = false;
                        break;
                    }

                }
            } while (playing);
        }
    }
}
