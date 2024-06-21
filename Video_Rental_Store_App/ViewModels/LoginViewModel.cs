using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string CardNumber { get; set; }
    }
}
