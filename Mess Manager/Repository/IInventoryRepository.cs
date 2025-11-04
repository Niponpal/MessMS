using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllInventorysAsync(CancellationToken cancellationToken);
        Task<Inventory?> GetInventoryByIdAsync(int id, CancellationToken cancellationToken);
        Task<Inventory> AddInventoryAsync(Inventory Inventory, CancellationToken cancellationToken);
        Task<Inventory?> UpdateInventoryAsync(Inventory Inventory, CancellationToken cancellationToken);
        Task<Inventory> DeleteInventoryAsync(int id, CancellationToken cancellationToken);
    }
}

