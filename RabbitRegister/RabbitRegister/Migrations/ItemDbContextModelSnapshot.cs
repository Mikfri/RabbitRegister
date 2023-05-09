﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitRegister.EFDbContext;

#nullable disable

namespace RabbitRegister.Migrations
{
    [DbContext(typeof(ItemDbContext))]
    partial class ItemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RabbitRegister.Model.Breeder", b =>
                {
                    b.Property<int>("BreederRegNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BreederRegNo"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("BreederRegNo");

                    b.ToTable("Breeder");
                });

            modelBuilder.Entity("RabbitRegister.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("City")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("ZipCode")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RabbitRegister.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BreederRegNo")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RabbitRegister.Model.Trimming", b =>
                {
                    b.Property<int>("TrimmingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrimmingId"));

                    b.Property<int>("BreederRegNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("DisposableWoolWeight")
                        .HasColumnType("float");

                    b.Property<double>("FirstSortmentWeight")
                        .HasColumnType("float");

                    b.Property<double?>("HairLengthByDayNinety")
                        .HasColumnType("float");

                    b.Property<int>("RabbitRegNo")
                        .HasColumnType("int");

                    b.Property<double>("SecondSortmentWeight")
                        .HasColumnType("float");

                    b.Property<double?>("TimeUsed")
                        .HasColumnType("float");

                    b.Property<string>("WoolDensity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrimmingId");

                    b.ToTable("Trimmings");
                });

            modelBuilder.Entity("RabbitRegister.Model.Wool", b =>
                {
                    b.HasBaseType("RabbitRegister.Model.Product");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.ToTable("Wools");
                });

            modelBuilder.Entity("RabbitRegister.Model.Yarn", b =>
                {
                    b.HasBaseType("RabbitRegister.Model.Product");

                    b.Property<string>("Fiber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("NeedleSize")
                        .HasColumnType("float");

                    b.Property<string>("Tension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Washing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YarnId")
                        .HasColumnType("int");

                    b.ToTable("Yarns");
                });

            modelBuilder.Entity("RabbitRegister.Model.Order", b =>
                {
                    b.HasOne("RabbitRegister.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RabbitRegister.Model.Wool", b =>
                {
                    b.HasOne("RabbitRegister.Model.Product", null)
                        .WithOne()
                        .HasForeignKey("RabbitRegister.Model.Wool", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RabbitRegister.Model.Yarn", b =>
                {
                    b.HasOne("RabbitRegister.Model.Product", null)
                        .WithOne()
                        .HasForeignKey("RabbitRegister.Model.Yarn", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
