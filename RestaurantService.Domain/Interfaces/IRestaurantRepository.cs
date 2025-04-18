using RestaurantService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetRestaurantByIdAsync(Guid restaurantId);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(Guid restaurantId);
        Task<IEnumerable<MenuCategory>> GetMenuCategoriesByRestaurantIdAsync(Guid restaurantId);
        Task<MenuCategory?> GetMenuCategoryByIdAsync(Guid categoryId);
        Task AddMenuCategoryAsync(MenuCategory menuCategory);
        Task UpdateMenuCategoryAsync(MenuCategory menuCategory);
        Task DeleteMenuCategoryAsync(Guid categoryId);
    }
}
