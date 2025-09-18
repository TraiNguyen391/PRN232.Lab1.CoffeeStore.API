using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Menu> CreateAsync(MenuRequestModel model)
        {
            var menu = _mapper.Map<Menu>(model);

            var productInMenus = model.Products
                .Select(p => _mapper.Map<ProductInMenu>(p))
                .ToList();

            menu.ProductInMenus = productInMenus;

            await _unitOfWork.MenuRepository.CreateAsync(menu);
            await _unitOfWork.SaveChangeAsync();
            return menu;
        }


        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _unitOfWork.MenuRepository.GetByIdAsync(code);

            var oldProducts = item.ProductInMenus.ToList();

            // delete all old products in menu
            foreach (var old in oldProducts)
            {
                await _unitOfWork.ProductInMenuRepository.RemoveAsync(old);
            }

            if (item != null)
            {
                var result = await _unitOfWork.MenuRepository.RemoveAsync(item);
                if (result)
                {
                    await _unitOfWork.SaveChangeAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _unitOfWork.MenuRepository.GetAllAsync();
        }

        public async Task<MenuResponseModel> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid menu code");
            }

            var result = await _unitOfWork.MenuRepository.GetByIdAsync(code);

            return _mapper.Map<MenuResponseModel>(result);
        }

        public async Task<int> UpdateAsync(int id, MenuRequestModel request)
        {
            var existingMenu = await _unitOfWork.MenuRepository
                .GetByIdAsync(id);

            if (existingMenu == null)
                throw new KeyNotFoundException($"Menu with id {id} not found");

            // Update field 
            existingMenu.Name = request.Name;
            existingMenu.FromDate = request.FromDate;
            existingMenu.ToDate = request.ToDate;

            // Get all old products in menu
            var oldProducts = existingMenu.ProductInMenus.ToList();

            // delete all old products in menu
            foreach (var old in oldProducts)
            {
                await _unitOfWork.ProductInMenuRepository.RemoveAsync(old);
            }

            // Add new products in menu
            foreach (var prod in request.Products)
            {
                existingMenu.ProductInMenus.Add(new ProductInMenu
                {
                    ProductId = prod.ProductId,
                    MenuId = id,
                    Quantity = prod.Quantity
                });
            }

            await _unitOfWork.MenuRepository.UpdateAsync(existingMenu);
            return await _unitOfWork.SaveChangeAsync();
        }

    }
}
