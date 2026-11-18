using System.ComponentModel.DataAnnotations;

namespace PanzioProjektWebAPI.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "A név nem lehet hosszabb 100 karakternél!")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } // egyedi
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public DateTime RegisteredAt { get; set; }
    }
}
