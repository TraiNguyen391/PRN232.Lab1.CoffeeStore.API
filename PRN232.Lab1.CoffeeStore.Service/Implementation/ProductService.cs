using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid product code");
            }   
            return await _repository.GetByIdAsync(code);
        }

        public async Task<int> CreateAsync(ProductRequestModel entity)
        {
            var product = _mapper.Map<Product>(entity);
            return await _repository.CreateAsync(product);
        }

        public async Task<int> UpdateAsync(int id, ProductRequestModel entity)
        {
            var product = _mapper.Map<Product>(entity);
            product.ProductId = id;
            return await _repository.UpdateAsync(product);
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
