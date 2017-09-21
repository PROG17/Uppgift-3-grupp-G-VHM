using System;
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
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();
            player = new Player(name);
            player.InRoom = 0;
            
            LoadRooms();
        }

        public void LoadRooms()
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
            room = new Room(" This is an enormous room, probably used as a dining room a long time ago. The walls are filled with strange paintings of annimals wearing human clothes.", false);
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
            exit = new Exit("window",8,false,"","Thee sunlight shines through the window which bathes your face in warmth. It is open...", "");
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
            room = new Room("You crawl through a small dark passage. Suddenly there is light. You can feel a fresh spring breeze nn your sweaty face. " +
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
            bool playing = true;
            string instruction;

            Console.WriteLine("You wake up in what feels like a haunted house. You feel the urgent need to escape.\n <Write \"help\" for a list of commands.> ");
            Console.WriteLine(rooms[player.InRoom].GetDescription());

            while (playing)
            {
                Console.Write("Input instructions:");
                instruction = Console.ReadLine();
                instruction = instruction.ToLower();
                string[] commands = instruction.Split(' ');
                Console.WriteLine();
                switch (commands[0])
                {
                    case "go":
                        if (commands.Length == 2 && (commands[1] == "west" || commands[1] == "east" || commands[1] == "north" ||
                            commands[1] == "south"))
                        {
                            playing = !TryMove(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine("Are you drunk? You need to specify a correct direction.");
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
                                    Console.WriteLine("You open the " + commands[3]);
                                }
                                else
                                {
                                    success = player.CombinedItems(commands[1], commands[3]);
                                    if (success)
                                    {
                                        Console.WriteLine("You crafted a " + Item.CraftItem(commands[1], commands[3]).Name); 
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
                            if (item == null && rooms[player.InRoom].GetDescription().Contains(commands[1]))
                            {
                                Console.WriteLine("You cannot pick up the " + commands[1]);
                            }
                            else if(item == null)
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
                    case "inventory":
                        if (commands.Length == 1)
                        {
                            Console.WriteLine(player.InventoryPrint());
                        }
                        else
                        {
                             ErrorMessage();
                        }
                        break;
                    case "help":
                        if (commands.Length == 1)
                        {
                            Console.WriteLine("Commands: \ngo <direction>\nuse <item>\nuse <item> on <item/exit>\nget <item>\ndrop <item>\nlook\ninspect <item/exit>\ninventory");
                        }
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
        }

        public bool TryMove(string direction)
        {
            int toRoom = rooms[player.InRoom].Go(direction);
            if (toRoom >= 0)
            {
                player.InRoom = toRoom;
                Console.WriteLine(rooms[player.InRoom].GetDescription());
                return rooms[player.InRoom].EndPoint;
            }
            else
            {
                Console.WriteLine("You could not go " + direction + ".");
                return false;
            }
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Could not understand instructions.");
        }
    }
}
