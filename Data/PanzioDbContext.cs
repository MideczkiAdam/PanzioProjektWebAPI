using Microsoft.EntityFrameworkCore;
using PanzioProjektWebAPI.Models;

namespace PanzioProjektWebAPI.Data
{
    public class PanzioDbContext : DbContext
    {
        public PanzioDbContext(DbContextOptions<PanzioDbContext> options) : base(options)
        {
            
        }

        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Review> reviews { get; set; }
    }
}
