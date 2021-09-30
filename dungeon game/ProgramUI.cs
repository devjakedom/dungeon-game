using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.Class1;

namespace dungeon_game
{
    public class ProgramUI
    {
        
        Character character = new Character(3);
        List<Item> inventory = new List<Item>();
        public void Run()
        {
            RunMenu();
        }
        bool isRunning = true;
        public void RunMenu()
        {
            while (isRunning)
            {
                Intro();
                PressAnyKeyToContinue();
                Console.Clear();
                Console.WriteLine("Instructions: You have three lives. There could be monsters at any turn. \n" +
                    "Either make the right decisions, or find a weapon to defeat monsters. \n" +
                    "If you have nothing to defend yourself you lose a life. Lose all three lives you die.\n" +
                    "\n" +
                    "Are you brave enough to take on the journey?\n" +
                    "\n" +
                    "1. Enter the dungeon\n" +
                    "2. Youre too scared. But you have to go in, how about the path to the left?\n");
                string switchOne = Console.ReadLine();

                switch (switchOne)
                {
                    case "1":
                        WrongPathMenuOption();
                        break;
                    case "2":
                        CorrectPathMenu();
                        break;
                    default:
                        EnterCorrectOption();
                        break;
                }
            }
        }


        //METHODS


        //Menu Options
        public void WrongPathMenuOption() //CHANGED
        {
            Console.Clear();
            Console.WriteLine("Dead. Confidence has killed this cat.");
            RunMenu();
        }

        public void CorrectPathMenu()
        {
            Console.Clear();
            Console.WriteLine("Mwahaha, you'll still have to find your way out.\n" +
                "You look to the left and see a trail of bones but then you look to the right and think you see something shiny.\n" +
                "1. Left toward bones \n" +
                "2. Right to the shining \n");
            string switchTwo = Console.ReadLine();
            switch (switchTwo)
            {
                case "1":
                    CorrectPathFirstOption();
                    break;
                case "2":
                    WrongPathFirstOption();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }

        public void CorrectPathFirstOption()
        {
            Console.Clear();
            Console.WriteLine("You've come to a T intersection. To the left the hall gets darker and darker until you can't see. To the right you see a bloody hand print on the wall.\n" +
                "Choose the number of your choice:\n" +
                "1. Dark hall\n" +
                "2. Bloody hand print AKA 'Wilson!'\n");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    WrongPathSecondOption();
                    break;
                case "2":
                    CorrectPathSecondOption();
                    break;
            }

        }

        public void WrongPathFirstOption()
        {
            Console.Clear();
            Console.WriteLine("The hallway comes to an end. But wait! Heres Johnny, theres a fragile knife...\n " +
                "May only be able to use to once but it could come in handy.\n" +
                "You picked it up and placed it in your inventory.\n" +
                "\n");
            PressAnyKeyToContinue();
            KnifeImage();
            PressAnyKeyToContinue();
            Console.Clear(); 

            Item knife = new Item(1, "Fragile Knife", ItemType.Knife);
            inventory.Add(knife);

            Console.WriteLine("Do you want to view your inventory?\n" +
                "1. Yes\n" +
                "2. No\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    DisplayInventory();
                    Console.Clear();
                    Console.WriteLine("Since path is a dead end you turn and head the other direction.");
                    PressAnyKeyToContinue();
                    CorrectPathFirstOption();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Since path is a dead end you turn and head the other direction.");
                    PressAnyKeyToContinue();
                    CorrectPathFirstOption();
                    break;
            }
        }

        //SECOND DECISION

        public void WrongPathSecondOption() //CHANGED
        {
            Console.Clear();
            Console.WriteLine("As you walk the hall gets darker and darker\n" +
                "Press 'f' to use flashlight\n");

            char flashlight = Console.ReadKey().KeyChar;
            if (flashlight == 'f')
            {
                Console.Clear();
                FlaslightImage();
                Console.WriteLine("Flashlight turns on...\n" +
                    "\n" +
                    "OH NO!! Its a ManBearPig!! Half man, half bear, half pig!!\n" +
                    "He turns his hideous mutated body towards you and lunges!\n" +
                    "Quick! If you have a weapon in your inventory you can kill it!\n");

                PressAnyKeyToContinue();
                ManBearPigImage();
                PressAnyKeyToContinue();

                if (inventory.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Items in inventory:\n" +
                        "Which item would you like to use?\n");

                    int index = 1;
                    foreach (Item item in inventory)
                    {
                        Console.WriteLine($"{index} {item.Name}");
                        index++;

                    }

                    int weaponSelected = int.Parse(Console.ReadLine());

                    int targetIndex = weaponSelected - 1;

                    Item userChoice = inventory[targetIndex];

                    WeaponBreak(userChoice);

                    inventory.Remove(userChoice);
                    Console.WriteLine();
                    Console.WriteLine("ManBearPig lands next to you motionless. Sayonara sucker, you whisper to yourself. You turn and walk out the room and head the other direction.");

                    PressAnyKeyToContinue();
                    CorrectPathSecondOption();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("The ManBearPig tackles you.. Theres nothing you can do to escape. You lose a live.");
                    character.Lives--;

                    Console.WriteLine($"You have this many lives left '{character.Lives}'");

                    PressAnyKeyToContinue();
                    CorrectPathSecondOption();
                }
            }
            else
            {

                Console.WriteLine("Thats not how you turn on a flashlight!");
                PressAnyKeyToContinue();
                WrongPathSecondOption();
            }
        }

