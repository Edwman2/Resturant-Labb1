namespace Resturant_Labb1.DTOs.ResponseDTOs
{
    public class MenuItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
    }
}
