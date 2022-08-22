using Microsoft.EntityFrameworkCore;

namespace SwagerAppV1._1.Model
{
    public class SwagerContext:DbContext
    {
        public SwagerContext(DbContextOptions<SwagerContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne<Groups>(s => s.Group)
                .WithMany(g => g.User)
                .HasForeignKey(s => s.IdGrupe).
                OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }

    }
}
