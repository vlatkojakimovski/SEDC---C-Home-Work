using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentsG1 = { "Zdravko", "Petko", "Stanko", "Branko", "Trajko" };
            string[] studentsG2 = { "Vlatko", "Risto", "Bate Vane", "Baze", "Artur" };

            Console.WriteLine("Enter 1 to print G1 or 2 to print G2 " );
            string printG1OrG2 = Console.ReadLine();

            if (printG1OrG2 == "1")
            {
                Console.WriteLine("The students in G"+ printG1OrG2 + " are:");
                foreach (string name in studentsG1)
                {
                    Console.WriteLine(name);
                }
            }
            else if (printG1OrG2 == "2")
            {
                Console.WriteLine("The students in G" + printG1OrG2 + " are:");
                foreach (string name in studentsG2)
                {
                    Console.WriteLine(name);
                }
            }
            else
                Console.WriteLine("Wrong input !!!");
        }
    }
}
