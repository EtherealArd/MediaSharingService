using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudAspData.Entity;

namespace CloudAsp.Models.Cloud
{
    public class FileModel
    {
        public byte[] File { get; set; }
        public string Name { get; set; }
        public FileType Type { get; set; }
    }
}