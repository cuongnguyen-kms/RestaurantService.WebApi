using Microsoft.AspNetCore.Mvc;
using RestaurantService.Application.DTOs;
using RestaurantService.Application.Interfaces;

namespace RestaurantService.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantApplicationService _restaurantService;
        private readonly ILogger<RestaurantsController> _logger;

        public RestaurantsController(IRestaurantApplicationService restaurantApplicationService, ILogger<RestaurantsController> logger)
        {
            _restaurantService = restaurantApplicationService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RestaurantDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRestaurants(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all restaurants");
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        // GET /api/v1/restaurants/{id}
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRestaurantById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching restaurant with ID: {RestaurantId}", id);
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                _logger.LogWarning("Restaurant with ID: {RestaurantId} not found", id);
                return NotFound();
            }
            return Ok(restaurant);
        }

        // GET /api/v1/restaurants/{restaurantId}/menu
        [HttpGet("{restaurantId:guid}/menu")]
        [ProducesResponseType(typeof(List<MenuItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // If restaurant doesn't exist
        public async Task<IActionResult> GetRestaurantMenu(Guid restaurantId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching menu for restaurant ID: {RestaurantId}", restaurantId);
            // Add check if restaurant exists first if needed, or let service handle it
            try
            {
                var menu = await _restaurantService.GetMenuCategoriesByRestaurantIdAsync(restaurantId);
                // Decide if empty menu is OK (200) or NotFound (404) based on requirements
                return Ok(menu);
            }
            catch (KeyNotFoundException ex) // Example: Catch specific exception from service
            {
                _logger.LogWarning(ex, "Restaurant not found when fetching menu for ID: {RestaurantId}", restaurantId);
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
