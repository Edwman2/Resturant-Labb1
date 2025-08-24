using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.Customers
{
    public class ResponseCustomerDTO
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
        public string Email { get; set; }
    }
}
