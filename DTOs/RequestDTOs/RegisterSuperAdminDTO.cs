using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class RegisterSuperAdminDTO
    {
        [Required(ErrorMessage ="You have to register a username")]
        [MinLength(5, ErrorMessage = "Have to contain at least 5 characters"), MaxLength(30, ErrorMessage = "Username can't contain more than 30 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Has to register a password")]
        [MinLength(7, ErrorMessage = "Password has to contain at least 7 characters"), MaxLength(40, ErrorMessage = "Password can't contain more than 40 characters")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage ="You have to assign a role")]
        public string Role { get; set; }
    }
}
