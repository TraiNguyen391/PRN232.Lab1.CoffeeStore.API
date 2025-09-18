using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service.Interface;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class ProductInMenuService : IProductInMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductInMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductInMenu>> GetAllAsync()
        {
            return await _unitOfWork.ProductInMenuRepository.GetAllAsync();
        }

        public async Task<ProductInMenu> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid product in menu code");
            }
            return await _unitOfWork.ProductInMenuRepository.GetByIdAsync(code);
        }

    }
}
