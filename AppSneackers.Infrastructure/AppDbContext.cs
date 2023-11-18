using AppSneackers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSneackers.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Sneacker> Sneackers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Sneacker>().ToTable("Sneackers");

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Sneacker>().HasKey(x => x.Id);

            modelBuilder.Entity<User>(
                b =>
                {
                    b.ComplexProperty(
                        e => e.Contact,
                        b =>
                        {
                            b.ComplexProperty(e => e.Address);
                            b.ComplexProperty(e => e.HomePhone);
                            b.ComplexProperty(e => e.WorkPhone);
                            b.ComplexProperty(e => e.MobilePhone);
                        });

                    //b.Property(x => x.Contact).IsRequired(false);
                });
          
        }
    }
}
