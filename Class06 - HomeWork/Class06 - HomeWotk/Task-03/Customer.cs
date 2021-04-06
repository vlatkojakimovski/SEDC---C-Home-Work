using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_03
{
    class Customer
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        private int Balance { get; set; }
        private int Pin { get; set; }

        public Customer(string name, long cardNumber, int balance, int pin)
        {
            Name = name;
            CardNumber = cardNumber;
            Balance = balance;
            Pin = pin;
        }

        public long GetCardNumber()
        {
            return CardNumber;
        }

        public int GetPin()
        {
            return Pin;
        }

        public void SetPin(int pin)
        {
            Pin = pin;
        }

        public int GetBalance()
        {
            return Balance;
        }

        public string ConvertCurrency(int amount)
        {
            return (amount.ToString("C", new CultureInfo("en-US")));
        }

        public bool CacheWithdrawal (int sumToWithdraw)
        {
            if (Balance >= sumToWithdraw)
            {
                Balance -= sumToWithdraw;
                Console.WriteLine($"You withdraw {ConvertCurrency(sumToWithdraw)}. \n Your account balance now is: {ConvertCurrency(Balance)}");
                return true;
            }
            else
            {
                Console.WriteLine("Not enough money on your account !!!");
                return false;
            }
        }

        public void CacheDeposit(int deposit)
        {
            Balance += deposit;
            Console.WriteLine($"Deposit of {ConvertCurrency(deposit)} successfuli added to your account. \n Your account balance is: {ConvertCurrency(Balance)}");
        }

        public void GetCustomerInfo ()
        {
            string cardParsed = Regex.Replace(CardNumber.ToString(), ".{4}", "$0-");
            cardParsed = cardParsed.Remove(cardParsed.Length - 1);
            Console.WriteLine($" Name: {Name} \n Card No: {cardParsed} \n Balance: {ConvertCurrency(Balance)}\n Pin: {Pin}");
        }
    }
}
