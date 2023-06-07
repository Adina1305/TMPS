using System;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public class ExpenseBuilder
    {
        private DatabaseManager databaseManager;

        public ExpenseBuilder(DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        public void AddExpenseCategory()
        {
            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            string query = $"INSERT INTO tblExpenseType (ExpenseType) VALUES ('{category}')";
            ExecuteQuery(query);

            Console.WriteLine("Expense category added successfully.");
        }
        private int GetNextCategoryId()
        {
            string query = "SELECT COUNT(*) + 1 FROM tblExpenseType";
            SqlCommand command = new SqlCommand(query, databaseManager.Connection);

            try
            {
                databaseManager.OpenConnection();
                object result = command.ExecuteScalar();
                return (int)result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                return -1;
            }
            finally
            {
                databaseManager.CloseConnection();
            }
        }


        public void AddExpenseSubcategory()
        {
            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            Console.Write("Enter expense subcategory: ");
            string subcategory = Console.ReadLine();

            string query = $"INSERT INTO tblExpSubType (ExpenseTypeID, ExpSubType_desc) VALUES ((SELECT ExpenseTypeID FROM tblExpenseType WHERE ExpenseType = '{category}'), '{subcategory}')";
            ExecuteQuery(query);

            Console.WriteLine("Expense subcategory added successfully.");
        }



        private int GetNextSubcategoryId()
        {
            string query = "SELECT COUNT(*) + 1 FROM tblExpSubType";
            SqlCommand command = new SqlCommand(query, databaseManager.Connection);

            try
            {
                databaseManager.OpenConnection();
                object result = command.ExecuteScalar();
                return (int)result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                return -1;
            }
            finally
            {
                databaseManager.CloseConnection();
            }
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
}
