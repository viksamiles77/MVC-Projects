using DomainModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Age must be a positive number.")]
        public int? Age { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [MinLength(16)]
        [MaxLength(16)]
        public string? CardNumber { get; set; }
        [Required]
        //[RegularExpression("^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        [Required]
        public SubscriptionTypeEnum SubscriptionType { get; set; }
    }
}
