using System.Globalization;

namespace Resturant_Labb1.Models
{
    public class SuperAdmin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
