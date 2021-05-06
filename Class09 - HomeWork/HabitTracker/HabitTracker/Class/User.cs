using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Class
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int FailedLoginAttempts { get; set; }
        DateTime DateOfBirth { get; set; }

        public List<Habit> UserHabit = new List<Habit>();

        public User()
        {

        }

        public User(string userName, string password, string firstName, string lastName, DateTime dateOfBirth)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            FailedLoginAttempts = 0;
        }

        public void DailyStatistics ()
        {
            void Print()
            {
                Console.Clear();
                Console.WriteLine("All Habits:  \n\n");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Good Habits: \n");
                Console.ForegroundColor = ConsoleColor.White;


                foreach (Habit item in UserHabit)
                {
                    if (item.Type == EnumGoodBad.Good)
                    {
                        item.PrintHabit();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" \n Bad Habits: \n");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Habit item in UserHabit)
                {
                    if (item.Type == EnumGoodBad.Bad)
                    {
                        item.PrintHabit();
                    }
                }
            }
            Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter Habit title");
            string habitTitle = Console.ReadLine();
            Habit temp = UserHabit.FirstOrDefault(x => x.Name == habitTitle);
            if (temp == null)
            {
                Console.WriteLine($"There is no habit with title {habitTitle} \n Press Enter to continue");
                Console.ReadLine();
            } else
            {
                Console.WriteLine($"Add record for habit {temp.Name}. Current completion: {temp.Completed} \n Your completion true or false: ");
                string completionNew = Console.ReadLine();
                if (completionNew == "true")
                {
                    temp.Completed = true;
                }
                else if (completionNew == "false")
                {
                    temp.Completed = false;
                }
                else
                {
                    Console.WriteLine("WRONG INPUT !!! Press ENTER and try again");
                    Console.ReadLine();
                    DailyStatistics();
                }

            }
            Print();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress 'ENTER' to continue . . . ");
            Console.ReadLine();
        }


        public void GoodHabitStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good Habits: \n ");
            Console.ForegroundColor = ConsoleColor.White;


            List<Habit> goodHabits = GetGoodHabits();
  
            for (int i = 0; i < goodHabits.Count; i++)
            {
                goodHabits[i].PrintHabit();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total Good Habits Completed: {goodHabits.Select(x => x.Completed == true).Count()}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            
        }

        public void BadHabitStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bad Habits ");
            Console.ForegroundColor = ConsoleColor.White;


            List<Habit> badHabits = GetBadHabits();

            for (int i = 0; i < badHabits.Count; i++)
            {
                badHabits[i].PrintHabit();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total Good Habits Completed: {badHabits.Select(x => x.Completed == true).Count()}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        public void WeeklyHabitStatistics()
        {
            int completedHabits = UserHabit.Where(x => x.Completed == true).Count();
            int missedHabits = UserHabit.Where(x => x.Completed == false).Count();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Statistics about completed | missed  Habits during the weekend \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Completted: {completedHabits}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Missed: {missedHabits}");

            Console.WriteLine("Press 'ENTER' to continue ...");
            Console.ReadLine();
        }

        public void AllStatistics()
        {
            int completedHabits = UserHabit.Where(x => x.Completed == true).Count();
            int missedHabits = UserHabit.Where(x => x.Completed == false).Count();
            int percent = 100 / (completedHabits + missedHabits);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"All time Statistics, percentage of completed vs missed habits.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Completed: {completedHabits*percent} %");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Missed: {missedHabits * percent} %");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press 'Enter' to continue ...");
            Console.Read();

        }

        public User Login(string username, string password)
        {
            if (UserName == username && Password == password)
            {
                return this;
            }

            if (Password != password)
            {
                FailedLoginAttempts++;
                return null;
            }

            FailedLoginAttempts = 0;

            return this;
        }

       
        public List<Habit> GetGoodHabits()
        {
            List<Habit> goodHabits = UserHabit.Where(x => x.Type == EnumGoodBad.Good).Select(x => (Habit) x).ToList();

            return goodHabits;
        }
        public List<Habit> GetBadHabits()
        {
            List<Habit> badHabits = UserHabit.Where(x => x.Type == EnumGoodBad.Bad).Select(x => (Habit)x).ToList();

            return badHabits;
        }


    }
}
