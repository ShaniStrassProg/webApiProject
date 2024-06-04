using AutoMapper;
using DTO;
using Repositories;

namespace LoginProject
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegister,User>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
         
         
            //.ForAllOtherMembers(opt => opt.Ignore()); // Ignore all other properties that do not match

           
        }

    }
}
