using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrOfNumbers = new int[6];
            int sum = 0;
            for (int i = 0; i < arrOfNumbers.Length; i++)
            {
                Console.WriteLine("Enter integer no. " + (i+1) + ": ");
                bool successfulParse = int.TryParse(Console.ReadLine(), out int parsedNumber);
                if (successfulParse)
                {
                    arrOfNumbers[i] = parsedNumber;
                    if (parsedNumber % 2 == 0)
                    {
                        sum += parsedNumber;
                    }
                }
                else
                {
                    Console.WriteLine("This is not valid integer number !!!");
                    i--;
                }
            }

            Console.WriteLine("Sum of ell even numbers is: " + sum);
        }
    }
}
