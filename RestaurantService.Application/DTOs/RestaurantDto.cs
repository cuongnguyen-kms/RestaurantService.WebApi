namespace RestaurantService.Application.DTOs
{
    public class RestaurantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CuisineType { get; set; } = string.Empty; // Consider an Enum or lookup table
        public AddressDto? Address { get; set; } // Navigation property
        public Guid AddressId { get; set; } // Foreign Key (if Address is separate entity)
        public List<MenuCategoryDto> MenuCategories { get; set; } = []; // Navigation property
        // public List<OperatingHours> OperatingHours { get; set; } = []; // Navigation property
        public string Status { get; set; } = string.Empty;
    }
}
