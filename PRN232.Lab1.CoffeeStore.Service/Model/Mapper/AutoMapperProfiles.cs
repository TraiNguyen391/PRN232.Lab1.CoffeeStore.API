using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel;

namespace PRN232.Lab1.CoffeeStore.Service.Model.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductRequestModel>();
            CreateMap<ProductRequestModel, Product>();

            CreateMap<Menu, MenuResponseModel>().ForMember(p => p.Products, opt => opt.MapFrom(src => src.ProductInMenus));
            CreateMap<ProductInMenu, MenuProductResponseModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<MenuRequestModel, Menu>()
            .ForMember(dest => dest.MenuId, opt => opt.Ignore())
            .ForMember(dest => dest.ProductInMenus,
                       opt => opt.MapFrom(src => src.Products));

            CreateMap<MenuProductRequestModel, ProductInMenu>()
                .ForMember(dest => dest.ProductInMenuId, opt => opt.Ignore())
                .ForMember(dest => dest.MenuId, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Menu, opt => opt.Ignore());

        }
    }
}
