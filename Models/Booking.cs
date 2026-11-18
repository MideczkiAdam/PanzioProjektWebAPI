using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public enum BookingStatus
    {
        [Display(Name = "Függő")]
        Pending,
        [Display(Name = "Megerősített")]
        Confirmed,
        [Display(Name = "Bejelentkezett")]
        CheckedIn,
        [Display(Name = "Kijelentkezett")]
        CheckedOut,
        [Display(Name = "Lemondott")]
        Cancelled
    }
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public int GuestId { get; set; } // idegen kulcs a Guest táblára
        [Required]
        public int RoomId { get; set; } // idegen kulcs a Room táblára
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; } // a CheckOut dátumának nagyobbnak kell lennie, mint a CheckIn dátumának
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A vendégek számának legalább 1-nek kell lennie!")]
        public int NumberOfGuests { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Az árnak nem negatív számnak kell lennie!")]
        public int TotalPrice { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public Review? Review { get; set; }
    }
}
