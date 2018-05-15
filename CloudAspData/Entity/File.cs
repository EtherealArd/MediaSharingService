using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAspData.Entity
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? RoomId { get; set; }
        public Room Room { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
