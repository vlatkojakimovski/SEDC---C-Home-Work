using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth date in format: dd/mm/yyy !");
            string dateInput = Console.ReadLine();
            if (AgeCalculator(dateInput) != 0)
            {
                Console.WriteLine($"You are {AgeCalculator(dateInput)} years old");
            }
        }

        static int AgeCalculator (string birthDate)
        {
            bool successfulDateStringParse = DateTime.TryParse(birthDate, out DateTime parsedBirthDate);

            if (successfulDateStringParse )
            {
                int birthMonth = parsedBirthDate.Month;
                int birthDay = parsedBirthDate.Day;
                int todayMonth = DateTime.Now.Month;
                int todayDay = DateTime.Now.Day;

                int ageReturn = (DateTime.Now.Year - parsedBirthDate.Year)-1;
                if (todayMonth > birthMonth)
                {
                    ageReturn++;
                }
                else if (todayMonth == birthMonth && todayDay > birthDay)
                {
                    ageReturn++;
                }
                return ageReturn;
            }
            else
            {
                Console.WriteLine("You have entered wrong input !!!");  
            }
            return 0;
        }
    }
}
