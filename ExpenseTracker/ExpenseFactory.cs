using System;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public class ExpenseFactory
    {
        private DatabaseManager databaseManager;
        ExpenseObserver expenseObserver = new ExpenseObserver();
 
        public ExpenseFactory(DatabaseManager dbManager)
        {
            databaseManager = dbManager;
        }
       

        public void AddExpense()
        {
            Console.Write("Enter ExpenseTypeID: ");
            int expenseTypeID = int.Parse(Console.ReadLine());

            Console.Write("Enter ExpSubTypeID: ");
            int expSubTypeID = int.Parse(Console.ReadLine());

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (!expenseObserver.CheckExpenseAmount(amount))
            {
                Console.WriteLine("Expense cannot be added. Amount exceeds the maximum limit.");
                return;
            }

            Console.Write("Enter DateOfPayment (yyyy-MM-dd): ");
            DateTime dateOfPayment = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter CreatedBy: ");
            string createdBy = Console.ReadLine();

            try
            {
                databaseManager.OpenConnection();

                string query = "INSERT INTO tblAllExpenses (ExpenseTypeID, ExpSubTypeID, Description, amount, dateofPayment, CreatedBy) " +
                               "VALUES (@ExpenseTypeID, @ExpSubTypeID, @Description, @Amount, @DateOfPayment, @CreatedBy)";

                SqlCommand command = new SqlCommand(query, databaseManager.Connection);
                command.Parameters.AddWithValue("@ExpenseTypeID", expenseTypeID);
                command.Parameters.AddWithValue("@ExpSubTypeID", expSubTypeID);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@DateOfPayment", dateOfPayment);
                command.Parameters.AddWithValue("@CreatedBy", createdBy);

                command.ExecuteNonQuery();

                Console.WriteLine("Expense added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
        }
    }
}
