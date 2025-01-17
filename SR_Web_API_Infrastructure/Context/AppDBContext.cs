using Microsoft.EntityFrameworkCore;
using SR_WebAPI_Domain.Entities;

namespace SR_WebAPI_Infrastructure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(c => c.Id);

            modelBuilder.Entity<Student>().Property(f => f.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }

    }
}
