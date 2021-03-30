using System;

namespace BonusTask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string addAnotherNumber = "Y";
            int smallestNumber = int.MaxValue, secondSmallestNumber = int.MaxValue;

            while (addAnotherNumber == "Y")
            {
                Console.WriteLine("Enter number: ");
                bool successfulParse = int.TryParse(Console.ReadLine(), out int parsedNumber);

                if (successfulParse)
                {
                    if (parsedNumber < smallestNumber)
                    {
                        secondSmallestNumber = smallestNumber;
                        smallestNumber = parsedNumber;
                    }
                    else if (parsedNumber < secondSmallestNumber)
                    {
                        secondSmallestNumber = parsedNumber;
                    }
                }
                else
                { Console.WriteLine("Wrong number"); }


                Console.WriteLine("To add another number write Y");
                addAnotherNumber = Console.ReadLine();
            }

            Console.WriteLine("The second smallest number is : "+ secondSmallestNumber);

        }
    }
}
