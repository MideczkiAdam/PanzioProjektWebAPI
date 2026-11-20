using Microsoft.EntityFrameworkCore;
using PanzioProjektWebAPI.Models;

namespace PanzioProjektWebAPI.Data
{
    public class PanzioDbContext : DbContext
    {
        public PanzioDbContext(DbContextOptions<PanzioDbContext> options) : base(options)
        {
            
        }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasIndex(r => r.Name).IsUnique();

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_RoomType_Capacity", "Capacity >= 1 AND Capacity <= 10");
                    t.HasCheckConstraint("CK_RoomType_PricePerNight", "PricePerNight > 0");
                    t.HasCheckConstraint("CK_RoomType_Name","length(Name) <= 50");
                });
            });
                

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(r => r.Number).IsUnique();

                entity.HasOne(r => r.RoomType)
                    .WithMany(rt => rt.Rooms)
                    .HasForeignKey(r => r.RoomTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasIndex(g => g.Email).IsUnique();

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Guest_Name", "length(Name) <= 100");
                });    
            });
                

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(b => b.Status)
                    .HasConversion<string>();

                entity.HasOne(b => b.Room)
                    .WithMany(r => r.Bookings)
                    .HasForeignKey(b => b.RoomId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Guest)
                    .WithMany(g => g.Bookings)
                    .HasForeignKey(b => b.GuestId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Booking_CheckOut", "CheckOut > CheckIn");
                    t.HasCheckConstraint("CK_Booking_NumberOfGuests", "NumberOfGuests >= 1");
                    t.HasCheckConstraint("CK_Booking_TotalPrice", "TotalPrice >= 0");
                });
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(r => r.Booking)
                    .WithOne(b => b.Review)
                    .HasForeignKey<Review>(r => r.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Review_Rating", "Rating >= 1 AND Rating <= 5");
                });
            });

            modelBuilder.Seed();

        }
    }
}
