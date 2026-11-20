using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.DTOs
{
    public class GetRoomDTO
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
