using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAspData.Entity
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public DateTime? DateCreate { get; set; }
        public byte[] Image { get; set; }
    }
}
