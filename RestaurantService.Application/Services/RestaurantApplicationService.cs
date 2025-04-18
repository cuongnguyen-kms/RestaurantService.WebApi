using AutoMapper;
using RestaurantService.Application.DTOs;
using RestaurantService.Application.Interfaces;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Interfaces;

namespace RestaurantService.Application.Services
{
    public class RestaurantApplicationService : IRestaurantApplicationService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantApplicationService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }
        public async Task AddMenuCategoryAsync(MenuCategoryDto menuCategoryDto)
        {
            var menuCategory = _mapper.Map<MenuCategory>(menuCategoryDto);
            await _restaurantRepository.AddMenuCategoryAsync(menuCategory);
        }

        public async Task AddRestaurantAsync(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _restaurantRepository.AddRestaurantAsync(restaurant);
        }

        public Task DeleteMenuCategoryAsync(Guid categoryId)
        {
            return _restaurantRepository.DeleteMenuCategoryAsync(categoryId);
        }

        public Task DeleteRestaurantAsync(Guid restaurantId)
        {
            return _restaurantRepository.DeleteRestaurantAsync(restaurantId);
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();
            return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }

        public async Task<IEnumerable<MenuCategoryDto>> GetMenuCategoriesByRestaurantIdAsync(Guid restaurantId)
        {
            var menuCategories = await _restaurantRepository.GetMenuCategoriesByRestaurantIdAsync(restaurantId);
            return _mapper.Map<IEnumerable<MenuCategoryDto>>(menuCategories);
        }

        public async Task<MenuCategoryDto?> GetMenuCategoryByIdAsync(Guid categoryId)
        {
            var menuCategory = await _restaurantRepository.GetMenuCategoryByIdAsync(categoryId);
            return _mapper.Map<MenuCategoryDto>(menuCategory);
        }

        public async Task<RestaurantDto?> GetRestaurantByIdAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public Task UpdateMenuCategoryAsync(MenuCategoryDto menuCategoryDto)
        {
            var menuCategory = _mapper.Map<MenuCategory>(menuCategoryDto);
            return _restaurantRepository.UpdateMenuCategoryAsync(menuCategory);
        }

        public Task UpdateRestaurantAsync(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            return _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }
    }
}
