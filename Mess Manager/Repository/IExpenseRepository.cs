using Mess_Manager.Models;

namespace Mess_Manager.Repository;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetAllExpenseAsynce(CancellationToken cancellationToken);
    Task<Expense>AddExpense(Expense expense,CancellationToken cancellationToken);
    Task<Expense> UpdateExpense(Expense expense,CancellationToken cancellationToken);
    Task<Expense> DeleteExpense(int id,CancellationToken cancellationToken);
    Task<Expense> GetExpenseByIdAsync(int  id,CancellationToken cancellationToken);
}
