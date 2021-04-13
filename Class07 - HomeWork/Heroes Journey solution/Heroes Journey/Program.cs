using Heroes_Journey.Class;
using System;

namespace Heroes_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            User [] UsersArr = { new User("vlatko@yahoo.com", "123456"), new User("jakimovski@uahoo.com", "654321") };
            if (!EmailPasswordCorrect(UsersArr))
            {
                Console.WriteLine("You have entered 5 wrong inputs, App is closing");
                System.Environment.Exit(0);
            }

            StartGame();

        }
        /// START GAME
        static void StartGame()
        {

            Hero heroOne = new Hero();
            Console.WriteLine("Next STEP -> Caharacter creating \n Enter character name :");

            heroOne.Name = NameInput();

            ChooseRace(heroOne);
            ChooseClass(heroOne);

            int EventCounter = 0;
            while (EventCounter < 5)
            {
                ChooseFightOrRunAway(heroOne);
                EventCounter++;
            }
            Console.WriteLine($"CONGRATULATIONS !!! YOU WON ! ");
            ReviewHero(heroOne);
        }

        ///////////////// Part -1  LOGIN  USER /////////////////////////////
        // Check if user email and password are correct (5 attempts)
        static bool EmailPasswordCorrect(User[] userArr)
        {
            string email;
            string pass;

            int counter = 0;
            bool LogIn = false;
            while (counter < 5)
            {
                Console.WriteLine("Please insert Email");
                email = Console.ReadLine();
                Console.WriteLine("Please insert Password");
                pass = Console.ReadLine();

                foreach (User item in userArr)
                {
                    if (item.GetEmail() == email && item.GetPassword() == pass && EmailCheckValid(item.GetEmail()))
                    {
                        LogIn = true;
                        Console.WriteLine($"Successfull logged in !!!");
                        break;
                    }
                }
                if (LogIn)
                {
                    break;
                }
                Console.WriteLine("Wrong input, try again !");
                counter++;
            }
            return LogIn;
        }

        // Checking if email contains . and @
        static bool EmailCheckValid(string email)
        {
            return (email.Contains('.') && email.Contains('@'));
        }

        ///////////////// Part -2 CREATE CHARACTER  /////////////////////////////
        ///Check name
        static string NameInput ()
        {
            string name = "-1";
            while (name == "-1")
            {
                name = Console.ReadLine();
                if (name.Length >=1 && name.Length <= 20)
                {
                    return name;
                }
                Console.WriteLine("Please write name with more then 1 and less then 20 characters");
            }
            return name;
        }

        //SWITCH  RACES  AND  CLASS 
        static void ChooseRace (Hero hero)
        {
            Console.WriteLine("Select Race 1,  2  or  3");
            Console.WriteLine("1) Dwarf \n - Has 100 Health \n - Has 6 Strength \n - Has 2 Agility \n");
            Console.WriteLine("2) Elf \n - Has 60 Health \n - Has 4 Strength \n - Has 6 Agility \n");
            Console.WriteLine("3) Human \n - Has 80 Health \n - Has 5 Strength \n - Has 4 Agility \n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hero.Health = 100; hero.Strength = 6; hero.Agility = 2; hero.Race = "Dwarf";
                    break;
                case "2":
                    hero.Health = 60; hero.Strength = 4; hero.Agility = 6; hero.Race = "Elf";
                    break;
                case "3":
                    hero.Health = 80; hero.Strength = 5; hero.Agility = 4; hero.Race = "Human";
                    break;
                default:
                    Console.WriteLine("Wrong select !!! ");
                    ChooseRace(hero);
                    break;
            }
        }

        static void ChooseClass(Hero hero)
        {
            string choice = "-1" ;
            while (choice != "1" || choice != "2" || choice != "3")
            {
                Console.WriteLine("Select Class 1,  2  or  3");
                Console.WriteLine("1) Warrior \n * + 20 Health \n * - 1 Agility \n");
                Console.WriteLine("2) Rogue \n * - 20 Health \n * + 1 Agility \n");
                Console.WriteLine("3) Mage \n * + 20 Health \n * - 1 Strength \n");

                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3")
                    break;
            }

            switch (choice)
            {
                case "1":
                    hero.Health += 20;  hero.Agility -= 1; hero.Class = "Warrior";
                    break;
                case "2":
                    hero.Health -= 20; hero.Agility += 1; hero.Class = "Rogue";
                    break;
                case "3": 
                    hero.Health += 20; hero.Strength -= 1; hero.Class = "Mage";
                    break;
                default:
                    break;
            }
            Console.WriteLine("Successfully create hero");
            ReviewHero(hero);
        }

        //// REVIEW 
        static void ReviewHero (Hero hero)
        {
            Console.WriteLine($"{hero.Name} ({hero.Race}) the {hero.Class}");
            Console.WriteLine($"{hero.Health} HP, {hero.Strength} STR, {hero.Agility} AGI ");
        }

        ///////////////// Part -3  GAMEPLAY /////////////////////////////
        // Random 1-5
        static int RandomNumberOneToFive()
        {
            Random number = new Random();
            return number.Next(1, 6);
        }
        // Random 1-10
        static int RandomNumberOneToTen()
        {
            Random number = new Random();
            return number.Next(1, 11);
        }


        static void ChooseFightOrRunAway (Hero hero)
        {
            int healthSubstraction = EventInvolved();
            string choice = "-1";
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Choose event: \n 1) FIGHT !!! \n 2) Run Away !");
                choice = Console.ReadLine();
            }
            if(choice == "1")
            {
                if (RandomNumberOneToTen() < hero.Strength)
                {
                    Console.WriteLine("YOU WON FIGHT !!!");
                } else
                {
                    hero.Health -= healthSubstraction;
                    Console.WriteLine($"YOU LOST THE FIGHT! Substract {healthSubstraction} and now you have {hero.Health} HP");
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine("YOU LOST, YOU ARE DEAD ! \n Dou you want to start new game ? \n 1) YES \n 2) NO");
                        string choiceAfterLost = Console.ReadLine();
                        while (choiceAfterLost != "1" && choiceAfterLost != "2" )
                        {
                            Console.WriteLine("You must choose  \n 1 - New Game  \n 2 - Exit application");
                            choiceAfterLost = Console.ReadLine();
                        }
                        if (choiceAfterLost == "1")
                        {
                            StartGame();
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                    }
                }
            }
            else if (choice == "2")
            {
                if (RandomNumberOneToTen() < hero.Agility)
                {
                    Console.WriteLine("YOU RUN AWAY SUCCESSFULLY !!!");
                }
                else
                {
                    hero.Health -= healthSubstraction;
                    Console.WriteLine($"YOU GOT COUGHT ! Substract {healthSubstraction} and now you have {hero.Health} HP");
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine("YOU LOST, YOU ARE DEAD ! \n Dou you want to start new game ? \n 1) YES \n 2) NO");
                        string choiceAfterLost = Console.ReadLine();
                        while (choiceAfterLost != "1" && choiceAfterLost != "2")
                        {
                            Console.WriteLine("You must choose  \n 1 - New Game  \n 2 - Exit application");
                            choiceAfterLost = Console.ReadLine();
                        }
                        if (choiceAfterLost == "1")
                        {
                            StartGame();
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                    }
                }
            }
        }

        // Event involved in and health substraction return
        static int EventInvolved()
        {
            int healthSubstract = 0;
            switch (RandomNumberOneToFive())
            {
                case 1:
                    Console.WriteLine("Bandits attack you out of nowhere. They seem very dangerous... \n  * -20 health");
                    healthSubstract = 20;
                    break;
                case 2:
                    Console.WriteLine("You bump in to one of the guards of the nearby village. They attack you without warning... \n * - 30 health");
                    healthSubstract = 30;
                    break;
                case 3:
                    Console.WriteLine("A Land Shark appears. It starts chasing you down to eat you... \n * - 50 health");
                    healthSubstract = 50;
                    break;
                case 4:
                    Console.WriteLine("You accidentally step on a rat. His friends are not happy. They attack... \n * - 10 health");
                    healthSubstract = 10;
                    break;
                case 5:
                    Console.WriteLine("You find a huge rock. It comes alive somehow and tries to smash you... \n * - 30 health");
                    healthSubstract = 30;
                    break;
                default:
                    break;
            }
            return healthSubstract;
        }

        
    }

}
