using System;
using Task_01.Class;
using Task_01.Classes;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver firstDriver = new Driver("Bob", 20);
            Driver secondDriver = new Driver("Greg", 16);
            Driver thirdDriver = new Driver("Jill", 12);
            Driver fourthDriver = new Driver("Anne", 8);
            Driver[] driversArray = new Driver[] { firstDriver, secondDriver, thirdDriver, fourthDriver };

            Car firstCar = new Car("Hyundai", 56);
            Car secondCar = new Car("Mazda", 68);
            Car thirdCar = new Car("Ferrari", 46);
            Car fourthCar = new Car("Porsche", 77);
            Car[] carsArray = new Car[] { firstCar, secondCar, thirdCar, fourthCar };

            Car[] raceCarsArr = new Car[2];
            Driver[] raceDriversArr = new Driver[2];

            int firstSelectedCar ;
            int secondSelectedCar ;

            int firstSelectedDriver ;
            int secondSelectedDriver ;


            void pickCarDriver()
            {
                firstSelectedCar = -1;
                secondSelectedCar = -1;

                firstSelectedDriver = -1;
                secondSelectedDriver = -1;

                Console.WriteLine("Select car No.1 ?");
                printCars(carsArray, firstSelectedCar-1);
                //firstSelectedCar = int.Parse(Console.ReadLine());
                bool successfulParseFirstCar = int.TryParse(Console.ReadLine(), out int firstSelectedCarOut);
                Console.WriteLine( checkInput(successfulParseFirstCar, firstSelectedCarOut, firstSelectedCar));
                raceCarsArr[0] = carsArray[firstSelectedCarOut - 1];

                Console.WriteLine("Select driver ?");
                printDrivers(driversArray, firstSelectedDriver-1);
                //firstSelectedDriver = int.Parse(Console.ReadLine());
                bool successfulParseFirstDriver = int.TryParse(Console.ReadLine(), out int firstSelectedDriverOut);
                raceDriversArr[0] = driversArray[firstSelectedDriverOut - 1];

                raceCarsArr[0].driver = raceDriversArr[0];

                Console.WriteLine("Select car No.2 ?");
                printCars(carsArray, firstSelectedCar-1);
                //secondSelectedCar = int.Parse(Console.ReadLine());
                bool successfulParseSecondCar = int.TryParse(Console.ReadLine(), out int secondSelectedCarOut);
                raceCarsArr[1] = carsArray[secondSelectedCarOut - 1];

                Console.WriteLine("Select driver ?");
                printDrivers(driversArray, firstSelectedDriver-1);
                //secondSelectedDriver = int.Parse(Console.ReadLine());
                bool successfulParseSecondDriver = int.TryParse(Console.ReadLine(), out int secondSelectedDriverOut);
                raceDriversArr[1] = driversArray[secondSelectedDriverOut - 1];

                raceCarsArr[1].driver = raceDriversArr[1];

                RaceCars(raceCarsArr[0], raceCarsArr[1]);
            }

            bool checkInput (bool input, int inputNumber, int selectedCarDriver)
            {
                if (input && inputNumber >= 0 && inputNumber <= 4 && inputNumber != selectedCarDriver)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            pickCarDriver();

            Console.WriteLine("Another race ?  Y/N ?");
            string anotherRace = Console.ReadLine();

            while (anotherRace == "Y" || anotherRace == "y")
            {
                pickCarDriver();
                Console.WriteLine("Another race ?  Y/N ?");
                anotherRace = Console.ReadLine();
            }


        }

        static void RaceCars(Car one, Car two)
        {
            if (one.CalculateSpeed() > two.CalculateSpeed())
            {
                Console.WriteLine($"On this RACE winner is {one.driver.Name} with car model {one.Model} and speed {one.CalculateSpeed()}");
            }
            else
            {
                Console.WriteLine($"On this RACE winner is {two.driver.Name} with car model {two.Model} and speed {two.CalculateSpeed()}");
            }
        }

        static void printCars(Car[] arr, int selected)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (selected == i)
                    continue;
                Console.WriteLine($"{i+1}. {arr[i].Model}");
            }
        }

        static void printDrivers(Driver[] arr, int selected)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (selected == i)
                    continue;
                Console.WriteLine($"{i+1}. {arr[i].Name}");
            }
        }
    }
}
