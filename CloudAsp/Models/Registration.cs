using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CloudAsp.Models
{
    public class Registration
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамілія")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "По батькові")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Пошта/Логін")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Remote("CheckUniqueEmail", "Client")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторіть пароль")]
        public string PasswordConfirm { get; set; }
    }
}