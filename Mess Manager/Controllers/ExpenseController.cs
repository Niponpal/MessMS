using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mess_Manager.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _expenseRepository.GetAllExpenseAsynce(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if(id == 0)
            {
                return View(new Expense());
            }
            var data = await _expenseRepository.GetExpenseByIdAsync(id, cancellationToken);
            if(data == null)
            {
                return NotFound();
            }
            return View(data); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Expense expense, CancellationToken cancellationToken)
        {
            if (expense.Id == 0)
            {
                await _expenseRepository.AddExpense(expense, cancellationToken);
                return RedirectToAction("Index");
            }
            else{ 
                
                await _expenseRepository.UpdateExpense(expense, cancellationToken);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _expenseRepository.GetExpenseByIdAsync(id,cancellationToken);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var data = await _expenseRepository.GetExpenseByIdAsync(id, cancellationToken);
            if( data == null)
            {
                return NotFound();
            }
            await _expenseRepository.DeleteExpense(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
