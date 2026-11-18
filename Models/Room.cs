using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; } // egyedi
        [Required]
        public int Floor { get; set; }
        [Required]
        public int RoomTypeId { get; set; } //idegen kulcs a RoomType táblára
        [Required]
        public bool IsActive { get; set; }
    }
}