        public void CorrectPathSecondOption()
        {
            Console.Clear();
            Console.WriteLine("Theres a long hallway with a door on the right.\n" +
                "Do you want to continue down the hall or go through the door?\n" +
                "1. I don't know what could be lurking behind that door. Go straight!\n" +
                "2. I aint scared of no ghosts! Go through the door.\n");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    CorrectPathThirdOption();
                    break;
                case "2":
                    FindAWeapon();
                    break;
                default:
                    Console.WriteLine("Please type an actual answer");
                    break;
            }
        }

        //THIRD DECISION

        public void CorrectPathThirdOption()
        {
            Console.Clear();
            Console.WriteLine("Shoot, the hallway branches off. Do you want to go left or right:\n" +
                "1. Left\n" +
                "2. Right\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    CorrectPathFourthOption();
                    break;
                case "2":
                    WrongPathFourthOption();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }

        public void FindAWeapon()
        {
            Console.Clear();
            Console.WriteLine("The room is pitch black.\n" +
                "\n" +
                "Do you want to turn on your flashlight to investigate or return?\n" +
                "Press 'f' to turn on flashlight.\n" +
                "Press any other key to return.\n" +
                "\n");
            char flashlight = Console.ReadKey().KeyChar;
            if (flashlight == 'f')
            {
                Console.Clear();
                FlaslightImage();
                Console.WriteLine("AHH! There's a skeleton laying on the ground!\n" +
                    "But in his hand there is a revelover.\n" +
                    "Unfortunately, there is only one bullet left. You'll have to use it wisely!\n" +
                    "\n");
                PressAnyKeyToContinue();

                RevolverImage();
                PressAnyKeyToContinue();
                Console.Clear();

                Item revolver = new Item(2, "Revolver", ItemType.Revolver);
                inventory.Add(revolver);

                Console.WriteLine("Do you want to view your inventory?\n" +
                "1. Yes\n" +
                "2. No\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        DisplayInventory();
                        Console.Clear();
                        Console.WriteLine("Since path is a dead end you turn and head down the hall.");
                        PressAnyKeyToContinue();
                        CorrectPathThirdOption();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Since path is a dead end you turn and head down the hall.");
                        PressAnyKeyToContinue();
                        CorrectPathThirdOption();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Returning to hallway.");
                PressAnyKeyToContinue();
                CorrectPathSecondOption();
            }

        }


        //FOURTH DECISION

        public void CorrectPathFourthOption()
        {
            Console.Clear();
            Console.WriteLine("As I walk through the valley of the shadow of death I take a look at my life and realize there's nothin' left 'Cause I've been blastin' and laughin' so long that Even my momma thinks that my mind is gone \n" +
                "OKAY, YOU GOTTA STOP SINGING! \n" +
                "As you walk down the hall it turns left or there is a door on the right \n" +
                "1. Go through the door because that may be the way.\n" +
                "2. Follow the hall and go left because doors mean nothing to you.\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    GemsOption();
                    break;
                case "2":
                    CorrectPathFifthOption();
                    break;
            }
        }




        public void WrongPathFourthOption()
        {
            Console.Clear();
            Console.WriteLine("As you walk down the hall way the power cuts off.. you fumble for your flashlight and drop it. \n" +
                "Its pitch black you cant see anything. \n" +
                "You drop to your hands and knees feeling around for the flashlight. Your hand bumps into something cold. \n" +
                "The lights flicker back on and you realize the cold object you felt was a bloody bone.\n" +
                "1. It is time to turn around and go the other way\n");
            Console.WriteLine("Select 1 to go the other way");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    PressAnyKeyToContinue();
                    CorrectPathFourthOption();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }


        // JEFFERY D OTTER SECTION
        public void GemsOption()
        {
            Console.Clear();
            Console.WriteLine("You deciced to go through the door to your right, you cant see anything. \n" +
                "Oh Wait! You see two glowing white gems.\n" +
                "1. Lets go look at the gems. \n" +
                "2. I just want to get the heck outta this joint, I do not need any stupid gems. I am turning around.");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    FightJeffreyDOtter();
                    break;
                case "2":
                    CorrectPathFourthOption();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }

        public void FightJeffreyDOtter()            //CHANGED
        {
            Console.Clear();
            Console.WriteLine("As you walk closer you realize they're not gems..... THEYRE EYES!\n" +
                "You start to back up but trip and fall. That is when the disgusting creature emerges.\n" +
                "Its a 10 foot otter showing his bloody fangs.\n" +
                "Quick! If you have a weapon you can kill it!\n");

            OtterImage();
            PressAnyKeyToContinue();

            if (inventory.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Items in inventory:\n" +
                    "Which item would you like to use?\n");

                int index = 1;
                foreach (Item item in inventory)
                {
                    Console.WriteLine($"{index} {item.Name}");
                    index++;

                }
                int weaponSelected = int.Parse(Console.ReadLine());

                int targetIndex = weaponSelected - 1;

                Item userChoice = inventory[targetIndex];

                WeaponBreak(userChoice);

                inventory.Remove(userChoice);

                Console.WriteLine("Jeffery D Otter stumbles... tries to take one last swing with his massive sharp claws. You duck and the swing misses. Since the room is a dead end you turn and head back the other direction.");
                
                PressAnyKeyToContinue();
                CorrectPathFifthOption();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Jeffrey D Otter slashes you with his claws. AHHHH! You lose a live.");
                character.Lives--;

                Console.WriteLine($"You have this many lives left '{character.Lives}'\n" +
                    $"Since the room is a dead end you turn and head back the other direction.\n");

                PressAnyKeyToContinue();
                CorrectPathFifthOption();
            }
        }

        //FIFTH DECISION

        public void CorrectPathFifthOption()
        {
            Console.Clear();
            Console.WriteLine("As you start walking down the hall you can tell your getting close to an exit.. You can hear the raging storm happening outside. You continue walking down the hall and are confronted with yet another decision. There is a door to your right or you can go straight.\n" +
                "Would you like to go through the door or go straight?\n" +
                "1. Through the door\n" +
                "2. Go straight \n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    DoorEntranceToFinalBossman();
                    break;
                case "2":
                    StraightToFinalBossman();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }

        public void DoorEntranceToFinalBossman()
        {
            Console.Clear();
            Console.WriteLine("As you walk through the door there is a flight of stairs. It is the only way to go. \n" +
                "1. Go down the stairs \n" +
                "2. GO DOWN THE STAIRS!");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    FinalDecision();
                    break;
                case "2":
                    FinalDecision();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }



        public void StraightToFinalBossman()
        {
            Console.Clear();
            Console.WriteLine("You decided to just walk straight down the hall.\n" +
                "OH NO! The floor doesnt feel steady, but you cannot turn around. \n" +
                "You come crashing to the ground. Panicking, you look around to see if anything is coming after you.\n" +
                "As the dust settles the only thing in the room is stairs and two doors.\n" +
                "Must be the stairs you saw from the floor above.\n");
            PressAnyKeyToContinue();
            FinalDecision();
        }


        //FINAL DECISION
        public void FinalDecision() //CHANGED
        {
            Console.Clear();
            Console.WriteLine("You've got to be close... at the end of the stairs the hall branches again. Do you want to go left or right? \n" +
                "1. Go directly left \n" +
                "2. Go right");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    FinalBattle();
                    break;
                case "2":
                    GetFinalBattleWeapon();
                    break;
                default:
                    EnterCorrectOption();
                    break;
            }
        }

        public void FinalBattle()  //CHANGED
        {
            Console.Clear();
            Console.WriteLine("As you round the corner you feel like youre almost free, in fact you can almost smell outside you think\n" +
                "You were right you can, you see a faint light! \n" +
                " That is when the disgusting creature emerges.\n" +
                "Its a troll!! He's only 3 feet tall, buts its FAST! Hes jumping from side to side licking his lips.\n" +
                "'You're gonna die now' he says... Just then, he steps on a rock. OWWW! He looks at his foot to examine the injury.\n" +
                "Quick! Nows your opportunity! If you have a weapon you can kill him!\n");
            PressAnyKeyToContinue();
            if (inventory.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Items in inventory:\n" +
                    "Which item would you like to use?\n");

                int index = 1;
                foreach (Item item in inventory)
                {
                    Console.WriteLine($"{index} {item.Name}");
                    index++;

                }
                int weaponSelected = int.Parse(Console.ReadLine());

                int targetIndex = weaponSelected - 1;

                Item userChoice = inventory[targetIndex];

                WeaponBreak(userChoice);

                inventory.Remove(userChoice);

                Console.WriteLine("The troll goes down. Behind him you notice a door with an exit sign above it.. QUICK! You sprint over as fast you can and open the door. The rain pelts your face and you run.  Your FREE!! Or so think... TO BE CONTINUED.");

                PressAnyKeyToContinue();
                YouWon();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Too late! The troll pounces and slashes you with his knife. You lose a live.");
                character.Lives--;

                if (character.Lives > 0)
                {
                    Console.WriteLine($"You have this many lives left '{character.Lives}'\n");
                }
                else
                {
                    YouLose();
                }


                PressAnyKeyToContinue();
                FinalDecision();
            }
        }



        public void GetFinalBattleWeapon()  //CHANGED
        {
            Console.Clear();
            Console.WriteLine("You turn right.. Theres a room that appears empty. But in the corner back corner you see something leaning against the wall.\n" +
                "As you get closer you notice it's a hammer. YES!! Another weapon, I just may be able to get out of here alive after all.\n" +
                "You add the hammer into the inventory.\n");

            HammerImage();
            PressAnyKeyToContinue();
            Console.Clear();

            Item hammer = new Item(3, "Hammer", ItemType.Hammer);
            inventory.Add(hammer);

            Console.WriteLine("Do you want to view your inventory?\n" +
            "1. Yes\n" +
            "2. No\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    DisplayInventory();
                    Console.Clear();
                    Console.WriteLine("Since the room is otherwise empty you turn and head the other way.");
                    PressAnyKeyToContinue();
                    FinalBattle();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Since the room is otherwise empty you turn and head the other way.");
                    PressAnyKeyToContinue();
                    FinalBattle();
                    break;

            }

        }




        //Helper Method



        public void EnterCorrectOption()
        {
            Console.WriteLine("READ! Enter a valid number.\n" +
                "Press any key to return.");
            Console.ReadKey();
        }



        public void PressAnyKeyToReturn()
        {
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }




        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        public void DisplayInventory()
        {
            foreach (Item item in inventory)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
            PressAnyKeyToContinue();
        }



        public void WeaponBreak(Item weapon)
        {

            if (weapon.ItemType == ItemType.Knife)
            {
                KnifeImage();
                PressAnyKeyToContinue();
                Console.Clear();
                Console.WriteLine("Your fragile knife broke!! The knife has been removed from your inventory.");
                
            }
            else if (weapon.ItemType == ItemType.Revolver)
            {
                Console.WriteLine("You used your last bullet!! The revolver has been removed from your inventory.");
                RevolverImage();
            }
            else if (weapon.ItemType == ItemType.Hammer)
            {
                Console.WriteLine("The handle breaks!! The hammer has been removed from your inventory.");
                HammerImage();
            }
        }


        public void YouWon()
        {
            Console.WriteLine("Congradulations! You've completed the maze. Returning to menu.");
            Run();
        }


        
        
            public void YouLose()
            {
                Console.WriteLine("WASTED.\n" +
                    "That was your last live.\n" +
                    "Returning to main menu.\n");
            WastedImage();
                PressAnyKeyToContinue();
                isRunning = false;
                return;
            }

        public void WastedImage()
        {
            Console.WriteLine(
"░██╗░░░░░░░██╗░█████╗░░██████╗████████╗███████╗██████╗░\n" +
"░██║░░██╗░░██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗\n" +
"░╚██╗████╗██╔╝███████║╚█████╗░░░░██║░░░█████╗░░██║░░██║\n" +
"░░████╔═████║░██╔══██║░╚═══██╗░░░██║░░░██╔══╝░░██║░░██║\n" +
"░░╚██╔╝░╚██╔╝░██║░░██║██████╔╝░░░██║░░░███████╗██████╔╝\n" +
"░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═════╝░\n");
        }
        public void FlaslightImage()
        {
            Console.WriteLine(
"                                    ░░  ██████████        ░░                            \n" +
"                                    ████░░░░░░░░░░████                                  \n" +
"                                  ██░░░░░░            ██                                \n" +
"                                ██░░░░                  ██                              \n" +
"                              ██░░░░                      ██                            \n" +
"                              ██░░                        ██                            \n" +
"                            ██░░░░                          ██                          \n" +
"                            ██░░░░                          ██                          \n" +
"                            ██░░░░                          ██                          \n" +
"                            ██░░░░                          ██                          \n" +
"                            ██░░░░    ░░          ░░        ██                          \n" +
"                              ██░░    ░░          ░░      ██                            \n" +
"                              ██░░░░    ░░      ░░        ██                            \n" +
"                                ██░░    ░░      ░░      ██                              \n" +
"                                ██░░░░    ░░░░░░        ██                              \n" +
"        ░░      ░░            ░░  ██░░░░  ░░  ░░      ██  ░░              ░░      ░░    \n" +
"                      ░░            ██░░  ░░  ░░    ██    ░░      ░░                    \n" +
"                                    ██████████████████                                  \n" +
"                                    ██▒▒░░░░░░░░░░░░██                                  \n" +
"                                  ██▒▒▒▒████████████████  ░░                            \n" +
"                                  ██▒▒░░░░░░░░░░░░░░░░██                                \n" +
"                                  ██▒▒▒▒████████████████                                \n" +
"                                    ██▒▒░░░░░░░░░░░░██                                  \n" +
"                                    ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                                  \n" +
"                                      ██████████████                                    \n" +
"                                                                                        \n" +
"░░░░░░░░░░░░░░  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ░░░░░░\n");
        }

        public void ManBearPigImage()
        {
            Console.WriteLine(
"                            ████████              ██████████                                \n" +
"                          ██░░▒▒░░░░██          ██░░░░▒▒░░░░██                              \n" +
"                        ██░░░░░░░░████████████████░░░░░░░░░░░░██                            \n" +
"                        ██░░░░████░░░░░░░░░░░░░░██░░░░░░░░░░░░██                            \n" +
"                        ██░░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                            \n" +
"                        ████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                            \n" +
"                        ████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                            \n" +
"                        ██░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░██                            \n" +
"                        ██████░░░░░░░░░░░░░░████░░░░░░░░░░░░░░██                            \n" +
"                        ██▒▒▒▒▓▓██░░░░░░░░▓▓▒▒░░░░░░░░░░░░░░░░▒▒▓▓                          \n" +
"                        ██░░░░▒▒░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░██                          \n" +
"                        ██░░░░████▓▓▓▓██░░░░░░░░░░░░░░░░░░░░░░░░██                          \n" +
"                      ██░░░░░░██░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░██                          \n" +
"                      ██░░░░▓▓██░░░░░░░░██▓▓▓▓░░░░░░░░░░░░░░░░░░▒▒██                        \n" +
"                      ██░░██▒▒████▓▓▓▓██▒▒▒▒▒▒██░░░░░░░░░░░░░░░░░░██                        \n" +
"                      ██░░██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░░░░░░░░░░░██                        \n" +
"                      ██░░██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒██▓▓░░░░░░░░░░░░██████▓▓░░██                \n" +
"                      ██░░██▓▓▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▓▓▒▒██░░░░░░░░░░░░░░▒▒▒▒▒▒░░██████            \n" +
"                      ██░░░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████        \n" +
"                      ██░░░░░░████▒▒▒▒▒▒▒▒▒▒████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██      \n" +
"      ████████        ██░░░░░░░░░░██▓▓██████░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░██      \n" +
"    ██████░░████      ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░██    \n" +
"  ████  ██░░██  ██    ██░░░░░░░░▒▒▒▒░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░██    \n" +
"  ████░░██████░░██    ██░░░░░░░░░░▒▒▒▒░░░░▒▒▒▒░░░░░░░░░░░░░░░░██████░░░░░░░░░░░░░░░░░░██    \n" +
"  ██▒▒██▒▒▒▒████      ██░░░░██░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░██░░██▒▒░░░░░░░░░░░░░░░░██      \n" +
"  ██▒▒▒▒░░▒▒▒▒██    ██░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  ██▒▒▒▒▒▒░░░░░░░░░░░░░░██      \n" +
"  ██░░░░░░░░░░▒▒▓▓▓▓▒▒░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░██▓▓██▒▒▒▒▒▒░░░░░░░░░░░░██        \n" +
"  ██░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░██▒▒▒▒▒▒░░░░░░████          \n" +
"  ██░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████▒▒▒▒▒▒▒▒████              \n" +
"    ██░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░██▒▒████                  \n" +
"    ██░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████░░░░██                \n" +
"      ████░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██              \n" +
"          ████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            \n" +
"                    ████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            \n" +
"                ████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██          \n" +
"              ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██          \n" +
"            ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████████░░░░░░░░░░░░░░░░░░░░░░░░██        \n" +
"          ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████            ██████░░░░░░░░░░░░░░░░░░██        \n" +
"          ██░░░░░░░░░░░░░░░░░░░░░░░░████                    ██░░██░░░░░░░░░░░░░░░░██        \n" +
"        ██░░░░░░░░░░░░░░░░░░░░░░████░░                    ██▒▒░░░░██░░░░░░░░░░░░░░██        \n" +
"        ██░░░░░░░░░░░░░░░░░░░░██                          ██▒▒░░░░░░████░░░░░░░░██          \n" +
"      ██▒▒░░░░░░░░░░░░░░░░░░▓▓░░                          ██▒▒▒▒░░░░▒▒▒▒▓▓▒▒▓▓▒▒░░          \n" +
"      ██▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░██                            ██▒▒▒▒░░░░██████████              \n" +
"    ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                              ██░░▒▒░░██                        \n" +
"    ██░░▒▒░░░░▒▒▒▒▒▒▒▒▒▒▒▒██                              ████████                          \n" +
"    ██████████████████████                                                                  \n");
        }
        

        public void OtterImage()
        {
            Console.WriteLine(
"                    ▒▒▓▓▓▓██▒▒                          \n" +
"                    ▓▓██▓▓▓▓▓▓▓▓                        \n" +
"                  ▓▓████▓▓▓▓▓▓▓▓                        \n" +
"                  ▓▓▓▓██▓▓▓▓▓▓▓▓▓▓                      \n" +
"                    ▒▒▓▓▓▓▓▓▓▓▓▓▓▓                      \n" +
"                        ░░▓▓▒▒▒▒▓▓▓▓                    \n" +
"                          ▒▒▒▒▒▒▓▓▓▓                    \n" +
"                  ▓▓      ░░▒▒▒▒▓▓▓▓                    \n" +
"                ░░▓▓██      ▒▒▒▒▓▓▓▓██                  \n" +
"                ▒▒▓▓▓▓▓▓▒▒▓▓▒▒▒▒▓▓▓▓▓▓▒▒                \n" +
"                  ▓▓░░▒▒▓▓██▒▒▒▒▒▒▓▓▓▓▓▓                \n" +
"                          ▒▒▒▒▒▒▓▓▓▓  ▓▓░░              \n" +
"                          ▒▒▒▒▒▒▓▓▓▓  ██▒▒              \n" +
"                        ░░▒▒▒▒▒▒▓▓██  ▓▓▓▓              \n" +
"                        ▓▓▒▒▒▒▒▒▓▓▓▓  ▓▓▓▓░░            \n" +
"                        ▒▒▒▒▒▒▒▒▒▒▓▓                    \n" +
"                      ▒▒▒▒▒▒▒▒▒▒▓▓▓▓                    \n" +
"                      ▒▒▒▒▒▒▒▒▒▒▒▒▓▓                    \n" +
"                      ▓▓▒▒▒▒▒▒▒▒▒▒▓▓                    \n" +
"                      ▓▓▒▒▒▒▒▒▒▒▓▓▓▓                    \n" +
"                      ▓▓▒▒▒▒▒▒▒▒▓▓▓▓                    \n" +
"                        ▒▒▒▒▒▒▒▒▓▓██                    \n" +
"                        ▒▒▓▓▓▓▓▓▓▓██░░                  \n" +
"                        ▒▒▓▓    ▓▓██▓▓                  \n" +
"                        ▓▓▒▒    ▒▒▓▓▓▓▓▓░░              \n" +
"                    ██▓▓▓▓    ░░▓▓▓▓▓▓▓▓▓▓              \n" +
"                    ▓▓▓▓▒▒    ▓▓▓▓▓▓    ▒▒              \n" +
"                      ░░        ██▒▒                    \n");
        }

        public void HammerImage()
        {
            Console.WriteLine(
"                  ██                \n" +
"                ██▒▒██              \n" +
"              ██▒▒▒▒▒▒██            \n" +
"      ██████  ██████████  ██████    \n" +
"    ██░░░░░░██░░██▓▓██░░██░░░░░░██  \n" +
"  ██▒▒▒▒▒▒▒▒░░▒▒██▓▓██▒▒░░▒▒▒▒░░░░██\n" +
"  ██▒▒▒▒▒▒▒▒▓▓▒▒██▓▓██▒▒▓▓▒▒▒▒▒▒░░██\n" +
"  ██▒▒▒▒▒▒▒▒██▒▒██▓▓██▒▒██▒▒▒▒▒▒░░██\n" +
"  ██▒▒▒▒▒▒▒▒██▒▒██▓▓██▒▒██▒▒▒▒▒▒░░██\n" +
"  ██▒▒▒▒▒▒▒▒██▒▒██▓▓██▒▒██▒▒▒▒▒▒░░██\n" +
"  ██▒▒▒▒▒▒▒▒▒▒▒▒██▓▓██▒▒▒▒▒▒▒▒▒▒░░██\n" +
"    ██▒▒▒▒▒▒██▒▒██▓▓██▒▒██▒▒▒▒▒▒██  \n" +
"      ██████  ████▓▓████  ██████    \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"░░          ░░  ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"              ██████████            \n" +
"            ██▒▒▒▒▒▒▒▒▒▒██          \n" +
"              ██████████            \n" +
"                ██▓▓██              \n" +
"                ██▓▓██              \n" +
"                  ██                ");
        }

        public void KnifeImage()
        {
            Console.WriteLine(
"  ████                                       \n" +                                                    
"██▒▒████                                                                                        \n" +
"  ██▒▒░░████                                                                                    \n" +
"  ██▒▒▒▒    ████                                                                                \n" +
"    ██▒▒▒▒░░  ░░██                                                                              \n" +
"    ██▒▒▒▒▒▒░░░░░░████                                                                          \n" +
"      ██▒▒▒▒▒▒░░░░░░░░████                                                                      \n" +
"        ██▒▒▒▒▒▒░░░░░░  ░░██                                                                    \n" +
"          ██▒▒▒▒▒▒░░░░░░░░░░██                                                                  \n" +
"            ██▒▒▒▒▒▒░░░░░░░░░░████                                                              \n" +
"            ▓▓██▒▒▒▒▒▒░░░░░░░░    ██                                                            \n" +
"            ▓▓▒▒██▒▒▒▒▒▒▒▒░░░░░░░░░░██                                                          \n" +
"              ▓▓▓▓██▒▒▒▒▒▒▒▒░░░░░░░░░░████                                                      \n" +
"                  ▓▓██▒▒▒▒▒▒▒▒░░░░░░░░    ██                                                    \n" +
"                  ▓▓▒▒██▒▒▒▒▒▒▒▒░░░░░░░░░░░░██                                                  \n" +
"                    ▓▓▒▒██▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░████                                              \n" +
"                      ▓▓▓▓████▒▒▒▒▒▒▒▒░░░░░░░░    ██                                            \n" +
"                          ▓▓▒▒██▒▒▒▒▒▒▒▒░░░░░░░░░░░░████        ████████                        \n" +
"                            ▓▓▒▒██▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░██    ██        ████                    \n" +
"                            ▓▓▒▒▒▒██▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░████      ░░      ██                  \n" +
"                              ▓▓▓▓▒▒████▓▓▒▒▒▒▒▒░░░░░░░░░░  ██    ░░░░░░      ██                \n" +
"                                  ▓▓▒▒▒▒██▓▓▓▓▓▓▒▒▓▓░░░░░░░░██    ░░██░░      ░░██              \n" +
"                                    ▓▓▓▓▒▒████▒▒▒▒▓▓▓▓░░░░████    ░░██░░░░      ██              \n" +
"                                        ▓▓▒▒▒▒██▒▒▓▓██████  ░░██░░░░████░░░░      ██            \n" +
"                                        ▓▓▒▒▓▓▒▒████  ██      ░░████▓▓▓▓████░░░░░░  ██          \n" +
"                                        ▓▓▓▓  ▓▓▒▒▓▓  ██  ░░░░██░░░░████▓▓▓▓██░░░░░░░░██        \n" +
"                                              ▓▓▒▒▓▓    ██████  ░░░░██░░██▓▓▓▓████░░░░░░▓▓      \n" +
"                                              ▓▓▒▒▓▓    ██  ░░  ████░░░░████▓▓▓▓▓▓██░░░░░░▓▓    \n" +
"                                              ▓▓▒▒▓▓      ██████  ░░████░░██▓▓▓▓▓▓▓▓██░░░░░░██  \n" +
"                                              ▓▓▒▒▓▓          ██████░░░░██▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░██\n" +
"                                                ▓▓                ██████  ██▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░\n" +
"                                                                            ██▓▓▓▓▓▓▓▓▓▓██░░░░░░\n" +
"                                                                              ██▓▓▓▓▓▓██░░░░░░░░\n" +
"                                                                                ██████░░░░░░░░░░\n" +
"                                                                                  ██░░░░░░░░░░░░\n" +
"                                                                                    ██░░░░░░░░░░\n" +
"                                                                                      ██░░░░░░░░\n" +
"                                                                                        ██░░░░░░\n" +
"                                                                                          ██░░░░\n" +
"                                                                                            ▓▓░░\n" +
"                                                                                            ░░▓▓\n" ); 
        }

        public void RevolverImage()
        {
            Console.WriteLine(
    "    ██████████                                  \n" +
    "██████░░░░░░██                                  \n" +
    "██░░██░░░░░░██                                  \n" +
    "██░░██░░░░░░████                                \n" +
    "  ████░░░░░░██░░██                              \n" +
    "    ██░░░░░░██░░░░██                           \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "    ██░░░░░░██░░░░██                            \n" +
    "  ████████████████████████                      \n" +
    "  ██░░░░░░░░░░░░░░░░░░░░░░██                    \n" +
    "  ██░░████████████████░░░░░░██                  \n" +
    "  ██░░██░░██░░██░░████░░██░░░░░░██              \n" +
    "  ██░░██░░██░░██░░████░░██████░░░░██            \n" +
    "  ██░░██░░██░░██░░████░░██░░░░██░░██            \n" +
    "  ██░░██░░██░░██░░████░░████████░░██            \n" +
    "  ██░░██░░██░░██░░████░░██░░░░██░░██            \n" +
    "  ██░░██░░░░██░░░░░░██░░██░░████░░██            \n" +
    "  ██░░██░░░░░░░░░░░░██░░████░░██░░██            \n" +
    "  ██░░████████████████░░██░░░░██░░██            \n " +
    "  ██░░░░██░░░░░░░░░░██░░██████░░░░██            \n" +
    "    ██░░░░██░░░░░░░░██░░██░░░░░░██              \n" +
    "      ██░░░░████████░░░░░░██░░██                \n" +
    "        ████████░░░░░░████████                  \n" +
    "          ██░░░░██░░██▒▒▒▒▒▒▒▒██████████████    \n" +
    "        ██░░░░░░░░██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  \n" +
    "      ██░░░░██░░░░██▒▒▒▒██░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\n" +
    "      ██░░██  ██████▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██\n" +
    "      ██░░██        ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░██▒▒▒▒██\n" +
    "        ██            ██████▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██\n" +
    "                            ██████▒▒▒▒▒▒▒▒▒▒██  \n" +
    "                                  ██████████    \n");
        }

        public void Intro()
        {
            Console.WriteLine(
"██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\n" +
"█░░░░░░░░░░░░███░░░░░░██░░░░░░█░░░░░░██████████░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░██████████░░░░░░█\n" +
"█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░░░░░░░░░██░░▄▀░░█\n" +
"█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░██░░▄▀░░█\n" +
"█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░██░░▄▀░░█\n" +
"█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█\n" +
"█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░██░░░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█\n" +
"█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█\n" +
"█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░░░░░▄▀░░█\n" +
"█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀▄▀▄▀░░█\n" +
"█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░░░░░░░░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░░░░░░░░░▄▀░░█\n" +
"█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██████████░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░██████████░░░░░░█\n" +
"██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\n" +
"██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\n" +
"█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██████████░░░░░░█░░░░░░█████████░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███\n" +
"█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██████████░░▄▀░░█░░▄▀░░█████████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███\n" +
"█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░▄▀░░█░░▄▀░░██████████░░▄▀░░█░░▄▀░░█████████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░▄▀░░███\n" +
"█░░▄▀░░█████████░░▄▀░░████░░▄▀░░███░░▄▀░░██░░▄▀░░█░░▄▀░░██████████░░▄▀░░█░░▄▀░░█████████░░▄▀░░█████████░░▄▀░░████░░▄▀░░███\n" +
"█░░▄▀░░█████████░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░░░░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░▄▀░░███\n" +
"█░░▄▀░░█████████░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███\n" +
"█░░▄▀░░█████████░░▄▀░░░░░░▄▀░░░░███░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░░░███\n" +
"█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░░░░░▄▀░░█░░▄▀░░█████████░░▄▀░░█████████░░▄▀░░██░░▄▀░░█████\n" +
"█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░░░░░█\n" +
"█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░░░░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀░░█\n" +
"█░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░░░█░░░░░░██░░░░░░█░░░░░░██░░░░░░██░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░░░█\n" +
"██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\n");
        }
    }
}









