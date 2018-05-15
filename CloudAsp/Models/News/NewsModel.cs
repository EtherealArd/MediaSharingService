using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudAsp.Models.News
{
    public class NewsModel
    {
        public List<CloudAspData.Entity.News> News { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}