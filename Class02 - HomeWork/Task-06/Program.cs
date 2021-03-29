using System;

namespace Task_06
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

            if (successfulConversionA && successfulConversionB)
            {
                largeNumber(intVariableA, intVariableB);
            }

        }
        static int largeNumber(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine("Number A:" + a + "is larger then number B:" + b);
                testEvenOdd(a);
                return a;
            }
            else if (b > a)
            {
                Console.WriteLine("Number B:" + b + "is larger then number A:" + a);
                testEvenOdd(b);
                return b;
            }
            else
            {
                Console.WriteLine("The numbers are equal: " + a + " = " + b);
                return 0;
            }
        }

        static void testEvenOdd(int a)
        {
            if (a % 2 == 0)
            {
                Console.WriteLine("The number " + a + " is EVEN");
            }
            else
            {
                Console.WriteLine("The number " + a + " is ODD");
            }
        }



    }
}
