using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Game
    {
        private Room[] rooms = new Room[7];
        private Player player;

        public Game()
        {
            Console.Write("Choose a player name: ");
            string name = Console.ReadLine();
            player = new Player(name);
            player.InRoom = 0;
            
            LoadRooms();
        }

        public void LoadRooms()
        {
            //Exempel room
            Room room = new Room("This is a test room.", false);
            Exit exit = new Exit("red door", 1, true, "red it is locked", "it's open", "fork");
            room.AddExit(exit, "west");
            exit = new Exit("door", 1, true, "it is locked", "it's open", "fork");
            room.AddExit(exit, "east");
            Item item = new Item("fork", "this is a dirty fork.");
            room.AddItem(item);
            rooms[0] = room;

        }

        public void PlayGame()
        {
            Console.Clear();
            bool playing = true;
            string instruction;

            Console.WriteLine("You are waking up in haunted house. Get out as fast asap.");
            Console.WriteLine(rooms[player.InRoom].GetDescription());

            while (playing)
            {
                Console.Write("Input instructions:");
                instruction = Console.ReadLine();
                instruction = instruction.ToLower();
                string[] commands = instruction.Split(' ');

                switch (commands[0])
                {
                    case "go":
                        if (commands[1] == "west")
                        {
                            TryMove("west");
                        }
                        else if (commands[1] == "east")
                        {
                            TryMove("east");
                        }
                        else if (commands[1] == "north")
                        {
                            TryMove("north");
                        }
                        else if (commands[1] == "south")
                        {
                            TryMove("south");
                        }
                        else
                        {
                            Console.WriteLine("Are you drunk, you need to specify a correct direction.");
                        }
                        break;
                    case "use":
                        if (commands.Length >= 4 && commands[2] == "on")
                        {
                            if (commands.Length > 4)
                            {
                                for (int i = 4; i < commands.Length; i++)
                                {
                                    commands[3] = commands[3] + " " + commands[i];
                                }
                            }
                            Item item = player.GetItem(commands[1]);
                            if (item != null)
                            {
                                bool success = false;
                                success = rooms[player.InRoom].UseItemOnExit(item, commands[3]);
                                if (success)
                                {
                                    Console.WriteLine("You open a door");
                                }
                                else
                                {
                                    success = player.CombinedItems(commands[1], commands[3]);
                                    if (success)
                                    {
                                        Console.WriteLine("You crafted a new item.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The combination does not work.");   
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have that item");
                            }
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case "get":
                        if (commands.Length == 2)
                        {
                            Item item = rooms[player.InRoom].GetItem(commands[1]);
                            if (item != null)
                            {
                                player.AddItem(item);
                                Console.WriteLine("You picked up a " + item.Name + ".");
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
                        break;
                    case "drop":
                        if (commands.Length == 2)
                        {
                            Item item = player.DropItem(commands[1]);
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
                            ErrorMessage();
                        break;
                    case "look":
                        if (commands.Length == 1)
                        {
                            Console.WriteLine(rooms[player.InRoom].GetDescription());
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case "inspect":
                        if (commands.Length >= 2)
                        {
                            if (commands.Length > 2)
                            {
                                for (int i = 2; i < commands.Length; i++)
                                {
                                    commands[1] = commands[1] + " " + commands[i];
                                }
                            }
                            string info = null;
                            info = player.InspectInventory(commands[1]);
                            if (info == null)
                            {
                                info = rooms[player.InRoom].InspectRoom(commands[1]);
                            }
                            if (info != null)
                            {
                                Console.WriteLine(info);
                            }
                            else
                            {
                                ErrorMessage();
                            }                            
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    default:
                        ErrorMessage();
                        break;
                }

            }
        }

        public void TryMove(string direction)
        {
            int toRoom = rooms[player.InRoom].Go(direction);
            if (toRoom >= 0)
            {
                player.InRoom = toRoom;
                Console.WriteLine(rooms[player.InRoom].GetDescription());
            }
            else
            {
                Console.WriteLine("You could not go " + direction + ".");
            }
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Could not understand instructions.");
        }
    }
}
