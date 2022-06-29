using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class Income
    {
        private string jobTitle;
        private double salary;

        public Income(string job, double salary) 
        { 
            this.jobTitle = job;
            this.salary = Math.Round(salary,2);
        }
        public string GetJobTitle() 
        {
            return this.jobTitle;
        }

        public double GetSalary()
        {
            return this.salary;
        }
    }

    public class Expense
    {
        private string item;
        private double amount;

        public Expense(string item, double amount)
        {
            this.item = item;
            this.amount = Math.Round(amount, 2);
        }
        public string GetItem()
        {
            return this.item;
        }

        public double GetAmount()
        {
            return this.amount;
        }
    }
}
