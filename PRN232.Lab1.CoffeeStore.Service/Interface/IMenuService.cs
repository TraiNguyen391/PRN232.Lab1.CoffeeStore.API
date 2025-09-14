using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel;

namespace PRN232.Lab1.CoffeeStore.Service.Interface
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllAsync();
        Task<MenuResponseModel> GetByIdAsync(int code);
        Task<Menu> CreateAsync(MenuRequestModel entity);
        Task<Menu> UpdateAsync(int id, MenuRequestModel entity);
        Task<bool> DeleteAsync(int code);
    }
}
