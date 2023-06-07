using System;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public interface IExpenseManager
    {
        void ModifyExpenseCategory();
        void ModifyExpenseSubcategory();
    }

    public class ExpenseManager : IExpenseManager
    {
        private string connectionString;
        private DatabaseManager databaseManager;

        public ExpenseManager(string connectionString)
        {
            this.connectionString = connectionString;
            this.databaseManager = new DatabaseManager();
        }

        public void ModifyExpenseCategory()
        {
            Console.Write("Enter expense category to modify: ");
            string categoryToModify = Console.ReadLine();

            Console.Write("Enter new expense category: ");
            string newCategory = Console.ReadLine();

            string query = $"UPDATE tblExpenseType SET ExpenseType = '{newCategory}' WHERE ExpenseType = '{categoryToModify}'";
            ExecuteQuery(query);

            Console.WriteLine("Expense category modified successfully.");
        }

        public void ModifyExpenseSubcategory()
        {
            Console.Write("Enter expense subcategory to modify: ");
            string subcategoryToModify = Console.ReadLine();

            Console.Write("Enter new expense subcategory: ");
            string newSubcategory = Console.ReadLine();

            string query = $"UPDATE tblExpSubType SET ExpSubType_desc = '{newSubcategory}' WHERE ExpSubType_desc = '{subcategoryToModify}'";
            ExecuteQuery(query);

            Console.WriteLine("Expense subcategory modified successfully.");
        }


        private void ExecuteQuery(string query)
        {
            try
            {
                databaseManager.OpenConnection();

                SqlCommand command = new SqlCommand(query, databaseManager.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
        }
    }

    public class ExpenseDecorator : IExpenseManager
    {
        private IExpenseManager expenseManager;

        public ExpenseDecorator(IExpenseManager expenseManager)
        {
            this.expenseManager = expenseManager;
        }

        public void ModifyExpenseCategory()
        {
            Console.WriteLine("Decorating ExpenseManager: Modifying Expense Category");

            // Apelați metoda originală pentru a permite modificarea categoriei în cadrul ExpenseManager
            expenseManager.ModifyExpenseCategory();

            Console.WriteLine("Decoration Complete");
        }

        public void ModifyExpenseSubcategory()
        {
            Console.WriteLine("Decorating ExpenseManager: Modifying Expense Subcategory");

            expenseManager.ModifyExpenseSubcategory();

            Console.WriteLine("Decoration Complete");
        }

    }

}
