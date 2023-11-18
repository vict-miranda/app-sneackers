﻿// <auto-generated />
using System.Collections.Generic;
using AppSneackers.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppSneackers.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppSneackers.Domain.Entities.Sneacker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sneackers", (string)null);
                });

            modelBuilder.Entity("AppSneackers.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("Password");

                    b.ComplexProperty<Dictionary<string, object>>("Contact", "AppSneackers.Domain.Entities.User.Contact#Contact", b1 =>
                        {
                            b1.IsRequired();

                            b1.ComplexProperty<Dictionary<string, object>>("Address", "AppSneackers.Domain.Entities.User.Contact#Contact.Address#Address", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("City")
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar")
                                        .HasColumnName("City");

                                    b2.Property<string>("Country")
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar")
                                        .HasColumnName("Country");

                                    b2.Property<string>("Line1")
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar")
                                        .HasColumnName("Line1");

                                    b2.Property<string>("Line2")
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar")
                                        .HasColumnName("Line2");

                                    b2.Property<string>("PostCode")
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar")
                                        .HasColumnName("PostCode");
                                });

                            b1.ComplexProperty<Dictionary<string, object>>("MobilePhone", "AppSneackers.Domain.Entities.User.Contact#Contact.MobilePhone#PhoneNumber", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<int>("CountryCode")
                                        .HasColumnType("int")
                                        .HasColumnName("CountryCode");

                                    b2.Property<int>("Number")
                                        .HasColumnType("int")
                                        .HasColumnName("Number");
                                });
                        });

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AppSneackers.Domain.Entities.Sneacker", b =>
                {
                    b.HasOne("AppSneackers.Domain.Entities.User", "User")
                        .WithMany("Sneackers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppSneackers.Domain.Entities.User", b =>
                {
                    b.Navigation("Sneackers");
                });
#pragma warning restore 612, 618
        }
    }
}
