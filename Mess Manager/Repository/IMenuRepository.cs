using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync(CancellationToken cancellationToken);
        Task<Menu?> GetMenuByIdAsync(int id, CancellationToken cancellationToken);
        Task<Menu> AddMenuAsync(Menu Menu, CancellationToken cancellationToken);
        Task<Menu?> UpdateMenuAsync(Menu Menu, CancellationToken cancellationToken);
        Task<Menu> DeleteMenuAsync(int id, CancellationToken cancellationToken);
    }
}
