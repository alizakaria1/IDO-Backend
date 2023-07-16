using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
           
        }

        public DbSet<User> User { get; set; }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Status> Status { get; set; }


    }
}
