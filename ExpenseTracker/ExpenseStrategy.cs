using System;
using System.Linq;

namespace ExpenseTracker
{
    public class ExpenseStrategy
    {
        private DatabaseManager databaseManager;

        public ExpenseStrategy(DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        public decimal CalculateTotalExpenses()
        {
            var allExpenses = databaseManager.GetAllExpenses();
            decimal totalExpenses = allExpenses.Sum(expense => expense.amount);
            return totalExpenses;
        }
    }
}
