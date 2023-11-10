using Hackathon.EF_Core.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.EF_Core.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<UserDbo> Users { get; set; }
        public DbSet<PointDbo> Points { get; set; }
        public DbSet<PointAttributeDbo> PointAttributes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Hackathon.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable("Users");
            modelBuilder.Entity<PointDbo>().ToTable("Points");
            modelBuilder.Entity<PointAttributeDbo>().ToTable("PointAttributes");
        }
    }
}
