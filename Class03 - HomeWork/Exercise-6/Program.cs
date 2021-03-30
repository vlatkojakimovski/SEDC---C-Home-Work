using System;

namespace Exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] arrayNames = new string[1];
            string addAnotherNameY = "Y";
            int counter = 0;

            while (addAnotherNameY == "Y")
            {
                Console.WriteLine("Enter name: ");
                arrayNames[counter] = Console.ReadLine();

                Console.WriteLine("To add another name write Y");
                addAnotherNameY = Console.ReadLine();

                if (addAnotherNameY == "Y")
                {
                    counter++;
                    Array.Resize(ref arrayNames, counter + 1);
                    continue;
                }
                else break;
            }

            for (int i = 0; i < arrayNames.Length; i++)
            {
                Console.WriteLine("Name "+ i + ": " + arrayNames[i]);
            }


        }
    }
}
