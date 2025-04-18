using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Domain.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CuisineType { get; set; } = string.Empty; // Consider an Enum or lookup table
        public Address? Address { get; set; } // Navigation property
        public Guid AddressId { get; set; } // Foreign Key (if Address is separate entity)
        public List<MenuCategory> MenuCategories { get; set; } = []; // Navigation property
        // public List<OperatingHours> OperatingHours { get; set; } = []; // Navigation property
        public AvailabilityStatus Status { get; set; } = AvailabilityStatus.Closed;
    }
}
