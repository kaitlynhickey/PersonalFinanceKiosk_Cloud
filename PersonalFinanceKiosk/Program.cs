
namespace PersonalFinanceKiosk
{
    public class Program
    {
        public static void Main()
        {
            User user;
            string username;
            string option;
            Retirement retirement;
            string instanceState = "LogInMenu";
            string password = "";
            double sum = 0;
            List<Income> incomes = new List<Income>();
            List<Expense> expenses = new List<Expense>();

            MenuText.WelcomeMenu();

            while (instanceState != "Exit")
            {
                switch (instanceState)
                {

                    case "LogInMenu":
                        MenuText.LogInMenu();
                        username = MenuFunct.GetUsername();
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
                                password = MenuFunct.GetPassword();
                                user = new User(username, password, false);
                                if (user.SignIn())
                                {
                                    Console.WriteLine($"\nWelcome {user.username}");
                                    instanceState = "MainMenu";
                                }
                                else
                                {
                                    MenuText.InvalidSignIn();
                                }
                                break;
                        }
                        break;


                    case "NewUser":
                        MenuText.NewUserMenu();
                        username = MenuFunct.SetUsername();
                        password = MenuFunct.GetPassword();
                        user = new User(username, password, true);
                        MenuText.NewUserCreated();
                        instanceState = "LogInMenu";
                        break;


                    case "MainMenu":
                        MenuText.MainMenu();
                        option = MenuFunct.GetMenuOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "BudgetMenu";
                                break;
                            case "2":
                                instanceState = "RetirementMenu";
                                break;
                            case "E" or "e":
                                instanceState = "Exit";
                                break;
                            default:
                                break;
                        }
                        break;


                    case "BudgetMenu":
                        MenuText.BudgetMenu();
                        option = MenuFunct.GetBudgetOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "DisplayBudget";
                                break;
                            case "2":
                                instanceState = "EnterIncome";
                                break;
                            case "3":
                                instanceState = "EditIncome";
                                break;
                            case "4":
                                instanceState = "EnterExpense";
                                break;
                            case "5":
                                instanceState = "EditExpense";
                                break;
                            case "M" or "m":
                                instanceState = "MainMenu";
                                break;
                            case "E" or "e":
                                instanceState = "Exit";
                                break;
                        }
                        break;

                    case "DisplayBudget":
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Income Items:");
                        foreach (var i in incomes) 
                        {
                            Console.Write(i.Item);
                            Console.WriteLine("\t\t\t\t\t$" + i.Amount);
                            sum += i.Amount;
                        }
                        Console.WriteLine("\nExpense Items:");
                        foreach (var i in expenses)
                        {
                            Console.Write(i.Item);
                            Console.WriteLine("\t\t\t\t\t- $" + i.Amount);
                            sum -= i.Amount;
                        }
                        Console.WriteLine("\nTotal:\t\t\t\t\t$" + sum + "\n");
                        instanceState = "BudgetMenu";
                        break;


                    case "EnterIncome":
                        incomes.Add(MenuFunct.AskIncome(incomes));
                        option = MenuFunct.GetIncomeOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "EnterIncome";
                                break;
                            case "2":
                                instanceState = "BudgetMenu";
                                break;
                        }
                        break;


                    case "EditIncome":
                        MenuFunct.EditIncome(incomes);
                        option = MenuFunct.GetEditOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "EditIncome";
                                break;
                            case "2":
                                instanceState = "BudgetMenu";
                                break;
                        }
                        break;


                    case "EnterExpense":
                        expenses.Add(MenuFunct.AskExpense(expenses));
                        option = MenuFunct.GetExpenseOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "EnterExpense";
                                break;
                            case "2":
                                instanceState = "BudgetMenu";
                                break;
                        }
                        break;


                    case "EditExpense":
                        MenuFunct.EditExpense(expenses);
                        option = MenuFunct.GetEditOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "EditExpense";
                                break;
                            case "2":
                                instanceState = "BudgetMenu";
                                break;
                        }
                        break;


                    case "RetirementMenu":
                        MenuText.RetirementMenu();
                        option = MenuFunct.GetRetirementOption();
                        switch (option)
                        {
                            case "1":
                                instanceState = "DisplayRetirement";
                                break;
                            case "2":
                                instanceState = "RetirementWarning";
                                break;
                            case "3":
                                instanceState = "EditIncome";
                                break;
                            case "M" or "m":
                                instanceState = "MainMenu";
                                break;
                            case "E" or "e":
                                instanceState = "Exit";
                                break;
                        }
                        break;


                    case "DisplayRetirement":
                        Console.WriteLine("Display Retirement Plan");
                        instanceState = "RetirementMenu";
                        break;


                    case "RetirementWarning":
                        option = MenuFunct.GetRetirementWarning();
                        switch (option)
                        {
                            case "1":
                                instanceState = "CreateRetirement";
                                break;
                            case "2":
                                instanceState = "RetirementMenu";
                                break;
                        }
                        break;

                    
                }
            }
            MenuText.ExitMenu();
        }
    }
}



