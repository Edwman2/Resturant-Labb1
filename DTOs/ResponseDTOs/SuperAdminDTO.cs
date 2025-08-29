namespace Resturant_Labb1.DTOs.ResponseDTOs
{
    public class SuperAdminDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
