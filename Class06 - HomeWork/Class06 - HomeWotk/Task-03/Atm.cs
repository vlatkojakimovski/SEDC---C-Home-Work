using System;
using System.Collections.Generic;
using System.Text;

namespace Task_03
{
    class Atm
    {
        public Customer[] customers = new Customer[0];

        public void AddCustomer (Customer newCustomer)
        {
            Array.Resize(ref customers, customers.Length + 1);
            customers[customers.Length - 1] = newCustomer;
        }

        public int FindCustomerPositionByCardNumber(Customer [] custArr, long cardNumber)
        {
            for (int i = 0; i < custArr.Length; i++)
            {
                if (cardNumber == custArr[i].GetCardNumber())
                {
                    return i;
                } 
            }
            return -1;
        }

        public void printCustomers()
        {
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i].GetCustomerInfo();
                Console.WriteLine();
            }
        }

        public long ConvertCardNumberToLongCard (string card)
        {
            string[] stringCardArr = card.Split("-");
            if (stringCardArr.Length != 4)
            {
                return -1;
            }
            foreach (string item in stringCardArr)
            {
                if (item.Length != 4)
                {
                    return -1;
                } 
            }
            string oneString = string.Join("", stringCardArr);

            bool succesfulParse = long.TryParse(oneString, out long parsedCardToLong);
            if (!succesfulParse)
            {
                return -1;
            }

            return parsedCardToLong;
        } 
    }
}
