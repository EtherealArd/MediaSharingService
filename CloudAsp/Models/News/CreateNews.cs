using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CloudAsp.Models.News
{
    public class CreateNews
    {
        [Required]
        [Display(Name = "Заголовок")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Текст")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Фото")]
        public HttpPostedFileBase File { get; set; }
    }
}