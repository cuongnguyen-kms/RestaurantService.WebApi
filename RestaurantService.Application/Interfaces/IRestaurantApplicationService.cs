using RestaurantService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Application.Interfaces
{
    public interface IRestaurantApplicationService
    {
        Task<RestaurantDto?> GetRestaurantByIdAsync(Guid restaurantId);
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
        Task AddRestaurantAsync(RestaurantDto restaurantDto);
        Task UpdateRestaurantAsync(RestaurantDto restaurantDto);
        Task DeleteRestaurantAsync(Guid restaurantId);
        Task<IEnumerable<MenuCategoryDto>> GetMenuCategoriesByRestaurantIdAsync(Guid restaurantId);
        Task<MenuCategoryDto?> GetMenuCategoryByIdAsync(Guid categoryId);
        Task AddMenuCategoryAsync(MenuCategoryDto menuCategoryDto);
        Task UpdateMenuCategoryAsync(MenuCategoryDto menuCategoryDto);
        Task DeleteMenuCategoryAsync(Guid categoryId);
    }
}
