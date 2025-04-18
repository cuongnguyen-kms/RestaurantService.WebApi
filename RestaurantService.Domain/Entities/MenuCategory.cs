using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Domain.Entities
{
    public class MenuCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign Key to Restaurant
        public Guid RestaurantId { get; set; }
        // Navigation Property back to the Restaurant (essential for EF Core)
        public Restaurant? Restaurant { get; set; }

        // Navigation Property to Menu Items within this category
        public List<MenuItem> MenuItems { get; set; } = [];
    }
}
