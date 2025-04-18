using RestaurantService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Application.DTOs
{
    public class MenuItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } // Optional description
        [Column(TypeName = "decimal(18, 2)")] // Specify SQL Server column type for price
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true; // Example: track item availability

        // Foreign Key to MenuCategory
        public Guid MenuCategoryId { get; set; }
        // Navigation Property back to the MenuCategory (essential for EF Core)
        public MenuCategoryDto? MenuCategory { get; set; }
    }
}
