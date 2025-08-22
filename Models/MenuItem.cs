namespace Resturant_Labb1.Models
{
    public class MenuItem
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsPopular { get; set; }

        public string? ImageUrl { get; set; }

    }
}
