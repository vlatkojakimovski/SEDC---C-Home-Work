using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Class
{
    public class Habit
    {


        public string Name { get; set; }

        public EnumHabitGroup Group {get; set;}

        public EnumHabitDificulty Dificulty { get; set; }

        public EnumGoodBad Type { get; set; }

        public DateTime Recorded { get; set; }
        public bool Completed { get; set; }

        public Habit(string name, EnumHabitGroup group, EnumHabitDificulty dificulty, EnumGoodBad type, DateTime recorded, bool completed)
        {
            Name = name;
            Group = group;
            Dificulty = dificulty;
            Type = type;
            Recorded = recorded;
            Completed = completed;
        }

        public Habit()
        {

        }

        public void PrintHabit ()
        {
            Console.WriteLine($"Habit Title: {Name}");
            Console.WriteLine($"Group: {Group}");
            Console.WriteLine($"Difficulty: {Dificulty}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Date: {Recorded}");
            Console.WriteLine($"Completed: {Completed}");
        }
    }
}
