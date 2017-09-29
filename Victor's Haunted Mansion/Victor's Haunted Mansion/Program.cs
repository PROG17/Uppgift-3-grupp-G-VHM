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
            bool playing = true; //Spela spelet tills playing har angets som false

            do
            {
                Console.Clear();

                //Spela spelet
                Game game = new Game();
                game.PlayGame();

                //Fråga användaren om de vill spela spelet en gång till
                //Fortsätt loppa frågan tills yes eller no har angetts som svar
                while (true)
                {
                    Console.WriteLine("Would you like to play again? (Yes/No)");
                    string yesNo = Console.ReadLine().ToLower(); //Läs in svaret som små lower-case

                    if (yesNo == "yes")
                    {
                        break;
                    }

                    if (yesNo == "no")
                    {
                        playing = false; //Sluta spela spelet
                        break;
                    }
                }

            } while (playing);
        }
    }
}
