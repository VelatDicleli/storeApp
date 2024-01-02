using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;
using System.Runtime.InteropServices;

namespace StoreApp.Infrastructer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap(); //iki yönlü mapleme
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserDto, IdentityUser>().ReverseMap();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();

        }
    }
}
