using System.ComponentModel.DataAnnotations;

namespace CloudAsp.Models
{
    public class Authorisation
    {
        [Required]
        [Display(Name = "Логін")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}