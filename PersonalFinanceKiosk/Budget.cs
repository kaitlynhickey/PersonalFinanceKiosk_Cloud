using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public abstract class Budget 
    {
        private string item;
        private double amount;

        public Budget(string item, double amount) 
        { 
            this.item = item;
            this.amount = amount;
        }

        public string Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        public double Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
    }

    public class Income : Budget
    {
        public Income(string item, double amount) : base(item, amount) 
        { 
        }
    }

    public class Expense : Budget
    {
        public Expense(string item, double amount) : base(item, amount)
        {
        }
    }
}
