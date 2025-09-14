using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int code);
        Task<int> CreateAsync(ProductRequestModel entity);
        Task<int> UpdateAsync(int id, ProductRequestModel entity);
        Task<bool> DeleteAsync(int code);
    }
}