using System;

namespace ExpenseTracker
{
    public class ExpenseObserver
    {
        public bool CheckExpenseAmount(decimal amount)
        {
            if (amount > 10000)
            {
                Console.WriteLine("Restriction: Amount exceeds the maximum limit.");
                return false;
            }
            else
            {
                Console.WriteLine("Expense amount is within the limit.");
                return true;
            }
        }
    }
}
