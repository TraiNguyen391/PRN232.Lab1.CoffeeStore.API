using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly MenuRepository _repository;
        private readonly IMapper _mapper;
        public MenuService(MenuRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> CreateAsync(MenuRequestModel entity)
        {
            var menu = _mapper.Map<Menu>(entity);
            return await _repository.CreateAsync(menu);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _repository.GetByIdAsync(code);
            if (item != null)
            {
                var result = await _repository.RemoveAsync(item);
                if (result)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Menu> GetByIdAsync(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Invalid menu code");
            }
            return await _repository.GetByIdAsync(code);
        }

        public Task<int> UpdateAsync(int id, MenuRequestModel entity)
        {
            var menu = _mapper.Map<Menu>(entity);
            menu.MenuId = id;
            return _repository.UpdateAsync(menu);
        }
    }
}
