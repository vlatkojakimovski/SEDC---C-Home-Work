﻿

namespace Models
{
    public class SalesPerson : Employee
    {
        private double SuccessSaleRevenue { get; set; }

        //public SalesPerson()
        //{
        //    Salary = 500;
        //    Role = Role.Sales;
        //}

        public SalesPerson(string firstName, string lastName, double successSalesRevenue) : base (firstName, lastName, Role.Sales, 500)
        {
            SuccessSaleRevenue = successSalesRevenue;
        }

        public void ExtendSuccessRevenue (double revenue)
        {
            SuccessSaleRevenue += revenue;
        }

        public override double GetSalary()
        {
            double bonus = 0;

            if (SuccessSaleRevenue <= 2000)
            {
                bonus = 500;
            }
            else if (SuccessSaleRevenue > 2000 && SuccessSaleRevenue <= 5000)
            {
                bonus = 1000;
            } else if (SuccessSaleRevenue > 5000)
            {
                bonus = 1500;
            }
            return Salary + bonus;

            //if salary is private property
            //return base.GetSalary() + bonus;
        }
    }
}
