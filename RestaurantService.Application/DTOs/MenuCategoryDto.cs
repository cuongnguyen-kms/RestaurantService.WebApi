using RestaurantService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Application.DTOs
{
    public class MenuCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign Key to Restaurant
        public Guid RestaurantId { get; set; }
        // Navigation Property back to the Restaurant (essential for EF Core)
        public RestaurantDto? Restaurant { get; set; }

        // Navigation Property to Menu Items within this category
        public List<MenuItemDto> MenuItems { get; set; } = [];
    }
}
