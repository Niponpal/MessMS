
using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken);
        Task<Purchase?> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken);
        Task<Purchase> AddPurchaseAsync(Purchase Purchase, CancellationToken cancellationToken);
        Task<Purchase?> UpdatePurchaseAsync(Purchase Purchase, CancellationToken cancellationToken);
        Task<Purchase> DeletePurchaseAsync(int id, CancellationToken cancellationToken);
    }
}
