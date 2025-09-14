using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service.Interface
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int code);
        Task<int> CreateAsync(MenuRequestModel entity);
        Task<int> UpdateAsync(int id, MenuRequestModel entity);
        Task<bool> DeleteAsync(int code);
    }
}
