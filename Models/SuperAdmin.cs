using System.Globalization;

namespace Resturant_Labb1.Models
{
    public class SuperAdmin
    {
        public int SuperAdminId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }


        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
