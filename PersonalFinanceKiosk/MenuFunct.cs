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
            while (!(option == "1" || option == "2" || option == "E" || option == "e"))
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
            while (!(option == "1" || option == "2" || option == "E" || option == "e"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                MenuText.MainMenu();
                option = Console.ReadLine();
            }
            return option;
        }

        public static string GetIncomeOption()
        {
            string option = "";
            while (!(option == "1" || option == "2"))
            {
                Console.WriteLine("To add another income item, press 1.");
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

            Console.WriteLine("\nEnter a source of income followed by the amount.");
            Console.Write("Enter your job title or income source: ");
            item = AskItem(incomes);
            amount = AskAmount(true);
            

            i = new Income(item, amount);
            Console.WriteLine($"You have created an income item of the following:\nSource: {i.Item}\nAmount: ${i.Amount}");

            return i;
        }

        public static string AskItem(List<Income> incomes) 
        {
            string item = "";
            item = Console.ReadLine();

            while (item == "")
            {
                Console.WriteLine("Please enter a valid job title or income source: ");
                item = Console.ReadLine();
            }
            while (true) 
            { 
                for
            }

            return item;
        }

        public static string AskItem(List<Expense> expenses)
        {
            string item = "";
            item = Console.ReadLine();

            while (item == "")
            {
                Console.WriteLine("Please enter a valid expense title: ");
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
                Console.Write("Enter the related amount of income: ");
            }
            else
            {
                Console.Write("Enter the related expense amount: ");
            }
            samount = Console.ReadLine();
            todecimal = Double.TryParse(samount, out amount);
            while (!todecimal)
            {
                Console.WriteLine("Please enter a valid number: ");
                samount = Console.ReadLine();
                todecimal = Double.TryParse(samount, out amount);
            }

            Console.Write("Was the amount entered an annual or monthly amount? If annual, press 1. If monthly, press 2: ");
            option = Console.ReadLine();
            while (!(option == "1" || option == "2"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                Console.Write("Was the amount entered an annual or monthly amount? If annual, press 1. If monthly, press 2: ");
                option = Console.ReadLine();
            }
            if (option == "1")
            {
                amount = amount / 12;
                if (income)
                {
                    Console.WriteLine($"The income amount has been adjusted to be a monthly amount of ${amount}.");
                }
                else
                {
                    Console.WriteLine($"The expense amount has been adjusted to be a monthly amount of ${amount}.");
                }
            }
            return amount;
        }

        public static void EditIncome(List<Income> incomes)
        {
            string samount;
            double amount;
            bool todecimal;
            string option;
            string item = "";
            bool exists = false;

            Console.Write("\nTo edit a previously existing income item, press 1. To delete a previously existing income item, press 2: ");
            option = Console.ReadLine();
            while (!(option == "1" || option == "2"))
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                Console.Write("\nTo edit a previously existing income item, press 1. To delete a previously existing income item, press 2: ");
                option = Console.ReadLine();
            }
            if (option == "1")
            {
                while (!exists)
                {
                    Console.WriteLine("Please enter an existing income source or press Q to return to the Budget Menu: ");
                    item = Console.ReadLine();
                    if (item != "Q" | item != "Q")
                    {
                        foreach (var i in incomes)
                        {
                            if (i.Item == item)
                            {
                                Console.Write("\nTo edit the job title or income source, press 1. To edit the amount only, press 2: ");
                                option = Console.ReadLine();
                                while (!(option == "1" || option == "2"))
                                {
                                    Console.WriteLine("Please enter one of the following valid options.\n");
                                    Console.Write("\nTo edit the job title or income source, press 1. To edit the amount only, press 2: ");
                                    option = Console.ReadLine();
                                }
                                if (option == "1") 
                                {
                                    i.Item = AskItem(incomes);
                                    i.Amount = AskAmount(true);
                                }
                                else 
                                {
                                    i.Amount = AskAmount(true);
                                }
                                exists = true;
                            }
                        }
                        if (!exists) 
                        {
                            Console.WriteLine("\nThat income source does not exist. Please try again.");
                        }
                    }
                    else { break; }
                }
            }
            else 
            {
                while (!exists)
                {
                    Console.WriteLine("Enter the name of the previously existing income item to delete or press Q to return to the Budget Menu: ");
                    item = Console.ReadLine();
                    if (item != "Q" | item != "Q")
                    {
                        foreach (var i in incomes)
                        {
                            if (i.Item == item)
                            {
                                incomes.Remove(i);
                                exists = true;
                            }
                        }
                        if (!exists)
                        {
                            Console.WriteLine("\nThat income source does not exist. Please try again.");
                        }
                    }
                    else { break; }
                }
            }
        }

        public static string GetEditOption()
        {
            string option = "";
            while (!(option == "1" || option == "2"))
            {
                Console.WriteLine("To edit another item, press 1.");
                Console.WriteLine("To return to the main budget screen, press 2.");
                option = Console.ReadLine();
            }
            return option;
        }

        public static Income AskExpense(List<Expense> expenses)
        {
            string item;
            double amount;
            Expense i;

            Console.WriteLine("\nEnter an expense item followed by the amount.");
            Console.Write("Enter your expense item: ");
            item = AskItem(expenses);
            amount = AskAmount(false);


            i = new Expense(item, amount);
            Console.WriteLine($"You have created an expese item of the following:\nSource: {i.Item}\nAmount: ${i.Amount}");

            return i;
        }
    }
}
