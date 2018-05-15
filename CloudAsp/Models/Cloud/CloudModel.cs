using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CloudAspData.Entity;

namespace CloudAsp.Models.Cloud
{
    public class CloudModel
    {
        public Guid Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Вкажіть кількість днів від одного до семи")]
        public Days DaysRemove { get; set; } = Days.Day1;
        public List<File> Files { get; set; }
    }
}