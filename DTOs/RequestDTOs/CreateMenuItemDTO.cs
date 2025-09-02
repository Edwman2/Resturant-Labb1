using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CreateMenuItemDTO
    {
        [Required(ErrorMessage = "You have to insert a name")]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(5,10000, ErrorMessage ="Price must be at least 5")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Write a description")]
        public string Description { get; set; } = string.Empty;


    }
}
