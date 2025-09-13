using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository() { }

        public ProductRepository(CoffeeStore2DBContext context) => _context = context;

        public async Task<List<Product>> GetAllAsync()
        {
            var item = await _context.Products.Include(c => c.Category).ToListAsync();
            return item ?? new List<Product>();
        }

        public async Task<Product> GetByIdAsync(int code)
        {
            var item = await _context.Products
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.ProductId == code);

            return item ?? new Product();
        }

    }

}
