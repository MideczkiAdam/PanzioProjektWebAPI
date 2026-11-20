using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PanzioProjektWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Email", "Name", "Phone", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, "kovacs.anna@example.com", "Kovács Anna", "+36301234567", new DateTime(2026, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "nagy.peter@example.com", "Nagy Péter", "+36202345678", new DateTime(2026, 9, 5, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "szabo.eszter@example.com", "Szabó Eszter", "+36703456789", new DateTime(2026, 9, 12, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "toth.gabor@example.com", "Tóth Gábor", null, new DateTime(2026, 9, 20, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "varga.katalin@example.com", "Varga Katalin", "+36304567890", new DateTime(2026, 10, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "kiss.marton@example.com", "Kiss Márton", null, new DateTime(2026, 10, 15, 16, 20, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Capacity", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1, "Kényelmes egyágyas szoba egy főnek.", "Egyágyas", 12000 },
                    { 2, 2, "Két külön ággyal vagy franciaággyal.", "Kétágyas", 18000 },
                    { 3, 4, "Tágas szoba családoknak, pótággyal.", "Családi", 28000 },
                    { 4, 6, "Különálló hálóval és konyhasarokkal.", "Apartman", 42000 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsActive", "Number", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1, true, 101, 1 },
                    { 2, 1, true, 102, 1 },
                    { 3, 1, true, 103, 2 },
                    { 4, 2, true, 201, 2 },
                    { 5, 2, true, 202, 2 },
                    { 6, 2, true, 203, 3 },
                    { 7, 3, true, 301, 3 },
                    { 8, 3, true, 302, 4 },
                    { 9, 3, false, 303, 4 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "CreatedAt", "GuestId", "NumberOfGuests", "RoomId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "CheckedOut", 36000 },
                    { 2, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3, "CheckedOut", 54000 },
                    { 3, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4, 6, "CheckedOut", 140000 },
                    { 4, new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 8, "CheckedOut", 84000 },
                    { 5, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 12, 13, 10, 0, 0, DateTimeKind.Unspecified), 4, 2, 4, "CheckedOut", 54000 },
                    { 6, new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 2, "CheckedIn", 48000 },
                    { 7, new DateTime(2026, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 5, 17, 40, 0, 0, DateTimeKind.Unspecified), 2, 2, 5, "CheckedIn", 36000 },
                    { 8, new DateTime(2026, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 7, "Confirmed", 196000 },
                    { 9, new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 12, 8, 50, 0, 0, DateTimeKind.Unspecified), 6, 1, 1, "Confirmed", 24000 },
                    { 10, new DateTime(2026, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 18, 19, 5, 0, 0, DateTimeKind.Unspecified), 4, 2, 3, "Pending", 54000 },
                    { 11, new DateTime(2026, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 8, "Cancelled", 168000 },
                    { 12, new DateTime(2026, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 8, "Confirmed", 84000 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "CreatedAt", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Tiszta, csendes szoba, nagyon kedves személyzet.", new DateTime(2026, 10, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, 2, "Jó elhelyezkedés, a reggeli lehetett volna változatosabb.", new DateTime(2026, 10, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 3, "A gyerekek imádták, bőven elfértünk négyen.", new DateTime(2026, 10, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, 4, null, new DateTime(2026, 10, 28, 9, 20, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
