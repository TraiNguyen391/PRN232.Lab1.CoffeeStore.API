using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid product code");
            }   
            return await _unitOfWork.ProductRepository.GetByIdAsync(code);
        }

        public async Task<int> CreateAsync(ProductRequestModel entity)
        {
            var product = _mapper.Map<Product>(entity);
            await _unitOfWork.ProductRepository.CreateAsync(product);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<int> UpdateAsync(int id, ProductRequestModel entity)
        {
            var item = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (item == null) return 0;

            _mapper.Map(entity, item);

            await _unitOfWork.ProductRepository.UpdateAsync(item);
            return await _unitOfWork.SaveChangeAsync();
        }


        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _unitOfWork.ProductRepository.GetByIdAsync(code);

            if (item != null)
            {
                await _unitOfWork.ProductRepository.RemoveAsync(item);
                await _unitOfWork.SaveChangeAsync();
                return true;
            }

            return false;
        }

    }
}
