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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

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
                });

            //modelBuilder.Entity<Sneacker>(
            //    b =>
            //    {
            //        b.ComplexProperty(e => e.ContactPhone);
            //        b.ComplexProperty(e => e.BillingAddress);
            //        b.ComplexProperty(e => e.ShippingAddress);
            //    });


            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            modelBuilder.Entity<Customer>(
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
                });

            modelBuilder.Entity<Order>(
                b =>
                {
                    b.ComplexProperty(e => e.ContactPhone);
                    b.ComplexProperty(e => e.BillingAddress);
                    b.ComplexProperty(e => e.ShippingAddress);
                });
        }
    }
}
