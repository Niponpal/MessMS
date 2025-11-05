using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Purchase> AddPurchaseAsync(Purchase Purchase, CancellationToken cancellationToken)
        {
            await _context.Purchases.AddAsync(Purchase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Purchase;
        }

        public async Task<Purchase> DeletePurchaseAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Purchases.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Purchases.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Purchases.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Purchase?> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Purchases.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Purchase?> UpdatePurchaseAsync(Purchase Purchase, CancellationToken cancellationToken)
        {
            var data = await _context.Purchases.FindAsync(Purchase.Id, cancellationToken);
            if (data != null)
            {
                data.PurchaseDate = Purchase.PurchaseDate;
                data.Price = Purchase.Price;
                data.Quantity = Purchase.Quantity;

                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
