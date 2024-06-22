using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Title { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Genre { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Language { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan Length { get; set; }
        [Required]
        public int AgeRestriction { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
