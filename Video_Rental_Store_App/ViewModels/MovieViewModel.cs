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
        [Range(0, int.MaxValue, ErrorMessage = "Length must be a positive number.")]
        public int Length { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Age Restriction must be a positive number.")]
        public int AgeRestriction { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }
    }
}
