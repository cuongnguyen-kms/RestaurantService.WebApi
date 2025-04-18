using Microsoft.EntityFrameworkCore;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Interfaces;

namespace RestaurantService.Infrastructure.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _context;

        public RestaurantRepository(RestaurantDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddMenuCategoryAsync(MenuCategory menuCategory)
        {
            await _context.MenuCategories.AddAsync(menuCategory);
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
        }

        public Task DeleteMenuCategoryAsync(Guid categoryId)
        {
            _context.MenuCategories.Remove(new MenuCategory { Id = categoryId });
            return Task.CompletedTask;
        }

        public Task DeleteRestaurantAsync(Guid restaurantId)
        {
            _context.Restaurants.Remove(new Restaurant { Id = restaurantId });
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants
                .Include(r => r.Address)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuCategory>> GetMenuCategoriesByRestaurantIdAsync(Guid restaurantId)
        {
            return await _context.MenuCategories
                .Where(mc => mc.RestaurantId == restaurantId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MenuCategory?> GetMenuCategoryByIdAsync(Guid categoryId)
        {
            return await _context.MenuCategories.FirstAsync(mc => mc.Id == categoryId);
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(Guid restaurantId)
        {
            return await _context.Restaurants
                .Include(r => r.Address)
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
        }

        public Task UpdateMenuCategoryAsync(MenuCategory menuCategory)
        {
            _context.Entry(menuCategory).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
