using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_Class08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Queue<int> queueNumbers = new Queue<int>();
            Stack<int> stackNumbers = new Stack<int>();
            List<int> listNumbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter the number");
                string anotherNumber = "";
                bool successfullParsed = int.TryParse(Console.ReadLine(), out int parsedNumber);
                if (successfullParsed)
                {
                    queueNumbers.Enqueue(parsedNumber);
                    stackNumbers.Push(parsedNumber);
                    listNumbers.Add(parsedNumber);

                    Console.WriteLine("Enter Y if you want to add another number");
                    anotherNumber = Console.ReadLine();
                } else
                {
                    Console.WriteLine("Wrong input !!!");
                    Console.WriteLine("Enter Y if you want to add another number");
                    anotherNumber = Console.ReadLine();
                }
                if (anotherNumber.ToLower() != "y")
                    break;
            }

            stackNumbers = StackTransforming(stackNumbers);

            PrintCollection(queueNumbers);
            PrintCollection(stackNumbers);
            PrintCollection(listNumbers);

        }

        static void PrintCollection(IEnumerable collection)
        {
            foreach (object item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }

        static Stack<int> StackTransforming (Stack<int> st)
        {
            Stack<int> tempStack = new Stack<int>();
            foreach (int item in st)
            {
                tempStack.Push(item);
            }
            return tempStack;
        }
    }
}
