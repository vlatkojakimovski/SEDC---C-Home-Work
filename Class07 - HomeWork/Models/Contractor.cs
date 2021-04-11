using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contractor : Employee
    {
        public double WorkingHours { get; set; }

        public int PayPerHour { get; set; }

        public Manager ResponsibleManager { get; set; }

        public Contractor (string firstName, string lastName, double workingHours, int payPerHour, Manager manager) : base (firstName, lastName, Role.Contractor, workingHours* payPerHour)
        {
            WorkingHours = workingHours;
            PayPerHour = payPerHour;
            ResponsibleManager = manager;
        }

        public override double GetSalary()
        {
            Salary = WorkingHours * PayPerHour;
            return Salary;
        }

        public string CurrentPosition ()
        {

            return ResponsibleManager.Role.ToString();
        }
    }
}
