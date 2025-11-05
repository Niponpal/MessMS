using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Supplier> AddSupplierAsync(Supplier Supplier, CancellationToken cancellationToken)
        {
            await _context.Suppliers.AddAsync(Supplier, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Supplier;
        }

        public async Task<Supplier> DeleteSupplierAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Suppliers.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Suppliers.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Suppliers.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Suppliers.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Supplier?> UpdateSupplierAsync(Supplier Supplier, CancellationToken cancellationToken)
        {
            var data = await _context.Suppliers.FindAsync(Supplier.Id, cancellationToken);
            if (data != null)
            {
                data.SupplierName = Supplier.SupplierName;
                data.PhoneNumber = Supplier.PhoneNumber;
                data.Email = Supplier.Email;
                data.Address = Supplier.Address;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
