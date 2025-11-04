using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Menu> AddMenuAsync(Menu Menu, CancellationToken cancellationToken)
        {
            await _context.Menus.AddAsync(Menu, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Menu;
        }

        public async Task<Menu> DeleteMenuAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Menus.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Menus.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Menus.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Menu?> GetMenuByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Menus.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Menu?> UpdateMenuAsync(Menu Menu, CancellationToken cancellationToken)
        {
            var data = await _context.Menus.FindAsync(Menu.Id, cancellationToken);
            if (data != null)
            {
                data.MenuDate = Menu.MenuDate;
                data.MealType = Menu.MealType;
                data.ItemName = Menu.ItemName;
                data.Quantity = Menu.Quantity;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
