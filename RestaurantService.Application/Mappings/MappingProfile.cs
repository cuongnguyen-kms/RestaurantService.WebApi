using AutoMapper;
using RestaurantService.Application.DTOs;
using RestaurantService.Domain.Entities;

namespace RestaurantService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<MenuCategory, MenuCategoryDto>()
                .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.MenuItems));

            CreateMap<Address, AddressDto>()
                .ReverseMap();

            CreateMap<MenuItem, MenuItemDto>()
                .ReverseMap();
        }
    }
}
