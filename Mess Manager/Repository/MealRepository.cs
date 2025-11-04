using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Meal> AddMealAsync(Meal Meal, CancellationToken cancellationToken)
        {
            await _context.Meals.AddAsync(Meal, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Meal;
        }

        public async Task<Meal> DeleteMealAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Meals.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Meals.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Meal>> GetAllMealsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Meals.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Meal?> GetMealByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Meals.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Meal?> UpdateMealAsync(Meal Meal, CancellationToken cancellationToken)
        {
            var data = await _context.Meals.FindAsync(Meal.Id, cancellationToken);
            if (data != null)
            {
                data.MealDate = Meal.MealDate;
                data.MealType = Meal.MealType;
                data.Quantity = Meal.Quantity;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
