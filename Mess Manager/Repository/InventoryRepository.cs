using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Inventory> AddInventoryAsync(Inventory Inventory, CancellationToken cancellationToken)
        {
            await _context.Inventories.AddAsync(Inventory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Inventory;
        }

        public async Task<Inventory> DeleteInventoryAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Inventories.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Inventories.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventorysAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Inventories.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Inventories.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Inventory?> UpdateInventoryAsync(Inventory Inventory, CancellationToken cancellationToken)
        {
            var data = await _context.Inventories.FindAsync(Inventory.Id, cancellationToken);
            if (data != null)
            {
                data.ItemName= Inventory.ItemName;
                data.Quantity= Inventory.Quantity;
                data.Unit = Inventory.Unit;
                data.PurchaseDate= Inventory.PurchaseDate;
                data.ExpiryDate= Inventory.ExpiryDate;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
