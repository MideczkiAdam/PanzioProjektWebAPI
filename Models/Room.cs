using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
