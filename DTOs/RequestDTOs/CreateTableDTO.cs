using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CreateTableDTO
    {
        [Required]
        public int TableNumber { get; set; }

        [Required]
        [Range(2,10, ErrorMessage ="Has to contain at least 2 seats")] 
        public int Seats { get; set; }
    }
}
