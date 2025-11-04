using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public class MealRepository : IMealRepository
    {
        public Task<Meal> AddMealAsync(Meal Meal, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Meal> DeleteMealAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Meal>> GetAllMealsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Meal?> GetMealByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Meal?> UpdateMealAsync(Meal Meal, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
