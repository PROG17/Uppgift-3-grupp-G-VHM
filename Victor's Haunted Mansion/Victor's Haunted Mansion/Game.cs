﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Game
    {
        private Room[] rooms = new Room[11];
        private Player player;

        public Game()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" 
 _    ___      __            _          __  __                  __           __   __  ___                 _           
| |  / (_)____/ /_____  ____( )_____   / / / /___ ___  ______  / /____  ____/ /  /  |/  /___ _____  _____(_)___  ____ 
| | / / / ___/ __/ __ \/ ___/// ___/  / /_/ / __ `/ / / / __ \/ __/ _ \/ __  /  / /|_/ / __ `/ __ \/ ___/ / __ \/ __ \
| |/ / / /__/ /_/ /_/ / /    (__  )  / __  / /_/ / /_/ / / / / /_/  __/ /_/ /  / /  / / /_/ / / / (__  ) / /_/ / / / /
|___/_/\___/\__/\____/_/    /____/  /_/ /_/\__,_/\__,_/_/ /_/\__/\___/\__,_/  /_/  /_/\__,_/_/ /_/____/_/\____/_/ /_/");

            Console.WriteLine("\nEnter player name: ");
            string name;
            do
            {
                name = Console.ReadLine();
            } while (name.Length <= 0);

            player = new Player(name);
            player.InRoom = 0; //Vilket rum spelaren är i, (startar i rum 0).

            LoadRooms();
        }

        private void LoadRooms()
        {
            //Start room
            Room room = new Room("The room is dark and enclosed with filth and grime on the walls.", false);
            Exit exit = new Exit("archway", 1, false, "", "It invites you in", "");
            room.AddExit(exit, "north");
            rooms[0] = room;

            //Room 1
            room = new Room("The room is sparsely furnished except for a sofa in the corner.", false);
            exit = new Exit("red door", 3, true, "You need a key to unlock the door.", "The red door is now open.", "key");
            room.AddExit(exit, "north");
            exit = new Exit("window", 8, false, "", "The window is open, a cool refreshing breeze brushes past your face.", "");
            room.AddExit(exit, "west");
            exit = new Exit("archway", 0, false, "", "It's dark and gloomy", "");
            room.AddExit(exit, "south");
            exit = new Exit("door", 2, false, "", "It's a regular door", "");
            room.AddExit(exit, "east");
            rooms[1] = room;

            //Room 2
            room = new Room("The room is dark but " + player.Name + " can feel the dust hanging in the air.", false);
            exit = new Exit("door", 1, false, "", "It's a regular door", "");
            room.AddExit(exit, "west");
            Item item = new Item("crowbar", "This is an old crowbar, someone has etched \"Property of Gordon\" on the side.");
            room.AddItem(item);
            item = new Item("key", "The key shines red when the light catches it.");
            room.AddItem(item);
            rooms[2] = room;

            //Room 3
            room = new Room("This is an enormous room, probably used as a dining room a long time ago. The walls are filled with strange paintings of annimals wearing human clothes.", false);
            exit = new Exit("staircase", 4, false, "", "You see a staircase leading to an attic.", "");
            room.AddExit(exit, "east");
            exit = new Exit("broken door", 5, true, "The doorknob is missing. The door looks like it is about to break.",
                "There is a big hole where the door used to be.", "crowbar");
            room.AddExit(exit, "west");
            exit = new Exit("red door", 1, false, "", "The red door is now open.", "");
            room.AddExit(exit, "south");
            rooms[3] = room;

            // Room 4
            room = new Room("You are in an attic. There are dead bats suspended all over the attic.", false);
            exit = new Exit("window", 8, false, "", "Thee sunlight shines through the window which bathes your face in warmth. It is open...", "");
            room.AddExit(exit, "east");
            exit = new Exit("staircase", 3, false, "", "The staircase leads back to the previous room.", "");
            room.AddExit(exit, "west");
            item = new Item("stick", "The stick is dry and brittle to the touch, it looks flammable.");
            room.AddItem(item);
            rooms[4] = room;

            // Room 5
            room = new Room("You walked in to an empty room.", false);
            exit = new Exit("dark corridor", 6, false, "", "The corridor is long and dark", "");
            room.AddExit(exit, "north");
            exit = new Exit("secret door", 9, false, "", "You can barely see the door, you can make out scratchmarks along the edges where it has been pried open many times before.", "");
            room.AddExit(exit, "west");
            exit = new Exit("broken door", 3, false, "", "There is a big hole where the door used to be.", "");
            room.AddExit(exit, "east");
            item = new Item("matchbox", "It's a blue box of matches.");
            room.AddItem(item);
            rooms[5] = room;

            //Room 6
            room = new Room("You step in to a fancy room. There are two chairs and a sofa, in front of the sofa is what looks like the pelt from a bear.", false);
            exit = new Exit("dark corridor", 5, false, "", "The corridor is long and dark", "");
            room.AddExit(exit, "south");
            exit = new Exit("window", 10, true, "The window is covered with boards.", "The window is now open.", "crowbar");
            room.AddExit(exit, "east");
            exit = new Exit("fireplace", 7, true, "There is no fire in the fireplace.", "A hidden passage was revealed behind the lit fireplace", "torch");
            room.AddExit(exit, "north");
            rooms[6] = room;

            //Room 7
            room = new Room("You crawl through a small dark passage. Suddenly there is light. You can feel a fresh spring breeze on your sweaty face. " +
                "\nYou run towards freedom. Congratulations " + player.Name + " you survived.", true);
            rooms[7] = room;

            //Room 8
            room = new Room("You jump from the window. You can feel the solid ground rush towards your face. "
                + player.Name + " is no more.....\n--------Game over---------", true);
            rooms[8] = room;

            //Room 9
            room = new Room("You see a huge hulking monster with bristling golden hair in the room. He notices you entering and hunts you down whilst bellowing \"Victor is HUNGRY!!!\". Unfortunately it seems you are the intended meal for this beast. \n GAME OVER...", true);
            rooms[9] = room;

            //Room 10
            room = new Room("You jump out the window. A thought strikes your mind \"This is never a good idea!!!!\" "
                            + player.Name + "is no more.....\n--------Game over---------", true);
            rooms[10] = room;
        }

        public void PlayGame()
        {
            Console.Clear();
            bool playing = true; //true medans spelet körs
            string instruction; //strängen som lagrar all input ifrån användaren

            Console.WriteLine("You wake up in what feels like a haunted house. You feel the urgent need to escape.\n <Write \"help\" for a list of commands.> ");
            Console.WriteLine(rooms[player.InRoom].GetDescription());

            while (playing)
            {
                //Läser in ord från konsolen och lagrar alla ord i en sträng array
                Console.Write("\nInput instructions:");
                instruction = Console.ReadLine();
                instruction = instruction.ToLower();

                string[] commands = instruction.Split(' '); //instruktionerna ord för ord
                Console.WriteLine(); //för layout

                //Switch-case sats som kollar vilket kommando som anropas, kommandot är alltid det första ordet användaren skrivit in.
                switch (commands[0])
                {
                    case "go":
                        //Försök flytta player till ett nytt rum
                        playing = !Go(commands); //Om spelet ska fortsätta efter go kommando utförts, GO() retunerar true om enpoint nåtts
                        break;
                    case "use":
                        //Försök att använda item/items
                        Use(commands);
                        break;
                    case "get":
                        //Försök att ta ett item
                        Get(commands);
                        break;
                    case "drop":
                        //Försök att droppa ett item
                        Drop(commands);
                        break;
                    case "look":
                        //Försök att kolla runt i rummet
                        Look(commands);
                        break;
                    case "inspect":
                        //Försök att inspektera item eller exit
                        Inspect(commands);
                        break;
                    case "inventory":
                        //Försök kolla på players inventory
                        Inventory(commands);
                        break;
                    case "help":
                        //Försök be om hjälp
                        Help(commands);
                        break;
                    default:
                        //Kommandot finns inte, skicka felmedelande
                        ErrorMessage();
                        break;
                }
            }
        }

        //När go-kommandot anropas
        private bool Go(string[] commands)
        {
            //Om kommandot skrivits in på rätt sätt
            if (commands.Length == 2 && (commands[1] == "west" || commands[1] == "east" ||
                                         commands[1] == "north" || commands[1] == "south"))
            {
                //Försöker flytta spelaren i rummet. 
                return TryMove(commands[1]); //Try move retunerar true om nya rummet är en endpoint, annars false
            }

            //Kommandot skrevs in på fel sätts
            Console.WriteLine("Are you drunk? You need to specify a correct direction.");

            return false; //Retunera att rum inte är endpoint
        }

        //Försök att flytta player, retunerar true om spelaren kommit till en endpoint
        private bool TryMove(string direction)
        {
            //försöker flytta player, metoden retunerar vilket rum player ska gå till
            //och retunerar -1 om player inte kunde gå till ett nytt rum
            int toRoom = rooms[player.InRoom].Go(direction);

            //flytta player och beskriv nya rummet
            if (toRoom >= 0)
            {
                player.InRoom = toRoom;
                Console.WriteLine(rooms[player.InRoom].GetDescription());
                return rooms[player.InRoom].EndPoint;
            }

            //Player kunde inte gå någonstans
            Console.WriteLine("You could not go " + direction + ".");
            return false;
        }

        //När use-kommandot anrpoas
        private void Use(string[] commands)
        {
            //Om ordet är för kort eller "on" inte är tredje ordet
            if (commands.Length < 4 || commands[2] != "on")
            {
                ErrorMessage();
                return; //Avsluta metoden efter att felmedelande skrivits ut
            }

            //Om det är mer än 4ord, gör så att sista fjärde kommandot består av ett sammansatt ord
            if (commands.Length > 4)
            {
                for (int i = 4; i < commands.Length; i++)
                {
                    commands[3] = commands[3] + " " + commands[i];
                }
            }

            //Försök att få angivet item från spelaren
            Item item = player.GetItem(commands[1]);
            
            //Om item inte fanns i player
            if (item == null)
            {
                Console.WriteLine("You don't have that item.");
            }
            //Om item hittades i player, försök att använda på exit
            else if (rooms[player.InRoom].UseItemOnExit(item, commands[3]))
            {
                //Om item kunde användas på exit, skriv ut att exit öppnats
                Console.WriteLine("You open the " + commands[3] + ".");
            }
            //Om use inte lyckats på exit, försök kombinera två items
            else if (player.CombinedItems(commands[1], commands[3]))
            {
                Console.WriteLine("You crafted a " + Item.CraftItem(commands[1], commands[3]).Name + ".");
            }
            else
            {
                Console.WriteLine("The combination does not work.");
            }
        }

        //När get-kommandot anrpoas
        private void Get(string[] commands)
        {
            if (commands.Length == 2)
            {
                //försök att ta ett item från det rummet player befinner sig i
                Item item = rooms[player.InRoom].GetItem(commands[1]);

                //om ett item hittats lägg till det i player
                if (item != null)
                {
                    player.AddItem(item);
                    Console.WriteLine("You picked up a " + item.Name + ".");
                }
                //annars om rummet innehåller textsträngen som efterfrågas
                else if (rooms[player.InRoom].GetDescription().Contains(commands[1]))
                {
                    Console.WriteLine("You cannot pick up the " + commands[1]);
                }
                else
                {
                    Console.WriteLine("There is no " + commands[1] + " in the room.");
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        //När drop-kommandot anrpoas
        private void Drop(string[] commands)
        {
            if (commands.Length == 2)
            {
                //ta ett item från player
                Item item = player.DropItem(commands[1]);

                //om item fanns, lägg till i rummet player befinner sig i
                if (item != null)
                {
                    rooms[player.InRoom].AddItem(item);
                    Console.WriteLine("You dropped " + item.Name + ".");
                }
                else
                {
                    Console.WriteLine("There is no " + commands[1] + " in your inventory.");
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        //När look-kommandot anrpoas
        private void Look(string[] commands)
        {
            if (commands.Length == 1)
            {
                //få beskrivning av rummet
                Console.WriteLine(rooms[player.InRoom].GetDescription());
            }
            else
            {
                ErrorMessage();
            }
        }

        //När inspect-kommandot anrpoas
        private void Inspect(string[] commands)
        {
            //inspect är alltid minst två ord långt
            if (commands.Length >= 2)
            {
                //om mer än två ord används, lägg till dem i andra platsen i commands
                if (commands.Length > 2)
                {
                    for (int i = 2; i < commands.Length; i++)
                    {
                        commands[1] = commands[1] + " " + commands[i];
                    }
                }

                //Begär att få information om item från players inventory
                string info;
                info = player.InspectInventory(commands[1]);

                //om item inte fanns i player
                if (info == null)
                {
                    //begär att få information om itemet i rummet
                    info = rooms[player.InRoom].InspectRoom(commands[1]);
                }

                //om rummet gav info om item
                if (info != null)
                {
                    Console.WriteLine(info);
                }
                else //item kunde inte hittas i rummet eller i player
                {
                    ErrorMessage();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        //När inventory-kommandot anrpoas
        private void Inventory(string[] commands)
        {
            if (commands.Length == 1)
            {
                //skriv ut vad player har i inventory
                Console.WriteLine(player.InventoryPrint());
            }
            else
            {
                ErrorMessage();
            }
        }

        //När help-kommandot anrpoas
        private void Help(string[] commands)
        {
            if (commands.Length == 1)
            {
                Console.WriteLine(
                    "Commands: \ngo <direction>\nuse <item>\nuse <item> on <item/exit>\nget <item>\ndrop <item>\nlook\ninspect <item/exit>\ninventory");
            }
            else
            {
                ErrorMessage();
            }
        }

        //Standard felmedelande när input kan tolkas
        private void ErrorMessage()
        {
            Console.WriteLine("Could not understand instructions.");
        }
    }
}
