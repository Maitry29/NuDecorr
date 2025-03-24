﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrbanNest.DataAccess.Data;

#nullable disable

namespace UrbanNest.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UrbanNest.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DisplayOrder = 1,
                            Name = "Table"
                        },
                        new
                        {
                            ID = 2,
                            DisplayOrder = 2,
                            Name = "Chair"
                        },
                        new
                        {
                            ID = 3,
                            DisplayOrder = 1,
                            Name = "Sofa"
                        },
                        new
                        {
                            ID = 4,
                            DisplayOrder = 3,
                            Name = "Lamp"
                        },
                        new
                        {
                            ID = 5,
                            DisplayOrder = 1,
                            Name = "Bed"
                        });
                });

            modelBuilder.Entity("UrbanNest.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryId = 1,
                            Description = "A high-quality wooden dining table with a modern design.",
                            ImageURL = "/images/products/Table.jpg",
                            Price = 19999.99m,
                            Title = "Wooden Dining Table"
                        },
                        new
                        {
                            ID = 2,
                            CategoryId = 2,
                            Description = "A comfortable and elegant sofa set for your living room.",
                            ImageURL = "/images/products/Sofa.jpg",
                            Price = 29999.99m,
                            Title = "Luxury Sofa Set"
                        },
                        new
                        {
                            ID = 3,
                            CategoryId = 3,
                            Description = "Ergonomic office chair with adjustable height and back support.",
                            ImageURL = "/images/products/Chair.jpg",
                            Price = 7999.99m,
                            Title = "Office Chair"
                        },
                        new
                        {
                            ID = 4,
                            CategoryId = 4,
                            Description = "Ergonomic lamp with adjustable height.",
                            ImageURL = "/images/products/Lamp.jpg",
                            Price = 7999.99m,
                            Title = "Lamp"
                        },
                        new
                        {
                            ID = 5,
                            CategoryId = 3,
                            Description = "Comfortable bed with back support.",
                            ImageURL = "/images/products/Bed.jpg",
                            Price = 7999.99m,
                            Title = "Bed"
                        });
                });

            modelBuilder.Entity("UrbanNest.Models.Product", b =>
                {
                    b.HasOne("UrbanNest.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
