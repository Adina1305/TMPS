using System;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-7AGA2OD;Initial Catalog=HomeExpense;Integrated Security=True";

            DatabaseManager databaseManager = new DatabaseManager();
            IExpenseManager expenseManager = new ExpenseManager(connectionString);

            ExpenseAdapter expenseAdapter = new ExpenseAdapter(databaseManager);
            ExpenseBuilder expenseBuilder = new ExpenseBuilder(databaseManager);
            ExpenseDecorator expenseDecorator = new ExpenseDecorator(expenseManager);
            ExpenseFactory expenseFactory = new ExpenseFactory(databaseManager);
            ExpenseStrategy expenseStrategy = new ExpenseStrategy(databaseManager);

            string choice;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                Console.Clear();
                Console.WriteLine("Expense Tracker");
                Console.WriteLine("----------------");
                Console.WriteLine("1. View Expenses");
                Console.WriteLine("2. Add Expense Category");
                Console.WriteLine("3. Add Expense Subcategory");
                Console.WriteLine("4. Modify Expense Category");
                Console.WriteLine("5. Modify Expense Subcategory");
                Console.WriteLine("6. Calculate Total Expenses");
                Console.WriteLine("7. Add Expense");
                Console.WriteLine("8. View Categories");
                Console.WriteLine("9. View Subcategories");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------");
                Console.Write("Enter your choice: ");

                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // View Expenses (Adapter Pattern)
                        Console.WriteLine("Viewing Expenses:");
                        expenseAdapter.DisplayExpenses();
                        break;
                    case "2":
                        // Add Expense Category (Builder Pattern)
                        Console.WriteLine("Adding Expense Category:");
                        expenseBuilder.AddExpenseCategory();
                        break;
                    case "3":
                        // Add Expense Subcategory (Builder Pattern)
                        Console.WriteLine("Adding Expense Subcategory:");
                        expenseBuilder.AddExpenseSubcategory();
                        break;
                    case "4":
                        // Modify Expense Category (Decorator Pattern)
                        Console.WriteLine("Modifying Expense Category:");
                        expenseDecorator.ModifyExpenseCategory();
                        break;
                    case "5":
                        // Modify Expense Subcategory (Decorator Pattern)
                        Console.WriteLine("Modifying Expense Subcategory:");
                        expenseDecorator.ModifyExpenseSubcategory();
                        break;
                    case "6":
                        // Calculate Total Expenses (Strategy Pattern)
                        Console.WriteLine("Calculating Total Expenses:");
                        decimal totalExpenses = expenseStrategy.CalculateTotalExpenses();
                        Console.WriteLine($"Total Expenses: {totalExpenses}");
                        break;
                    case "7":
                        // Add Expense (Factory and Observer Patterns)
                        Console.WriteLine("Adding Expense:");
                        expenseFactory.AddExpense();
                        
                        break;
                    case "8":
                        // View Categories
                        Console.WriteLine("Viewing Expense Categories:");
                        expenseAdapter.DisplayExpenseCategories();
                        break;
                    case "9":
                        // View Subcategories
                        Console.WriteLine("Viewing Expense Subcategories:");
                        expenseAdapter.DisplayExpenseSubcategories();
                        break;
                    case "0":
                        // Exit
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadKey();
                }
            } while (choice != "0");
        }

    }
}
