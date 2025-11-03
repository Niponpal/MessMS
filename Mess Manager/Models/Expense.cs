namespace Mess_Manager.Models;

public class Expense
{
    public int Id { get; set; }
    public string ExpenseName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Description { get; set; } = string.Empty;
}
