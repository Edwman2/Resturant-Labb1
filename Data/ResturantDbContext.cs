using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Data
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ResturantTable> ResturantTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
