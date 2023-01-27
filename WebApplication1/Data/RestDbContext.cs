using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;

namespace WebApplication1.Data
{
    public class RestDbContext: DbContext
    {
        public RestDbContext(DbContextOptions<RestDbContext> options) : base(options)
        {

        }

        public DbSet<Item> item { get; set; }
        public DbSet<order> order { get; set; }
        public DbSet<orderItem> orderItem { get; set; }
        public DbSet<orderStatus> orderStatus { get; set; }
        public DbSet<bill> bill { get; set; }
 
    }
}
