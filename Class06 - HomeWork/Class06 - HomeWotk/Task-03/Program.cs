using System;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Atm AtmMachine = new Atm();

            AtmMachine.AddCustomer(new Customer("Vlatko", 3333333333333333, 36000, 1234));
            AtmMachine.AddCustomer(new Customer("Irena", 3254125236552311, 36000, 1234));
            AtmMachine.AddCustomer(new Customer("Pero", 1654125236552311, 36000, 1234));
            AtmMachine.AddCustomer(new Customer("Stanko", 9854125236552311, 36000, 1234));

            AtmMachine.customers[0].CacheWithdrawal(12000);
            AtmMachine.printCustomers();

            void login()
            {
                while (true)
                {
                    Console.WriteLine("Please insert your card ");
                    string cardInserted = Console.ReadLine();
                    long CardInsertedLong = AtmMachine.ConvertCardNumberToLongCard(cardInserted);
                    int customerPosition;

                    if (CardInsertedLong != -1)
                    {
                        customerPosition = AtmMachine.FindCustomerPositionByCardNumber(AtmMachine.customers, CardInsertedLong);
                    }
                    else
                    {
                        Console.WriteLine("Wrong card number ! Try again ...");
                        //Console.WriteLine("This card is not registered yet. Do you want to register now? Pres 1 to register");
                        //string registerCardChose = Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"Hello {AtmMachine.customers[customerPosition].Name} Please insert your PIN ?");
                    int tempPin = convertStringToInt(Console.ReadLine());
                    if (tempPin != -1)
                    {
                        if (tempPin == AtmMachine.customers[customerPosition].GetPin())
                        {
                            Console.WriteLine("Successfull card and PIN");
                            userTransactions(customerPosition);
                        }
                    }
                    else
                    {
                        Console.WriteLine("WRONG PIN !!!");
                        continue;
                    }

                }
            }

            void userTransactions(int position)
            {
                Console.WriteLine("ATM Machine 2021 - SKOPJE \n Please select option: \n 1. Check Balance \n 2. Cash Withdrawal \n 3. Cash Deposit \n 4. Register new card");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        string temAmountBalance = AtmMachine.customers[position].ConvertCurrency(AtmMachine.customers[position].GetBalance());
                        Console.WriteLine($"You have  {temAmountBalance}");
                        //userTransactions(position);
                        break;
                    case "2":
                        Console.WriteLine("Add amount to withdrow");
                        int withdrawAmount = convertStringToInt(Console.ReadLine());
                        AtmMachine.customers[position].CacheWithdrawal(withdrawAmount);
                        //userTransactions(position);
                        break;
                    case "3":
                        Console.WriteLine("Input deposit amount");
                        int depositSum = convertStringToInt(Console.ReadLine());
                        if (depositSum >0)
                        {
                            AtmMachine.customers[position].CacheDeposit(depositSum);
                        } else
                        {
                            Console.WriteLine("Wrong deposit input !!!");
                            userTransactions(position);
                            break;
                        }
                        break;
                    case "4":
                        registerCard(AtmMachine);
                        login();
                        break;
                    default:
                        Console.WriteLine("Wrong input !!!");
                        break;
                }
                Console.WriteLine("Do you want another transaction ? 1 = Yes 2 = No");
                if (Console.ReadLine() == "1")
                {
                    userTransactions(position);
                }
                Console.WriteLine("Thank you for using our bank :) ");
                login();
            }

            login(); 
        }

        static void registerCard(Atm atm)
        {
            Console.WriteLine("Insert your card in format  XXXX-XXXX-XXXX-XXXX");
            string tempCard = Console.ReadLine();
            long tempCardLong = atm.ConvertCardNumberToLongCard(tempCard);
            if (tempCardLong != -1)
            {
                if (atm.FindCustomerPositionByCardNumber(atm.customers ,tempCardLong) == -1)
                {
                    Console.WriteLine("Please enter your name:");
                    string tempName = Console.ReadLine();
                    int pin;
                    Console.WriteLine("Please enter your PIN:");

                    while (true)
                    {
                        int pinInput = convertStringToInt(Console.ReadLine());
                        if (pinInput != -1)
                        {
                            pin = pinInput;
                            break;
                        }
                        Console.WriteLine("You must enter pin with numbers only !!! Please enter Pin again:");
                    }
                    Customer tempCustomer = new Customer(tempName, tempCardLong, 0, pin);
                    atm.AddCustomer(tempCustomer);
                }
            }
            Console.WriteLine("This card is already registered. You can try login.");
        }

        static int convertStringToInt(string str)
        {
            bool successfulParse = int.TryParse(str, out int parsedStrToInt);
            if (successfulParse)
            {
                return parsedStrToInt;
            }
            return -1;
        }
    }
}
