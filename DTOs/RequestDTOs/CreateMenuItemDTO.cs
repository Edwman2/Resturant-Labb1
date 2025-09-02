namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CreateMenuItemDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsPopular { get; set; }


    }
}
