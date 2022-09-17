namespace ProductShop
{
    using AutoMapper;

    using ProductShop.DataTransferObjects;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Setting mappers for importing
            this.CreateMap<UserDTO, User>();
            this.CreateMap<ProductDto, Product>();
            this.CreateMap<CategoryDto, Category>();
            this.CreateMap<CategoryProductDto, CategoryProduct>();
        }
    }
}
