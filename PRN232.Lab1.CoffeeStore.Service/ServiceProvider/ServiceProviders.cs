
using PRN232.Lab1.CoffeeStore.Service.Interface;

namespace PRN232.Lab1.CoffeeStore.Service.ServiceProviders
{
    public interface IServiceProviders
    {
        IMenuService MenuService { get; }
        IProductService ProductService { get; }
        IProductInMenuService ProductInMenuService { get; }
    }

    public class ServiceProviders : IServiceProviders
    {
        private readonly IMenuService _menuService;
        private readonly IProductService _productService;
        private readonly IProductInMenuService _productInMenuService;

        public ServiceProviders(IMenuService menuService, IProductService productService, IProductInMenuService productInMenuService)
        {
            _menuService = menuService;
            _productService = productService;
            _productInMenuService = productInMenuService;
        }

        public IMenuService MenuService => _menuService;
        public IProductService ProductService => _productService;
        public IProductInMenuService ProductInMenuService => _productInMenuService;

    }
}
