public class ExpenseCategory
{
    public int Id { get; set; }
    public string ExpenseType { get; set; }

    public ExpenseCategory(int id, string expenseType)
    {
        Id = id;
        ExpenseType = expenseType;
    }
}

public class ExpSubType
{
    public int Id { get; set; }
    public int ExpenseTypeId { get; set; }
    public string ExpSubTypeDesc { get; set; }

    public ExpSubType(int id, int expenseTypeId, string expSubTypeDesc)
    {
        Id = id;
        ExpenseTypeId = expenseTypeId;
        ExpSubTypeDesc = expSubTypeDesc;
    }
}
