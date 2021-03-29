using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number for variable A ");
            string variableA = Console.ReadLine();
            Console.WriteLine("Please enter number for variable B ");
            string variableB = Console.ReadLine();
            bool successfulConversionA = double.TryParse(variableA, out double intVariableA);
            bool successfulConversionB = double.TryParse(variableB, out double intVariableB);
            Console.WriteLine("Please enter operation:  +   -   *   /  ");
            string calculateOperator = Console.ReadLine();

            if (calculateOperator == "+" || calculateOperator == "-" || calculateOperator == "*" || calculateOperator == "/")
            {
                switch (calculateOperator)
                {
                    case "+":
                        Console.WriteLine(intVariableA + intVariableB);
                        break;
                    case "-":
                        Console.WriteLine(intVariableA - intVariableB);
                        break;
                    case "*":
                        Console.WriteLine(intVariableA * intVariableB);
                        break;
                    case "/":
                        Console.WriteLine(intVariableA / intVariableB);
                        break;
                    default:
                        break;
                }
            }
            else Console.WriteLine("Wrong Input !!!");
        }
    }
}
