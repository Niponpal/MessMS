using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IMealRepository
    {
        Task<IEnumerable<Meal>> GetAllMealsAsync(CancellationToken cancellationToken);
        Task<Meal?> GetMealByIdAsync(int id, CancellationToken cancellationToken);
        Task<Meal> AddMealAsync(Meal Meal, CancellationToken cancellationToken);
        Task<Meal?> UpdateMealAsync(Meal Meal, CancellationToken cancellationToken);
        Task<Meal> DeleteMealAsync(int id, CancellationToken cancellationToken);
    }
}
