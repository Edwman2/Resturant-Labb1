namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class RegisterSuperAdminDTO
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
