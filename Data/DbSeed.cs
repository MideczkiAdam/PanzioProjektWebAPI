using Microsoft.EntityFrameworkCore;
using PanzioProjektWebAPI.Models;

namespace PanzioProjektWebAPI.Data
{
    public static class DbSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasData(
            new RoomType { Id = 1, Name = "Egyágyas", Capacity = 1, PricePerNight = 12000, Description = "Kényelmes egyágyas szoba egy főnek." },
            new RoomType { Id = 2, Name = "Kétágyas", Capacity = 2, PricePerNight = 18000, Description = "Két külön ággyal vagy franciaággyal." },
            new RoomType { Id = 3, Name = "Családi", Capacity = 4, PricePerNight = 28000, Description = "Tágas szoba családoknak, pótággyal." },
            new RoomType { Id = 4, Name = "Apartman", Capacity = 6, PricePerNight = 42000, Description = "Különálló hálóval és konyhasarokkal." }
        );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Number = 101, Floor = 1, RoomTypeId = 1, IsActive = true },
                new Room { Id = 2, Number = 102, Floor = 1, RoomTypeId = 1, IsActive = true },
                new Room { Id = 3, Number = 103, Floor = 1, RoomTypeId = 2, IsActive = true },
                new Room { Id = 4, Number = 201, Floor = 2, RoomTypeId = 2, IsActive = true },
                new Room { Id = 5, Number = 202, Floor = 2, RoomTypeId = 2, IsActive = true },
                new Room { Id = 6, Number = 203, Floor = 2, RoomTypeId = 3, IsActive = true },
                new Room { Id = 7, Number = 301, Floor = 3, RoomTypeId = 3, IsActive = true },
                new Room { Id = 8, Number = 302, Floor = 3, RoomTypeId = 4, IsActive = true },
                new Room { Id = 9, Number = 303, Floor = 3, RoomTypeId = 4, IsActive = false }
            );

            modelBuilder.Entity<Guest>().HasData(
                new Guest { Id = 1, Name = "Kovács Anna", Email = "kovacs.anna@example.com", Phone = "+36301234567", RegisteredAt = new DateTime(2026, 9, 1, 10, 0, 0) },
                new Guest { Id = 2, Name = "Nagy Péter", Email = "nagy.peter@example.com", Phone = "+36202345678", RegisteredAt = new DateTime(2026, 9, 5, 14, 30, 0) },
                new Guest { Id = 3, Name = "Szabó Eszter", Email = "szabo.eszter@example.com", Phone = "+36703456789", RegisteredAt = new DateTime(2026, 9, 12, 9, 15, 0) },
                new Guest { Id = 4, Name = "Tóth Gábor", Email = "toth.gabor@example.com", Phone = null, RegisteredAt = new DateTime(2026, 9, 20, 18, 45, 0) },
                new Guest { Id = 5, Name = "Varga Katalin", Email = "varga.katalin@example.com", Phone = "+36304567890", RegisteredAt = new DateTime(2026, 10, 3, 11, 0, 0) },
                new Guest { Id = 6, Name = "Kiss Márton", Email = "kiss.marton@example.com", Phone = null, RegisteredAt = new DateTime(2026, 10, 15, 16, 20, 0) }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, GuestId = 1, RoomId = 1, CheckIn = new DateTime(2026, 10, 5), CheckOut = new DateTime(2026, 10, 8), NumberOfGuests = 1, Status = BookingStatus.CheckedOut, TotalPrice = 36000, CreatedAt = new DateTime(2026, 9, 20, 10, 0, 0) },
                new Booking { Id = 2, GuestId = 2, RoomId = 3, CheckIn = new DateTime(2026, 10, 10), CheckOut = new DateTime(2026, 10, 13), NumberOfGuests = 2, Status = BookingStatus.CheckedOut, TotalPrice = 54000, CreatedAt = new DateTime(2026, 9, 25, 12, 0, 0) },
                new Booking { Id = 3, GuestId = 3, RoomId = 6, CheckIn = new DateTime(2026, 10, 15), CheckOut = new DateTime(2026, 10, 20), NumberOfGuests = 4, Status = BookingStatus.CheckedOut, TotalPrice = 140000, CreatedAt = new DateTime(2026, 9, 28, 9, 30, 0) },
                new Booking { Id = 4, GuestId = 1, RoomId = 8, CheckIn = new DateTime(2026, 10, 25), CheckOut = new DateTime(2026, 10, 27), NumberOfGuests = 5, Status = BookingStatus.CheckedOut, TotalPrice = 84000, CreatedAt = new DateTime(2026, 10, 8, 15, 0, 0) },
                new Booking { Id = 5, GuestId = 4, RoomId = 4, CheckIn = new DateTime(2026, 11, 1), CheckOut = new DateTime(2026, 11, 4), NumberOfGuests = 2, Status = BookingStatus.CheckedOut, TotalPrice = 54000, CreatedAt = new DateTime(2026, 10, 12, 13, 10, 0) },

                new Booking { Id = 6, GuestId = 5, RoomId = 2, CheckIn = new DateTime(2026, 11, 18), CheckOut = new DateTime(2026, 11, 22), NumberOfGuests = 1, Status = BookingStatus.CheckedIn, TotalPrice = 48000, CreatedAt = new DateTime(2026, 11, 2, 10, 0, 0) },
                new Booking { Id = 7, GuestId = 2, RoomId = 5, CheckIn = new DateTime(2026, 11, 19), CheckOut = new DateTime(2026, 11, 21), NumberOfGuests = 2, Status = BookingStatus.CheckedIn, TotalPrice = 36000, CreatedAt = new DateTime(2026, 11, 5, 17, 40, 0) },

                new Booking { Id = 8, GuestId = 3, RoomId = 7, CheckIn = new DateTime(2026, 12, 20), CheckOut = new DateTime(2026, 12, 27), NumberOfGuests = 3, Status = BookingStatus.Confirmed, TotalPrice = 196000, CreatedAt = new DateTime(2026, 11, 10, 11, 0, 0) },
                new Booking { Id = 9, GuestId = 6, RoomId = 1, CheckIn = new DateTime(2026, 12, 1), CheckOut = new DateTime(2026, 12, 3), NumberOfGuests = 1, Status = BookingStatus.Confirmed, TotalPrice = 24000, CreatedAt = new DateTime(2026, 11, 12, 8, 50, 0) },

                new Booking { Id = 10, GuestId = 4, RoomId = 3, CheckIn = new DateTime(2026, 12, 5), CheckOut = new DateTime(2026, 12, 8), NumberOfGuests = 2, Status = BookingStatus.Pending, TotalPrice = 54000, CreatedAt = new DateTime(2026, 11, 18, 19, 5, 0) },

                new Booking { Id = 11, GuestId = 5, RoomId = 8, CheckIn = new DateTime(2026, 12, 10), CheckOut = new DateTime(2026, 12, 14), NumberOfGuests = 4, Status = BookingStatus.Cancelled, TotalPrice = 168000, CreatedAt = new DateTime(2026, 11, 8, 14, 0, 0) },
                new Booking { Id = 12, GuestId = 6, RoomId = 8, CheckIn = new DateTime(2026, 12, 10), CheckOut = new DateTime(2026, 12, 12), NumberOfGuests = 2, Status = BookingStatus.Confirmed, TotalPrice = 84000, CreatedAt = new DateTime(2026, 11, 14, 9, 0, 0) }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, BookingId = 1, Rating = 5, Comment = "Tiszta, csendes szoba, nagyon kedves személyzet.", CreatedAt = new DateTime(2026, 10, 9, 10, 0, 0) },
                new Review { Id = 2, BookingId = 2, Rating = 4, Comment = "Jó elhelyezkedés, a reggeli lehetett volna változatosabb.", CreatedAt = new DateTime(2026, 10, 14, 12, 30, 0) },
                new Review { Id = 3, BookingId = 3, Rating = 5, Comment = "A gyerekek imádták, bőven elfértünk négyen.", CreatedAt = new DateTime(2026, 10, 21, 18, 0, 0) },
                new Review { Id = 4, BookingId = 4, Rating = 3, Comment = null, CreatedAt = new DateTime(2026, 10, 28, 9, 20, 0) }
            );
        }
    }
}