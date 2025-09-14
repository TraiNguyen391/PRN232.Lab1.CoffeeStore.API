using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Interface;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class ProductInMenuService : IProductInMenuService
    {
        private readonly ProductInMenuRepository _repository;

        public ProductInMenuService(ProductInMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductInMenu>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductInMenu> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid product in menu code");
            }
            return await _repository.GetByIdAsync(code);
        }

    }
}
