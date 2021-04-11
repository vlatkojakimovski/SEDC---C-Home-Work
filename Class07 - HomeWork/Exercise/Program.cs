using Models;
using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Bob","Bobsky", Role.Other, 600);
            SalesPerson salesPerson = new SalesPerson("Bill", "Billsky", 1500);
            Manager manager = new Manager("Elon", "Musk" , 5000);
            Manager managerTwo = new Manager("Bil", "Gates", 5000);
            Contractor contractor = new Contractor("Steve", "Stevensky", 160, 15, manager);
            Contractor contractorTwo = new Contractor("John", "Johnsky", 160, 30, manager);

            Employee[] company = {contractor, contractorTwo, manager, managerTwo, salesPerson };

            CEO RonCEO = new CEO("Ron", "Ronsky", company, 70, 20);
            RonCEO.PrintInfo();
            Console.WriteLine($"Salary of CEO is: {RonCEO.GetSalary()}");
            RonCEO.PrintEmployees();



            salesPerson.ExtendSuccessRevenue(2000);
            manager.AddBonus(4000);
            salesPerson.ExtendSuccessRevenue(3000);

            Console.WriteLine(employee.GetInfo());
            Console.WriteLine(salesPerson.GetInfo());
            Console.WriteLine(manager.GetInfo());


            Console.WriteLine($" \n Employee salary: {employee.GetSalary()}");
            Console.WriteLine($"SalesPerson salary: {salesPerson.GetSalary()}");
            Console.WriteLine($"Manager salary: {manager.GetSalary()}");



        }
    }
}
