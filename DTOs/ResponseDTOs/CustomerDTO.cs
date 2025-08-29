using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.Response
{
    public class CustomerDTO
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
    }
}
