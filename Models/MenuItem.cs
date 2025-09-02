using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsPopular { get; set; } = false;

        public string? ImageUrl { get; set; }

    }
}
