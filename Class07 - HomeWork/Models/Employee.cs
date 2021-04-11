using System;

namespace Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public string FullName { 
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

        public string FullName => $"{FirstName} {LastName}";

        public Role Role { get; set; }

        protected double Salary { set; get; }



        public Employee(string firstName, string lastName, Role role, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Salary = salary;
        }

        public string GetInfo()
        {
            return $"{FullName} - Salary: {Salary} \n";
            // will call base or override methodthat will return salary + bonuses
            //return $"{FullName} - {GetSalary()}";
        }

        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
