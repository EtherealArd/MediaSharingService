using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAspData.Entity
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
