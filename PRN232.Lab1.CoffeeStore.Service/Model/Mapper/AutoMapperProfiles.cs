using AutoMapper;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.Service.Model.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductRequestModel>();
            CreateMap<ProductRequestModel, Product>();

            CreateMap<Menu, MenuRequestModel>();
            CreateMap<MenuRequestModel, Menu>();
        }
    }
}
