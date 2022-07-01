using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace PersonalFinanceKiosk
{
    public class Retirement
    {
        private double age;
        private double monthsAge;
        private double retirementAge;
        private double monthsRetirementAge;
        private double finalAge;
        private double monthsFinalAge;
        private double nper;
        private double nperRF;
        private double monthlyPayment;
        private double monthlyIncome;
        private double savings;
        private double valueAtRetirement;
        private double ror;
        private double monthlyRor;
        private double retirementRor;
        private double monthlyRetirementRor;
        private double valueAtFinalAge = 150000.0;

        public Retirement(double age, double retirementAge, double finalAge, double monthlyIncome, double savings, double ror, double retirementRor)
        {
            this.age = age;
            this.monthsAge = age * 12;
            this.retirementAge = retirementAge;
            this.monthsRetirementAge = retirementAge * 12;
            this.finalAge = finalAge;
            this.monthsFinalAge = finalAge * 12;
            this.nper = monthsRetirementAge - monthsAge;
            this.nperRF = monthsFinalAge - monthsRetirementAge;
            this.monthlyIncome = -monthlyIncome;
            this.savings = savings;
            this.ror = ror;
            this.monthlyRor = ror / 100 / 12;
            this.retirementRor = retirementRor;
            this.monthlyRetirementRor = retirementRor / 100 / 12;

            this.ValueAtRetirement = Financial.PV(this.monthlyRetirementRor, this.nperRF, this.monthlyIncome, this.valueAtFinalAge);
            this.monthlyPayment = Financial.Pmt(this.monthlyRor, this.nper, this.savings, -this.valueAtRetirement);
        }

        public double Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double RetirementAge
        {
            get { return this.retirementAge; }
            set { this.retirementAge = value; }
        }

        public double Nper
        {
            get { return this.nper; }
            set { this.nper = value; }
        }

        public double NperRF
        {
            get { return this.nperRF; }
            set { this.nperRF = value; }
        }

        public double MonthlyIncome
        {
            get { return this.monthlyIncome; }
            set { this.monthlyIncome = value; }
        }

        public double MonthlyPayment
        {
            get { return this.monthlyPayment; }
            set { this.monthlyPayment = value; }
        }

        public double Savings
        {
            get { return this.savings; }
            set { this.savings = value; }
        }

        public double ValueAtRetirement
        {
            get { return this.valueAtRetirement; }
            set { this.valueAtRetirement = value; }
        }

        public double RoR
        {
            get { return this.ror; }
            set { this.ror = value; }
        }

        public double RetirementRor
        {
            get { return this.retirementRor; }
            set { this.retirementRor = value; }
        }

        public double ValueAtFinalAge
        {
            get { return this.valueAtFinalAge; }
            set { this.valueAtFinalAge = value; }
        }
    }
}
