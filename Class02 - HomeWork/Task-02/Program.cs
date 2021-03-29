using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number for variable A ");
            string variableA = Console.ReadLine();
            Console.WriteLine("Please enter number for variable B ");
            string variableB = Console.ReadLine();
            Console.WriteLine("Please enter number for variable C ");
            string variableC = Console.ReadLine();
            Console.WriteLine("Please enter number for variable D ");
            string variableD = Console.ReadLine();
            bool successfulConversionA = double.TryParse(variableA, out double dblVariableA);
            bool successfulConversionB = double.TryParse(variableB, out double dblVariableB);
            bool successfulConversionC = double.TryParse(variableC, out double dblVariableC);
            bool successfulConversionD = double.TryParse(variableD, out double dblVariableD);

            Console.WriteLine("Average number is: " + ((dblVariableA + dblVariableB + dblVariableC + dblVariableD) / 4));
        }
    }
}
