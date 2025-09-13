using PRN232.Lab1.CoffeeStore.Repository;
using PRN232.Lab1.CoffeeStore.Repository.Models;

namespace PRN232.Lab1.CoffeeStore.Service
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService() => _repository ??= new ProductRepository();

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<int> CreateAsync(Product entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _repository.GetByIdAsync(code);

            if (item != null)
            {
                return await _repository.RemoveAsync(item);
            }

            return false;
        }

    }
}
