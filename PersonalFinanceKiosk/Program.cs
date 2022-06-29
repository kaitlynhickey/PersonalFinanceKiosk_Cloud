
namespace PersonalFinanceKiosk
{
    public class Program
    {
        public static void Main()
        {
            User user;
            string instanceState = "LogInMenu";
            string username;
            string option;
            string password = "";
            List<Income> incomes = new List<Income>();
            List<Expense> expenses = new List<Expense>();

            Menu.WelcomeMenu();

            while (instanceState != "Exit")
            {
                switch (instanceState)
                {
                    case "LogInMenu":
                        Menu.LogInMenu();
                        username = Menu.GetUsername();
                        switch (username)
                        {
                            case "":
                                Console.WriteLine("Please enter a valid username\n");
                                break;
                            case "5":
                                instanceState = "NewUser";
                                break;
                            case "E" or "e":
                                instanceState = "Exit";
                                break;
                            default:
                                password = Menu.GetPassword();
                                user = new User(username, password, false);
                                if (user.SignIn())
                                {
                                    Console.WriteLine($"\nWelcome {user.username}");
                                    instanceState = "OptionsMenu";
                                }
                                else
                                {
                                    Menu.InvalidSignIn();
                                }
                                break;
                        }
                        break;
                    case "NewUser":
                        Menu.NewUserMenu();
                        username = Menu.SetUsername();
                        password = Menu.GetPassword();
                        user = new User(username, password, true);
                        Menu.NewUserCreated();
                        instanceState = "LogInMenu";
                        break;
                    case "OptionsMenu":
                        Menu.OptionsMenu();
                        option = Menu.GetOption();
                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("\nBudget Functionality:");
                                instanceState = "Exit";
                                break;
                            case "2":
                                Console.WriteLine("\nRetirement Planning Functionality:");
                                instanceState = "Exit";
                                break;
                            case "E" or "e":
                                instanceState = "Exit";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            Menu.ExitMenu();
        }
    }
}



