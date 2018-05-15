using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAspData.Entity
{
    public enum Days
    {
        [Display(Name = "1 день")]
        Day1 = 1,
        [Display(Name = "3 дні")]
        Day3 = 3,
        [Display(Name = "7 днів")]
        Day7 = 7
    }
}
