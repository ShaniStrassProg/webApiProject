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
            //CreateMap<UserUpdate, User>().ReverseMap();
        }

    }
}
