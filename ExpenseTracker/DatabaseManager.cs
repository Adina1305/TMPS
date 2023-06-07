using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source=DESKTOP-7AGA2OD;Initial Catalog=HomeExpense;Integrated Security=True";
        private SqlConnection connection;

        public SqlConnection Connection { get { return connection; } }

        public DatabaseManager()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
                connection.Open();          
        }

        public void CloseConnection()
        {
                connection.Close();
        }

        public List<Expense> GetAllExpenses()
        {
            List<Expense> expenses = new List<Expense>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM tblAllExpenses";
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int expenseTypeID = (int)reader["ExpenseTypeID"];
                    int expSubTypeID = (int)reader["ExpSubTypeID"];
                    string description = (string)reader["Description"];
                    decimal amount = (decimal)reader["amount"];
                    DateTime dateOfPayment = (DateTime)reader["dateofPayment"];
                    string createdBy = (string)reader["CreatedBy"];

                    Expense expense = new Expense(
                        id,
                        expenseTypeID,
                        expSubTypeID,
                        description,
                        amount,
                        dateOfPayment,
                        createdBy
                    );

                    expenses.Add(expense);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving expenses: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return expenses;
        }

    }
}
