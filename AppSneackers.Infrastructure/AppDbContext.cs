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
                            b.ComplexProperty(e => e.Address).Property(x => x.Line1)
                                .HasColumnName("Line1")
                                .HasColumnType("varchar")
                                .HasMaxLength(200)
                                .IsRequired(false);

                            b.ComplexProperty(e => e.Address).Property(x => x.PostCode)
                                .HasColumnName("PostCode")
                                .HasColumnType("varchar")
                                .HasMaxLength(200)
                                .IsRequired(false);

                            b.ComplexProperty(e => e.Address).Property(x => x.City)
                                .HasColumnName("City")
                                .HasColumnType("varchar")
                                .HasMaxLength(200)
                                .IsRequired(false);

                            b.ComplexProperty(e => e.Address).Property(x => x.Country)
                                .HasColumnName("Country")
                                .HasColumnType("varchar")
                                .HasMaxLength(200)
                                .IsRequired(false);

                            b.ComplexProperty(e => e.Address).Property(x => x.Line2)
                                .HasColumnName("Line2")
                                .HasColumnType("varchar")
                                .HasMaxLength(200)
                                .IsRequired(false);

                            b.ComplexProperty(e => e.MobilePhone).Property(x => x.CountryCode)
                                .HasColumnName("CountryCode")
                                .HasColumnType("int");

                            b.ComplexProperty(e => e.MobilePhone).Property(x => x.Number)
                                .HasColumnName("Number")
                                .HasColumnType("int");
                        });
                });

            modelBuilder.Entity<User>().Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>().Property(p => p.LastName)
               .HasColumnName("LastName")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<User>().Property(p => p.Email)
               .HasColumnName("Email")
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsRequired();

            modelBuilder.Entity<User>().Property(p => p.Password)
               .HasColumnName("Password")
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsRequired();

        }
    }
}
