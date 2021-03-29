using System;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number for variable A ");
            string variableA = Console.ReadLine();
            Console.WriteLine("Please enter number for variable B ");
            string variableB = Console.ReadLine();
            bool successfulConversionA = int.TryParse(variableA, out int intVariableA);
            bool successfulConversionB = int.TryParse(variableB, out int intVariableB);
            Console.WriteLine("Number A = " + intVariableA);
            Console.WriteLine("Number B = " + intVariableB);

            swapNumbers(intVariableA, intVariableB);
        }

        static void swapNumbers(int a, int b)
        {
            Console.WriteLine("SWAPPING ...");
            int pom = 0;

            pom = a;
            a = b;
            b = pom;
            Console.WriteLine("Number A = " + a);
            Console.WriteLine("Number B = " + b);


        }
    }
}
