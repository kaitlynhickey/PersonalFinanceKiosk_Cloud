using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class MenuText
    {
        public static void WelcomeMenu()
        {
            Console.WriteLine("DISCLAIMER: " +
                "\nThis is a school project and is neither intended to serve as financial advice " +
                "\nnor as a system to contain actual financial information. " +
                "\nDo not enter any personal information." +
                "\nThe security of this application and the information entered is neither implied nor guaranteed. " +
                "\nUse of this application signals you understand that personal information should not be entered " +
                "\nand fabricated data should be used.");

            Console.Write("\nPlease press enter to continue:");
            Console.ReadLine();

            Console.WriteLine("\n\nWelcome to your personal finance kiosk!");
        }

        public static void LogInMenu()
        {
            Console.WriteLine("\nTo log in as an existing user, please enter your username followed by your password.");
            Console.WriteLine("To create a new account, please enter 5");
            Console.WriteLine("To exit the application, enter E");
        }

        public static void InvalidSignIn()
        {
            Console.WriteLine("The username or password provided was invalid. Please try again.");
        }

        public static void NewUserMenu()
        {
            Console.WriteLine("\n\nTo create a new user, enter your username of choice and password.");
        }

        public static void NewUserCreated()
        {
            Console.WriteLine("Your account has been successfully created." +
                              "\nPlease use your newly created username and password to sign in.");
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\nPlease select from one of the following kiosk options.");
            Console.WriteLine("To build a budget, press 1");
            Console.WriteLine("To build a retirement plan, press 2");
            Console.WriteLine("To exit the application, enter E");
        }
        
        public static void BudgetMenu()
        {
            Console.WriteLine("\n\nCreate a monthly budget by entering income and expenses.");
            Console.WriteLine("To display your current budget, press 1");
            Console.WriteLine("To enter an income item, press 2");
            Console.WriteLine("To edit or delete an existing income item, press 3");
            Console.WriteLine("To enter an expense item, press 4");
            Console.WriteLine("To edit or delete an existing income item, press 5");
            Console.WriteLine("To return to the main menu, enter M");
            Console.WriteLine("To exit the application, enter E");
        }

        public static void RetirementMenu()
        {
            Console.WriteLine("\n\nCreate and view an estimated retirement plan:");
            Console.WriteLine("To display your current retirement plan, press 1");
            Console.WriteLine("To create a new retirement plan, press 2");
            //Console.WriteLine("To edit an existing retirement plan, press 3");
            Console.WriteLine("To return to the main menu, enter M");
            Console.WriteLine("To exit the application, enter E");
        }

        public static void ExitMenu()
        {
            Console.WriteLine("\n\nThank you for using the personal finance kiosk. Have a great day!");
        }
    }
}
