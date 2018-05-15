using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CloudAsp.Models.News
{
    public class EditNews
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Текст")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "Фото")]
        public byte[] Image { get; set; }
    }
}