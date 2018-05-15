using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAspData.Entity
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Client Client { get; set; }
        public Days DaysRemove { get; set; }
        public DateTime DataCreated { get; set; }
        public List<File> Files { get; set; }
    }
}
