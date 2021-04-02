using System;

namespace Exercise_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringSentence = "Hello from SEDC Codecademy 2021";

            Console.WriteLine("How many characters you want to print form the string ? ");
            string numberInput = Console.ReadLine();
            bool successfulParse = int.TryParse(numberInput, out int parsedNumber);

            if (successfulParse)
            {
                Substring(stringSentence, parsedNumber);
            } else
            {
                Console.WriteLine("You have entered wrong input !");
            }
        }

        static void Substring(string str, int numbCharacters)
        {
            if (str.Length >= numbCharacters && numbCharacters > 0)
            {
                Console.WriteLine( str.Substring(0, numbCharacters));
            } else
            {
                Console.WriteLine("The sentence does not have that much characters or you have entered number below 0 !!! ");
            }
        }
    }
}
