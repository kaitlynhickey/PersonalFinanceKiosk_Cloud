using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class MenuFunct
    {
        public static string SetUsername()
        {
            string username;
            Console.Write("Username: ");
            username = Console.ReadLine();
            while (User.UsernameInUse(username))
            {
                Console.WriteLine("That username already exists. Please enter a unique username.");
                Console.WriteLine("Username: ");
                username = Console.ReadLine();
            }
            return username;
        }

        public static string GetUsername()
        {
            string username;
            Console.Write("Username (or 5 for new user, E to quit): ");
            username = Console.ReadLine();
            return username;
        }

        public static string GetPassword()
        {
            string password;
            Console.Write("Password: ");
            password = Console.ReadLine();
            while (password == "")
            {
                Console.WriteLine("Please enter a password: ");
                password = Console.ReadLine();
            }
            return password;
        }

        public static string GetMenuOption()
        {
            string option;
            option = Console.ReadLine();
            while (!(option == "1" | option == "2" | option == "E" | option == "e"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                MenuText.MainMenu();
                option = Console.ReadLine();
            }
            return option;
        }

        public static string GetBudgetOption()
        {
            string option;
            option = Console.ReadLine();
            while (!(option == "1" | option == "2" | option == "3" | option == "4" | option == "5" | option == "M" | option == "m" |option == "E" | option == "e"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                MenuText.BudgetMenu();
                option = Console.ReadLine();
            }
            return option;
        }

        public static string GetIncomeOption()
        {
            string option = "";
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("\nTo add another income item, press 1.");
                Console.WriteLine("To return to the main budget screen, press 2.");
                option = Console.ReadLine();
            }
            return option;
        }

        public static Income AskIncome(List<Income> incomes)
        {
            string item;
            double amount;
            Income i;

            Console.WriteLine("\n\nEnter a source of income followed by the amount.");
            item = AskItem(incomes);
            amount = AskAmount(true);
            

            i = new Income(item, amount);
            Console.WriteLine($"\nAn income item of the following has been created:\nSource: {i.Item}\nAmount: ${i.Amount}");

            return i;
        }

        public static string AskItem(List<Income> incomes) 
        {
            string item;
            bool exists = true;

            Console.Write("Enter your job title or income source: ");
            item = Console.ReadLine();

            while (incomes.Any(a => a.Item == item) | item == "")
            {
                if (item == "")
                {
                    Console.Write("Please enter a valid job title or income source: ");
                }
                else 
                {
                    Console.WriteLine("\nThat income item already exists. Please try again.\n");
                    Console.Write("Enter your job title or income source: ");
                }
                item = Console.ReadLine();
            }
            return item;
        }

        public static string AskItem(List<Expense> expenses)
        {
            string item = "";
            bool exists = true;

            Console.Write("Enter your expense title: ");
            item = Console.ReadLine();

            while (expenses.Any(a => a.Item == item) | item == "")
            {
                if (item == "")
                {
                    Console.Write("Please enter a valid job title or income source: ");
                }
                else
                {
                    Console.WriteLine("\nThat income item already exists. Please try again.\n");
                    Console.Write("Enter your job title or income source: ");
                }
                item = Console.ReadLine();
            }

            return item;
        }

        public static double AskAmount(bool income)
        {
            double amount;
            string samount;
            bool todecimal;
            string option;

            if (income)
            {
                Console.Write("Enter the amount of income as either a monthly or an annual figure: ");
            }
            else
            {
                Console.Write("Enter the expense amount as either a monthly or an annual figure: ");
            }
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out amount);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out amount);
            }

            Console.Write("\nWas the amount entered an annual or monthly amount? If annual, press 1. If monthly, press 2: ");
            option = Console.ReadLine();
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                Console.Write("Was the amount entered an annual or monthly amount? If annual, press 1. If monthly, press 2: ");
                option = Console.ReadLine();
            }
            if (option == "1")
            {
                amount = Math.Round(amount / 12, 2);
                if (income)
                {
                    Console.WriteLine($"The income amount has been adjusted accordingly to be a monthly amount of ${amount}.");
                }
                else
                {
                    Console.WriteLine($"The expense amount has been adjusted accordingly to be a monthly amount of ${amount}.");
                }
            }
            if (income)
            {
                Console.Write("\nWould you like your income amount entered to reflect estimated withheld taxes of 30%? " +
                    "\nTo apply, press 1. Otherwise, press 2: ");
                option = Console.ReadLine();
                while (!(option == "1" | option == "2"))
                {
                    Console.WriteLine("Please enter one of the following valid options.\n");
                    Console.Write("\nWould you like your income to reflect estimated withheld taxes of 30%?\nTo apply, press 1. Otherwise, press 2: ");
                    option = Console.ReadLine();
                }
                if (option == "1")
                {
                    amount = Math.Round(amount * .7, 2);
                    Console.WriteLine($"The income has been adjusted accordingly to reflect an after-tax monthly amount of ${amount}.");
                }
            }
            
            return amount;
        }

        public static void EditIncome(List<Income> incomes)
        {
            string option;
            string item = "";
            bool exists = false;

            Console.Write("\nTo edit a previously existing income item, press 1. To delete a previously existing income item, press 2: ");
            option = Console.ReadLine();
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                Console.Write("\nTo edit a previously existing income item, press 1. To delete a previously existing income item, press 2: ");
                option = Console.ReadLine();
            }
            if (option == "1")
            {
                while (!exists)
                {
                    Console.Write("Please enter an existing income source or press Q to  to back out: ");
                    item = Console.ReadLine();
                    if (item != "Q" && item != "q")
                    {
                        foreach (var i in incomes)
                        {
                            if (i.Item == item)
                            {
                                Console.Write("\nTo edit the job title or income source, press 1. To edit the amount, press 2. To edit both, press 3: ");
                                option = Console.ReadLine();
                                while (!(option == "1" | option == "2" | option == "3"))
                                {
                                    Console.WriteLine("Please enter one of the following valid options.\n");
                                    Console.Write("\nTo edit the job title or income source, press 1. To edit the amount, press 2. To edit both, press 3: ");
                                    option = Console.ReadLine();
                                }
                                if (option == "1") 
                                {
                                    i.Item = AskItem(incomes);
                                }
                                else if (option == "2") 
                                {
                                    i.Amount = AskAmount(true);
                                }
                                else 
                                {
                                    i.Item = AskItem(incomes);
                                    i.Amount = AskAmount(true);
                                }
                                Console.WriteLine($"\nThe edited income item now shows as follows:\nSource: {i.Item}\nAmount: ${i.Amount}\n");
                                exists = true;
                            }
                        }
                        if (!exists) 
                        {
                            Console.WriteLine("\nThat income source does not exist. Please try again.\n");
                        }
                    }
                    else { break; }
                }
            }
            else 
            {
                while (!exists)
                {
                    Console.Write("Enter the name of the previously existing income item to delete\nor press Q to back out: ");
                    item = Console.ReadLine();
                    if (item != "Q" && item != "q")
                    {
                        foreach (var i in incomes)
                        {
                            if (i.Item == item)
                            {
                                incomes.Remove(i);
                                Console.WriteLine($"\nThe following income item has been removed:\nSource: {i.Item}\nAmount: ${i.Amount}");
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                        {
                            Console.WriteLine("\nThat income source does not exist. Please try again.\n");
                        }
                    }
                    else { break; }
                }
            }
        }

        public static string GetEditOption()
        {
            string option = "";
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("\nTo edit another item, press 1.");
                Console.WriteLine("To return to the main budget screen, press 2.");
                option = Console.ReadLine();
            }
            return option;
        }

        public static Expense AskExpense(List<Expense> expenses)
        {
            string item;
            double amount;
            Expense i;

            Console.WriteLine("\n\nEnter an expense item followed by the amount.");
            item = AskItem(expenses);
            amount = AskAmount(false);


            i = new Expense(item, amount);
            Console.WriteLine($"\nYou have created an expense item of the following:\nExpense: {i.Item}\nAmount: ${i.Amount}");

            return i;
        }

        public static string GetExpenseOption()
        {
            string option = "";
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("\nTo add another expense item, press 1.");
                Console.WriteLine("To return to the main budget screen, press 2.");
                option = Console.ReadLine();
            }
            return option;
        }

        public static void EditExpense(List<Expense> expenses)
        {
            string option;
            string item = "";
            bool exists = false;

            Console.Write("\nTo edit a previously existing expense item, press 1. To delete a previously existing expense item, press 2: ");
            option = Console.ReadLine();
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("\nPlease enter one of the following valid options.");
                Console.Write("\nTo edit a previously existing expense item, press 1. To delete a previously existing expense item, press 2: ");
                option = Console.ReadLine();
            }
            if (option == "1")
            {
                while (!exists)
                {
                    Console.Write("Please enter an existing expense item or press Q to back out: ");
                    item = Console.ReadLine();
                    if (item != "Q" && item != "q")
                    {
                        foreach (var i in expenses)
                        {
                            if (i.Item == item)
                            {
                                Console.Write("\nTo edit the expense title, press 1. To edit the amount, press 2. To edit both, press 3: ");
                                option = Console.ReadLine();
                                while (!(option == "1" | option == "2" | option == "3"))
                                {
                                    Console.WriteLine("Please enter one of the following valid options.\n");
                                    Console.Write("\nTo edit the expense title, press 1. To edit the amount, press 2. To edit both, press 3: ");
                                    option = Console.ReadLine();
                                }
                                if (option == "1")
                                {
                                    i.Item = AskItem(expenses);
                                }
                                else if (option == "2")
                                {
                                    i.Amount = AskAmount(false);
                                }
                                else
                                {
                                    i.Item = AskItem(expenses);
                                    i.Amount = AskAmount(false);
                                }
                                Console.WriteLine($"\nThe edited expense now shows as follows:\nSource: {i.Item}\nAmount: ${i.Amount}\n");
                                exists = true;
                            }
                        }
                        if (!exists)
                        {
                            Console.WriteLine("\nThat expense item does not exist. Please try again.");
                        }
                    }
                    else { break; }
                }
            }
            else
            {
                while (!exists)
                {
                    Console.Write("Enter the name of the previously existing expense item to delete or press Q to back out: ");
                    item = Console.ReadLine();
                    if (item != "Q" && item != "q")
                    {
                        foreach (var i in expenses)
                        {
                            if (i.Item == item)
                            {
                                expenses.Remove(i);
                                Console.WriteLine($"\nThe following expense has been removed:\nSource: {i.Item}\nAmount: ${i.Amount}\n");
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                        {
                            Console.WriteLine("\nThat expense item does not exist. Please try again.");
                        }
                    }
                    else { break; }
                }
            }
        }

        public static string GetRetirementOption()
        {
            string option;
            option = Console.ReadLine();
            while (!(option == "1" | option == "2" | option == "M" | option == "m" | option == "E" | option == "e"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                MenuText.RetirementMenu();
                option = Console.ReadLine();
            }
            return option;
        }

        public static string GetRetirementWarning()
        {
            string option = "";
            while (!(option == "1" | option == "2"))
            {
                Console.WriteLine("\nWarning: If you currently have a retirement plan in place, this will override that plan" +
                    "\nand you will no longer have access to it. " +
                    "\nTo continue making a new retirement plan, press 1.");
                Console.WriteLine("To return to the main retirement plan screen, press 2.");
                option = Console.ReadLine();
            }
            return option;
        }

        public static Retirement AskRetirement()
        {
            double age;
            double retirementAge;
            double finalAge;
            double monthlyIncome;
            double savings;
            double ror; 
            double retirementRor;
            string samount;
            bool todecimal;
            Retirement retirement;

            Console.Write("\nPlease enter your current age: ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out age);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out age);
            }

            Console.Write("\nEnter the age at which you plan to retire: ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out retirementAge);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out retirementAge);
            }

            Console.Write("\nA little morbid, but necessary, please enter the ideal age to which you expect to live: ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out finalAge);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out finalAge);
            }

            Console.Write("\nEnter the current amount of savings you have set aside for retirement: ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out savings);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out savings);
            }

            Console.Write("\nEnter the monthly income you would like to receive in retirement: ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out monthlyIncome);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out monthlyIncome);
            }

            Console.Write("\nEnter the rate of return you estimate your investments to receive between now and when you retire as a percent. " +
                "\nExample: 7.5 for 7.5%" +
                "\n(Tip: An estimate for a moderate level of risk might land somewhere between 6% and 8%): ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out ror);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out ror);
            }

            Console.Write("\nEnter the rate of return you estimate your investments to receive between the time you retire and your life expectancy as a percent. " +
                "\nExample: 7.5 for 7.5%" +
                "\n(Tip: An estimate for a low level of risk might land somewhere between 2% and 4%): ");
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out retirementRor);
            while (!todecimal)
            {
                Console.Write("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out retirementRor);
            }

            retirement = new Retirement(age, retirementAge, finalAge, monthlyIncome, savings, ror, retirementRor);

            Console.WriteLine("\nYour retirement plan has been successfully created! " +
                "\nTo view the results of your retirement plan, select display retirement plan from the retirement menu.");

            return retirement;
        }

    }
}
