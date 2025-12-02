using Mess_Manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Manager.Repository
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken);
        Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken cancellationToken);
        Task<Supplier> AddSupplierAsync(Supplier Supplier, CancellationToken cancellationToken);
        Task<Supplier?> UpdateSupplierAsync(Supplier Supplier, CancellationToken cancellationToken);
        Task<Supplier> DeleteSupplierAsync(int id, CancellationToken cancellationToken);
        IEnumerable<SelectListItem> Dropdown();
    }
}
