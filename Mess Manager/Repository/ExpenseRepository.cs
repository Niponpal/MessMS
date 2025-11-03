using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Expense> AddExpense(Expense expense, CancellationToken cancellationToken)
        {
            await _context.AddAsync(expense);
             _context.SaveChanges();
            return expense;
        }

        public async Task<Expense> DeleteExpense(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Expenses.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Expenses.Remove(data);
               _context.SaveChanges();
            }
            return null;
        }

        public async Task<IEnumerable<Expense>> GetAllExpenseAsynce(CancellationToken cancellationToken)
        {
            var data = await _context.Expenses.ToListAsync(cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Expense> GetExpenseByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Expenses.FindAsync(id,cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Expense> UpdateExpense(Expense expense, CancellationToken cancellationToken)
        {
            var data = await _context.Expenses.FindAsync(expense.Id, cancellationToken);
            if(data != null)
            {
                data.ExpenseName = expense.ExpenseName;
                data.Amount = expense.Amount;
                data.ExpenseDate = expense.ExpenseDate;
                data.Description = expense.Description;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
