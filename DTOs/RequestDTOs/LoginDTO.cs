using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="You have to insert a username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="You have to insert a passowrd")]
        public string PasswordHash { get; set; }
    }
}
