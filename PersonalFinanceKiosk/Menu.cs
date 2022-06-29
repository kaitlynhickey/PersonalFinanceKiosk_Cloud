using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class Menu
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

        public static void LogInMenu2()
        {
            Console.WriteLine("\nPlease enter your username followed by your password.");
            Console.WriteLine("To create a new account, please enter 5");
            Console.WriteLine("To exit the application, enter E");
        }

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

        public static void InvalidSignIn()
        {
            Console.WriteLine("The username or password provided was invalid. Please try again.");
        }

        public static void NewUserMenu()
        {
            Console.WriteLine("\nTo create a new user, enter your username of choice and password.");
        }

        public static void NewUserCreated()
        {
            Console.WriteLine("Your account has been successfully created." +
                              "\nPlease use your newly created username and password to sign in.");
        }

        public static void OptionsMenu()
        {
            Console.WriteLine("\nPlease select from one of the following kiosk options.");
            Console.WriteLine("To build a budget, press 1");
            Console.WriteLine("To build a retirement plan, press 2");
            Console.WriteLine("To exit the application, enter E");
        }
        public static string GetOption()
        {
            string option;
            option = Console.ReadLine();
            while (!(option == "1" || option == "2" || option == "E" || option == "e")) 
            {
                Console.WriteLine("Please enter one of the following valid options.\n");
                OptionsMenu();
                option = Console.ReadLine();
            }
            return option;
        }

        public static void ExitMenu()
        {
            Console.WriteLine("\nThank you for using the personal finance kiosk. Have a great day!");
        }
    }
}
