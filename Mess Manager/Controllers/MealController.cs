using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealRepository _mealRepository;
        public MealController(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetAllMealsAsync(cancellationToken);
            return View(meals);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Attendance());
            }
            var meals = await _mealRepository.GetMealByIdAsync(id, cancellationToken);
            if (meals == null)
            {
                return NotFound();
            }
            return View(meals);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Meal meal, CancellationToken cancellationToken)
        {
            if (meal.Id == 0)
            {
                await _mealRepository.AddMealAsync(meal, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _mealRepository.UpdateMealAsync(meal, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _mealRepository.GetMealByIdAsync(id, cancellationToken);
            if (data != null)
            {
                await _mealRepository.DeleteMealAsync(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealByIdAsync(id, cancellationToken);
            if (meals == null)
            {
                return NotFound();
            }
            return View(meals);

        }
    }
}
