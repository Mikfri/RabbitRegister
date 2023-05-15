﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitRegister.EFDbContext;

#nullable disable

namespace RabbitRegister.Migrations
{
    [DbContext(typeof(ItemDbContext))]
    [Migration("20230515105330_RabbitReg")]
    partial class RabbitReg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("RabbitId")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("BreederRegNo");

                    b.HasIndex("RabbitId");

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

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

                    b.ToTable("Product");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RabbitRegister.Model.Rabbit", b =>
                {
                    b.Property<int>("RabbitRegNo")
                        .HasColumnType("int");

                    b.Property<int>("BreederRegNo")
                        .HasColumnType("int");

                    b.Property<string>("CauseOfDeath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeadOrAlive")
                        .HasColumnType("int");

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsForSale")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Owner")
                        .HasColumnType("bit");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SuitableForBreeding")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("RabbitRegNo");

                    b.ToTable("Rabbits");
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("RabbitRegister.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RabbitRegister.Model.Wool", b =>
                {
                    b.HasBaseType("RabbitRegister.Model.Product");

                    b.Property<string>("ImgString")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ImgString")
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

                    b.ToTable("Yarns");
                });

            modelBuilder.Entity("RabbitRegister.Model.Breeder", b =>
                {
                    b.HasOne("RabbitRegister.Model.Rabbit", "Rabbit")
                        .WithMany()
                        .HasForeignKey("RabbitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rabbit");
                });

            modelBuilder.Entity("RabbitRegister.Model.Order", b =>
                {
                    b.HasOne("RabbitRegister.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RabbitRegister.Model.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

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

            modelBuilder.Entity("RabbitRegister.Model.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
