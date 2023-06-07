using System;

namespace ExpenseTracker
{
    public class Expense
    {
        public int ID { get; set; }
        public int ExpenseTypeID { get; set; }
        public int ExpSubTypeID { get; set; }
        public string Description { get; set; }
        public decimal amount { get; set; }
        public DateTime dateofPayment { get; set; }
        public string CreatedBy { get; set; }

        public Expense(int id, int expenseTypeID, int expSubTypeID, string description, decimal amount, DateTime dateofPayment, string createdBy)
        {
            ID = id;
            ExpenseTypeID = expenseTypeID;
            ExpSubTypeID = expSubTypeID;
            Description = description;
            this.amount = amount;
            this.dateofPayment = dateofPayment;
            CreatedBy = createdBy;
        }
    }

}
