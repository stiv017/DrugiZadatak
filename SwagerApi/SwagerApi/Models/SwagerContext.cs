using Microsoft.EntityFrameworkCore;


namespace SwagerApi.Models
{
    public class SwagerContext : DbContext
    {
        public SwagerContext(DbContextOptions<SwagerContext>options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; } 
        public DbSet<Groups> Groups { get; set; }
    }
}
