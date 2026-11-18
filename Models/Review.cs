using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int BookingId { get; set; } // idegen kulcss a Booking táblára
        [Required]
        [Range(1, 5, ErrorMessage = "A minősítésnek 1 és 5 között kell lennie!")]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Booking Booking { get; set; }
    }
}
