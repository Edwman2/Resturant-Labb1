namespace Resturant_Labb1.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public bool IsRevoked { get; set; }

        public int SuperAdminId { get; set; }
        public SuperAdmin SuperAdmin { get; set; }

    }
}
