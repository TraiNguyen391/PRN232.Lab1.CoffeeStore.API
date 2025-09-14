using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Repository.Implementation
{
    public class MenuRepository : GenericRepository<Menu>
    {
        public MenuRepository() { }
        public MenuRepository(CoffeeStoreDBContext context) => _context = context;
        public async Task<List<Menu>> GetAllAsync()
        {
            var item = await _context.Menus.ToListAsync();
            return item ?? new List<Menu>();
        }
        public async Task<Menu> GetByIdAsync(int code)
        {
            var item = await _context.Menus
                .Include(d => d.ProductInMenus).ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(d => d.MenuId == code);
            return item ?? new Menu();
        }

    }
}
