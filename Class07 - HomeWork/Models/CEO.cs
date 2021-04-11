using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CEO : Employee
    {
        public int Shares { get; set; }
        private double SharesPrice { get; set; }
        public Employee[] Employees { get; set; }
        
        public CEO(string firstName, string lastName, Employee [] employees, int shares, double sharesPrice) : base (firstName, lastName, Role.CEO, 1500 )
        {
            Shares = shares;
            SharesPrice = sharesPrice;
            Employees = employees;
        }

        public void AddSharesPrice(double number)
        {
            SharesPrice = number;
        }

        public void PrintEmployees()
        {
            Console.WriteLine($"Employees who works for {FullName }:\n");
            foreach (Employee item in Employees)
            {
                Console.WriteLine($" {item.GetInfo()} \n");
            }
        }

        public override double GetSalary()
        {
            return Salary + Shares * SharesPrice;
        }

        public void PrintInfo ()
        {
            Console.WriteLine($" {Role} \n First Name: {FirstName}, Last Name: {LastName} Salary: {Salary}");
        }
    }
}
