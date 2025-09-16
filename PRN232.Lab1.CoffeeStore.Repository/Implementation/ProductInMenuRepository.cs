using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Repository.Implementation
{
    public class ProductInMenuRepository : GenericRepository<ProductInMenu>
    {
        public ProductInMenuRepository(CoffeeStoreDBContext context) : base(context) { }

        public async Task<List<ProductInMenu>> GetAllAsync()
        {
            var item = await _context.ProductInMenus.ToListAsync();
            return item ?? new List<ProductInMenu>();
        }

        public async Task<ProductInMenu> GetByIdAsync(int code)
        {
            var item = await _context.ProductInMenus
                .Include(d => d.Product)
                .Include(d => d.Menu)
                .FirstOrDefaultAsync(d => d.ProductInMenuId == code);
            return item ?? new ProductInMenu();
        }

    }
}
