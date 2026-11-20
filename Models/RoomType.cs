using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "A név nem lehet hosszabb 50 karakternél!")]
        public string Name { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "A kapacitásnak 1 és 10 között kell lennie!")]
        public int Capacity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Az árnak pozitív számnak kell lennie!")]
        public int PricePerNight { get; set; }
        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
