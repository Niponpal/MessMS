using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken);
        Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken cancellationToken);
        Task<Supplier> AddSupplierAsync(Supplier Supplier, CancellationToken cancellationToken);
        Task<Supplier?> UpdateSupplierAsync(Supplier Supplier, CancellationToken cancellationToken);
        Task<Supplier> DeleteSupplierAsync(int id, CancellationToken cancellationToken);
    }
}
