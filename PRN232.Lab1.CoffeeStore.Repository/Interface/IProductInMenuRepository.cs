using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Repository.Interface
{
    public interface IProductInMenuRepository : IGenericRepository<ProductInMenu>
    {
        Task<List<ProductInMenu>> GetAllAsync();
        Task<ProductInMenu> GetByIdAsync(int code);
    }
}
