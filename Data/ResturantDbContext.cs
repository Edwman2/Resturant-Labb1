using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Data
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Table> tables { get; set; }
        public DbSet<MenuItem> menuItems { get; set; }
    }
}
