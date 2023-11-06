using Microsoft.EntityFrameworkCore;
using WebApplicationCasusWasmachine.Models;

namespace WebApplicationCasusWasmachine.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) 
            : base(contextOptions) 
        {

        }

        public DbSet<Device> devices { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOne(o => o.User)
                .WithMany(v => v.Devices)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Goal>()
                .HasOne(o => o.User)
                .WithMany(v => v.Goals)
                .HasForeignKey(o => o.UserId);
        }


    }
}
