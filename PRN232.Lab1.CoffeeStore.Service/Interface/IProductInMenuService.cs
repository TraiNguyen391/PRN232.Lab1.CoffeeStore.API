using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Service.Interface
{
    public interface IProductInMenuService
    {
        Task<List<ProductInMenu>> GetAllAsync();
        Task<ProductInMenu> GetByIdAsync(int code);
    }
}
