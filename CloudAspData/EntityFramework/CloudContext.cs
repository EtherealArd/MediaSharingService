using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAspData.Entity;

namespace CloudAspData.EntityFramework
{
    public class CloudContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> News { get; set; }

        public CloudContext(): base("CloudDBConnectionString")
        {
            
        }
    }
}
