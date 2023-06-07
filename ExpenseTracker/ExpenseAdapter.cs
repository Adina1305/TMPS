using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public class ExpenseAdapter
    {
        private DatabaseManager databaseManager;

        public ExpenseAdapter(DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        public void DisplayExpenses()
        {
            Console.WriteLine("Displaying Expenses from SQL Database:");

            // Obțineți conexiunea din DatabaseManager
            SqlConnection connection = databaseManager.Connection;

            // Interogați baza de date pentru a obține cheltuielile
            string query = "SELECT * FROM tblAllExpenses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                // Deschideți conexiunea și citiți datele cheltuielilor
                databaseManager.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int expenseTypeID = (int)reader["ExpenseTypeID"];
                    int expSubTypeID = (int)reader["ExpSubTypeID"];
                    string expenseType = expenseTypeID.ToString();
                    string expenseSubType = expSubTypeID.ToString();
                    string description = (string)reader["Description"];
                    decimal amount = (decimal)reader["amount"];
                    DateTime dateOfPayment = (DateTime)reader["dateofPayment"];
                    string createdBy = (string)reader["CreatedBy"];

                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Expense Type: {expenseType}");
                    Console.WriteLine($"Expense SubType: {expenseSubType}");
                    Console.WriteLine($"Description: {description}");
                    Console.WriteLine($"Amount: {amount}");
                    Console.WriteLine($"Date of Payment: {dateOfPayment}");
                    Console.WriteLine($"Created By: {createdBy}");
                    Console.WriteLine();
                }

                reader.Close();
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

        public void DisplayExpenseCategories()
        {
            Console.WriteLine("Displaying Expense Categories:");

            SqlConnection connection = databaseManager.Connection;
            string query = "SELECT * FROM tblExpenseType";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                databaseManager.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int expenseTypeID = (int)reader["ExpenseTypeID"];
                    string expenseType = (string)reader["ExpenseType"];

                    Console.WriteLine($"Expense Type ID: {expenseTypeID}");
                    Console.WriteLine($"Expense Type: {expenseType}");
                    Console.WriteLine();
                }

                reader.Close();
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

        public void DisplayExpenseSubcategories()
        {
            Console.WriteLine("Displaying Expense Subcategories:");

            SqlConnection connection = databaseManager.Connection;
            string query = "SELECT * FROM tblExpSubType";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                databaseManager.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int expSubTypeID = Convert.IsDBNull(reader["ExpSubTypeID"]) ? 0 : (int)reader["ExpSubTypeID"];
                    int expenseTypeID = Convert.IsDBNull(reader["ExpenseTypeID"]) ? 0 : (int)reader["ExpenseTypeID"];
                    string expSubTypeDesc = (string)reader["ExpSubType_desc"];

                    Console.WriteLine($"Expense SubType ID: {expSubTypeID}");
                    Console.WriteLine($"Expense Type ID: {expenseTypeID}");
                    Console.WriteLine($"Expense SubType Description: {expSubTypeDesc}");
                    Console.WriteLine();
                }

                reader.Close();
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
