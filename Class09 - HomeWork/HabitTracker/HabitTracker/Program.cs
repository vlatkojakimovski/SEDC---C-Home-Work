using HabitTracker.Class;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabitTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>() {
                new User("Vlatko", "Vlatko123@", "Vlatko", "Jakimovski", new DateTime(1988,02,09)),
                 new User("Petko", "Petko123@", "Petko ", "Petkovski", new DateTime(2001,05,01)),
            };
            //StatisticsMenu();
            List<Habit> habitsList = new List<Habit>()
            {
                new Habit("Trcanje", EnumHabitGroup.ExerciseAndSport, EnumHabitDificulty.Medium, EnumGoodBad.Good, new DateTime(2021,04,30) , true),
                new Habit("Odmaranje", EnumHabitGroup.HomeAndPersonal, EnumHabitDificulty.Hard, EnumGoodBad.Bad, new DateTime(2021,05,01), false)
            };


            users[0].UserHabit = habitsList;
            void StartApp()
            {
                string choice = ChoiceLoginRegister();
                switch (choice)
                {
                    case "1":
                        User loggedUser = LoggedUserReturn(users);
                        if (loggedUser == null)
                        {
                            Console.WriteLine("You have 3 unsuccessfull attempts to log in. Closing program ... ");
                            System.Environment.Exit(0);
                        }

                        UIMenu();
                        void UIMenu() {
                            Console.Clear();
                            GreenConsoleColor();
                            Console.WriteLine($"Logg in Successfull \n Welcome {loggedUser.FirstName} \n\n");
                            choice = ChoiceHabitsStatsEditAcc();
                            switch (choice)
                            {
                                case "1":
                                    Console.Clear();
                                    choice = ChoiceDailySingle();
                                    switch (choice)
                                    {
                                        case "1":
                                            Console.Clear();
                                            loggedUser.DailyStatistics();
                                            UIMenu();
                                            break;
                                        case "2":
                                            Console.Clear();
                                            loggedUser.DailyStatistics();
                                            UIMenu();
                                            break;
                                        case "0":
                                            Console.Clear();
                                            loggedUser = null;
                                            UIMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    PrintStatistics();
                                    void PrintStatistics()
                                    {
                                        Console.Clear();
                                        choice = ChoiceStats();
                                        switch (choice)
                                        {
                                            case "1":
                                                loggedUser.GoodHabitStatistics();
                                                PrintStatistics();
                                                break;
                                            case "2":
                                                loggedUser.BadHabitStatistics();
                                                PrintStatistics();
                                                break;
                                            case "3":
                                                loggedUser.WeeklyHabitStatistics();
                                                PrintStatistics();
                                                break;
                                            case "4":
                                                loggedUser.AllStatistics();
                                                PrintStatistics();
                                                break;
                                            case "5":
                                                Console.Clear();
                                                loggedUser.GoodHabitStatistics();
                                                loggedUser.BadHabitStatistics();
                                                loggedUser.WeeklyHabitStatistics();
                                                loggedUser.AllStatistics();

                                                PrintStatistics();
                                                break;

                                            case "0":
                                                ChoiceHabitsStatsEditAcc();
                                                /*UIMenu()*/
                                                ;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    break;
                                case "3":
                                    EditAccountVoid();
                                    void EditAccountVoid()
                                    {
                                        while (true)
                                        {
                                            choice = ChoiceEditAccount();
                                            switch (choice)
                                            {
                                                case "1":
                                                    Console.Clear();
                                                    habitsList.Add(CreateHabit());
                                                    EditAccountVoid();
                                                    break;
                                                case "2":
                                                    Console.Clear();
                                                    Console.WriteLine("All Habits: \n");
                                                    RemoveHabit(loggedUser);
                                                    EditAccountVoid();
                                                    break;
                                                case "3":
                                                    EditUserInfo(ref loggedUser);
                                                    EditAccountVoid();
                                                    break;
                                                case "4":
                                                    //EditUserInfo(loggedUser);
                                                    //EditAccountVoid();
                                                    ChangePassword(loggedUser);
                                                    break;
                                                case "0":
                                                    UIMenu();
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }

                                    break;
                                case "0":
                                    StartApp();
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;
                    case "2":
                        Console.Clear();
                        User newUser = CreateUser();
                        if (newUser != null)
                        {
                            users.Add(newUser);
                        }
                        StartApp();
                        break;
                    case "0":
                        Console.Clear();
                        loggedUser = null;
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            StartApp();


        }
        // ///////////  MENUS  ///////////////////////
        #region MENU
        static void LoginRegisterMenu()
        {
            WhiteConsoleColor();
            Console.WriteLine("Habit Tracker Welcome ! \n");
            Console.WriteLine("1) Log In");
            Console.WriteLine("2) Register ");
            ExitMenu();


        }

        static void ExitMenu()
        {
            RedConsoleColor();
            Console.WriteLine("\n\n\n 00 (Exit)");
        }

        static void LogOutExitMenu()
        {
            RedConsoleColor();
            Console.WriteLine("\n\n\n 0 Log Out");
            Console.WriteLine("00 (Exit)");
        }

        static void HabitStatisticEditAccMenu()
        {
            BlueConsoleColor();
            Console.WriteLine("1) Habits");
            Console.WriteLine("2) Statistics");
            Console.WriteLine("3) Edit Account");
            LogOutExitMenu();
        }

        static void DailySingleHabitLogMenu()
        {
            Console.Clear();
            YellowConsoleColor();
            Console.WriteLine( "0 (Go Back)");
            BlueConsoleColor();
            Console.WriteLine("1) Daily Log");
            Console.WriteLine("2) Single Log");
        }

        static void StatisticsMenu()
        {
            BlueConsoleColor();
            Console.WriteLine($"{"1) Good",-15} {"habits",-10}");
            Console.WriteLine($"{"2) Bad",-15} {"habits",-10}");
            Console.WriteLine($"{"3) Weekly",-15} {"Statistics",-10}");
            Console.WriteLine($"4) All Time Statistics");
            Console.WriteLine($"5) ----- ALL STATISTICS -----");

        }

        static void EditAccountMenu()
        {
            Console.Clear();
            BlueConsoleColor();
            Console.WriteLine($"{"1) Add",-15} {"habit",-10}");
            Console.WriteLine($"{"2) Remove",-15} {"habit",-10}");
            Console.WriteLine($"{"3) Edit",-15} {"Info",-10}");
            Console.WriteLine($"{"4) Change",-15} {"Password",-10}");
        }

        #endregion

        // //////////   Console COLORS  ////////////
        static void YellowConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        static void BlueConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static void GreenConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void RedConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void WhiteConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }


        #region USER manipulation
        static User CreateUser()
        {
            while (true)
            {
                Console.WriteLine("Enter Username : ");
                string userName = Console.ReadLine();
                if (!UserNameValidCheck(userName))
                    continue;
                if (userName == "0")
                    return null;

                Console.WriteLine("Enter Password : ");
                string password = Console.ReadLine();
                if (!PasswordValidCheck(password))
                    continue;
                if (password == "0")
                    return null;

                Console.WriteLine("Enter First Name : ");
                string firstName = Console.ReadLine();
                if (!FirstNameLastNameCheck(firstName))
                    continue;
                if (firstName == "0")
                    return null;

                Console.WriteLine("Enter Last Name : ");
                string lastName = Console.ReadLine();
                if (!FirstNameLastNameCheck(lastName))
                    continue;
                if (lastName == "0")
                    return null;

                Console.WriteLine("Enter Date of Birth : ");
                string dateOfBirth = Console.ReadLine();
                if (!AgeCalculator(dateOfBirth))
                    continue;
                if (dateOfBirth == "0")
                    return null;

                bool successfullParsed = DateTime.TryParse(dateOfBirth, out DateTime parsedBirthDate);

                Console.WriteLine("User Successfully created !");

                return new User(userName, password, firstName,lastName, parsedBirthDate);
            }

        }

        static void EditUserInfo(ref User user)
        {
            Console.WriteLine("Enter new value for first name: \n");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter new value for last name: \n");
            string lName = Console.ReadLine();
            if (FirstNameLastNameCheck(fName) && FirstNameLastNameCheck(lName))
            {
                user.FirstName = fName;
                user.LastName = lName;
                Console.WriteLine($"You have changed your First name and Last name: ");
                Console.WriteLine($"Now First Name is: {user.FirstName}, and Last Name is: {user.LastName} ");

            }
            else
            {
                Console.WriteLine("Wrong input for first name or last name !!!");            
            }

        }

        static void ChangePassword(User user)
        {
            Console.WriteLine("Enter your old password first");
            string oldPassword = Console.ReadLine();
            Console.WriteLine("Enter new password");
            string newPassword = Console.ReadLine();
            if (PasswordValidCheck(oldPassword) && PasswordValidCheck(newPassword))
            {
                Console.WriteLine("Password successfuly changed ! \n Press 'ENTER' to continue ... ");
                user.Password = newPassword;
                Console.ReadLine();
                Console.Clear();
            }else
            {
                Console.WriteLine("Invalid old or new password, \n Password must be at least 6 chars and contain a number!");
                Console.WriteLine("Press 'ENTER' and try again ...");
                Console.ReadLine();
                Console.Clear();
            }

        }
        #endregion


        #region HABIT region
        static Habit CreateHabit()
        {
            Console.WriteLine("\n Enter habit title");
            string name = Console.ReadLine();
            string dificulty = "";
            while (dificulty != "1" && dificulty != "2" && dificulty != "3")
            {
                Console.WriteLine("Enter habit dificulty 1 (low), 2 (medium) or 3 (hard)");
                dificulty = Console.ReadLine();
            }
            string type = "";
            while (type != "1" && type !="2")
            {
                Console.WriteLine("Enter habit type 1 (good) or 2 (bad)");
                type = Console.ReadLine();
            }
            int group = -1;
            while (group < 1 || group > 6)
            {
                Console.WriteLine("Enter habit group ");
                Console.WriteLine("1 (ExerciseAndSport) ");
                Console.WriteLine("2 (StudyAndLearning) ");
                Console.WriteLine("3 (ActivitieasAndHobbies) ");
                Console.WriteLine("4 (WorkAndCareer) ");
                Console.WriteLine("5 (HomeAndPersonal) ");
                Console.WriteLine("6 (Other) ");
                group = int.Parse(Console.ReadLine());
            }
            DateTime date= new DateTime(1900,1,1);
            Console.WriteLine("Enter habit Date");
            bool parsedDate = DateTime.TryParse(Console.ReadLine(), out DateTime dateParsedSuccess);
            if (parsedDate)
            {
                date = dateParsedSuccess;
            } else
            {
                Console.WriteLine("Please enter valid data format, Ex: 2020/03/24");
                Console.WriteLine("Press 'ENTER' and try again ...");
                Console.ReadLine();
                CreateHabit();
            }

            int dificultyInt = int.Parse(dificulty);
            int typeInt = int.Parse(type);

            Habit temp = new Habit(name, (EnumHabitGroup)group, (EnumHabitDificulty)dificultyInt, (EnumGoodBad)typeInt, date, false);
            return temp;
        }

        static void RemoveHabit (User user)
        {
            foreach (Habit item in user.UserHabit)
            {
                item.PrintHabit();
            }
            Console.WriteLine("Enter Habit title to remove: \n");
            string habitTitle = Console.ReadLine();
            for (int i=0; i < user.UserHabit.Count; i++)
            {
                if (user.UserHabit[i].Name.Equals(habitTitle, StringComparison.InvariantCultureIgnoreCase))
                {
                    user.UserHabit.RemoveAt(i);
                    Console.WriteLine("Habit successfully deleted.");
                    break;
                }
            }
        }
        #endregion

        #region USER Valid check
        static bool UserNameValidCheck(string userName)
        {
            if (userName.Length >= 6 && !char.IsDigit(userName[0]))
            {
                return true;
            }
            return false;
        }

        static bool PasswordValidCheck(string pass)
        {
            if (pass.Length >= 6 && pass.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        static bool FirstNameLastNameCheck(string str)
        {
            if (str.Length >= 2 && !str.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        static bool AgeCalculator(string birthDate)
        {
            bool successfulDateStringParse = DateTime.TryParse(birthDate, out DateTime parsedBirthDate);

            if (successfulDateStringParse)
            {
                int birthMonth = parsedBirthDate.Month;
                int birthDay = parsedBirthDate.Day;
                int todayMonth = DateTime.Now.Month;
                int todayDay = DateTime.Now.Day;

                int ageReturn = (DateTime.Now.Year - parsedBirthDate.Year) - 1;
                if (todayMonth > birthMonth)
                {
                    ageReturn++;
                }
                else if (todayMonth == birthMonth && todayDay > birthDay)
                {
                    ageReturn++;
                }
                if (ageReturn >= 5 && ageReturn <= 122)
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Please enter correct YEAR-MONTH-DAY (year/month/day) format, age must be between 5 and 122. \n Ex: 1992/2/28 \n  Press 'ENTER' and try again...");
            }

            return false;
        }


        static User LoggedUserReturn(List<User> users)
        {
            int loginCounter = 3;
            while (loginCounter > 0)
            {

                WhiteConsoleColor();
                Console.WriteLine("Enter Username : ");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter Password : ");
                string userPassword = Console.ReadLine();

                User loggedUser = users.FirstOrDefault(x => x.Login(userName, userPassword) != null);

                if (loggedUser == null)
                {
                    Console.WriteLine("Invalid Username or Password!");
                    Console.WriteLine("If you don't have an account, register before logging in ! \n \n  ");
                    Console.WriteLine($"Number of tries left: {--loginCounter}! ");
                    Console.WriteLine("Press ENTER and try again ...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                loginCounter = 3;
                return loggedUser;


            }
            return null;
        }

        #endregion

        ///////////// CHOICES  MENUS ////////////////
        #region CHOICES MENU

        static string ChoiceLoginRegister()
        {
            while (true)
            {
                LoginRegisterMenu();
                string userChoice = "";
                userChoice = Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice != "0")
                {
                    Console.WriteLine("Please choose either 1, 2 or 3. \n Press ENTER and try again...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                return userChoice;
            }
        }
        static string ChoiceHabitsStatsEditAcc ()
        {
            while (true)
            {
                HabitStatisticEditAccMenu();
                string userChoice = "";
                userChoice =  Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "0")
                {
                    Console.WriteLine("Please choose either 1, 2 or 3. \n Press ENTER and try again...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                return userChoice;
            }
        }

        static string ChoiceDailySingle ()
        {
            Console.Clear();
            while (true)
            {
                DailySingleHabitLogMenu();
                string userChoice = "";
                userChoice = Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice !="0")
                {
                    Console.WriteLine("Please choose either 1 or 2. \n Press ENTER and try again...");
                    Console.ReadLine();
                    Console.Clear();
                    if (userChoice == "0")
                    {
                        ChoiceHabitsStatsEditAcc();
                    }
                    continue;
                }
                return userChoice;
            }
        }

        static string ChoiceStats ()
        {
            while (true)
            {
                StatisticsMenu();
                string userChoice = "";
                userChoice = Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4" && userChoice != "5" && userChoice != "0" )
                {
                    Console.WriteLine("Please choose either 1, 2 or 3. \n Press ENTER and try again...");
                    Console.ReadLine();
                    Console.Clear();
                    if (userChoice == "0")
                    {
                        ChoiceHabitsStatsEditAcc();
                    }
                    continue;
                }
                return userChoice;
            }
        }

        static string ChoiceEditAccount()
        {
            ExitMenu();
            LogOutExitMenu();
            while (true)
            {
                EditAccountMenu();
                string userChoice = "";
                userChoice = Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4" && userChoice != "0")
                {
                    Console.WriteLine("Please choose either 1, 2, 3 or 4. \n Press ENTER and try again...");
                    Console.ReadLine();
                    Console.Clear();
                    if (userChoice == "0")
                    {
                        ChoiceHabitsStatsEditAcc();
                    }
                    continue;
                }
                return userChoice;
            }
        }
        #endregion

    }
}