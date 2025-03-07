﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuDecorr.DataAccess.Data;

#nullable disable

namespace NuDecorr.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250306115447_addProductTableToDb")]
    partial class addProductTableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NuDecorr.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Table"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Chair"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 1,
                            Name = "Sofa"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 3,
                            Name = "Lamp"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 1,
                            Name = "Bed"
                        });
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
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

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Description = "A high-quality wooden dining table with a modern design.",
                            ImageURL = "https://example.com/images/dining-table.jpg",
                            Price = 19999.99m,
                            Title = "Wooden Dining Table"
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 2,
                            Description = "A comfortable and elegant sofa set for your living room.",
                            ImageURL = "https://example.com/images/sofa-set.jpg",
                            Price = 29999.99m,
                            Title = "Luxury Sofa Set"
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 3,
                            Description = "Ergonomic office chair with adjustable height and back support.",
                            ImageURL = "https://example.com/images/office-chair.jpg",
                            Price = 7999.99m,
                            Title = "Office Chair"
                        });
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("NuDecorr.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
