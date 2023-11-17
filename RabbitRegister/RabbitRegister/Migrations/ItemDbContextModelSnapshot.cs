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
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("BreederRegNo");

                    b.ToTable("Breeders");
                });

            modelBuilder.Entity("RabbitRegister.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RabbitRegister.Model.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderLineId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("RabbitRegister.Model.Rabbit", b =>
                {
                    b.Property<int>("RabbitRegNo")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("OriginRegNo")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("CauseOfDeath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeadOrAlive")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IsForSale")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Owner")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SuitableForBreeding")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("RabbitRegNo", "OriginRegNo");

                    b.HasIndex("Owner");

                    b.ToTable("Rabbits");
                });

            modelBuilder.Entity("RabbitRegister.Model.Trimm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisposableWoolWeight")
                        .HasColumnType("int");

                    b.Property<int>("FirstSortmentWeight")
                        .HasColumnType("int");

                    b.Property<float?>("HairLengthByDayNinety")
                        .HasColumnType("real");

                    b.Property<int>("OriginRegNo")
                        .HasColumnType("int");

                    b.Property<int>("RabbitRegNo")
                        .HasColumnType("int");

                    b.Property<int>("SecondSortmentWeight")
                        .HasColumnType("int");

                    b.Property<int?>("TimeUsed")
                        .HasColumnType("int");

                    b.Property<float?>("WoolDensity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("RabbitRegNo", "OriginRegNo");

                    b.ToTable("Trimms");
                });

            modelBuilder.Entity("RabbitRegister.Model.Trimming", b =>
                {
                    b.Property<int>("TrimmingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrimmingId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisposableWoolWeight")
                        .HasColumnType("int");

                    b.Property<int>("FirstSortmentWeight")
                        .HasColumnType("int");

                    b.Property<float?>("HairLengthByDayNinety")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("OriginRegNo")
                        .HasColumnType("int");

                    b.Property<int>("RabbitRegNo")
                        .HasColumnType("int");

                    b.Property<int>("SecondSortmentWeight")
                        .HasColumnType("int");

                    b.Property<int?>("TimeUsed")
                        .HasColumnType("int");

                    b.Property<float?>("WoolDensity")
                        .HasColumnType("real");

                    b.HasKey("TrimmingId");

                    b.ToTable("Trimmings");
                });

            modelBuilder.Entity("RabbitRegister.Model.Wool", b =>
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

                    b.Property<string>("ImgString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Wools");
                });

            modelBuilder.Entity("RabbitRegister.Model.Yarn", b =>
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

                    b.Property<string>("Fiber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("NeedleSize")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tension")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Washing")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.ToTable("Yarns");
                });

            modelBuilder.Entity("RabbitRegister.Model.OrderLine", b =>
                {
                    b.HasOne("RabbitRegister.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RabbitRegister.Model.Rabbit", b =>
                {
                    b.HasOne("RabbitRegister.Model.Breeder", "Breeder")
                        .WithMany()
                        .HasForeignKey("Owner");

                    b.Navigation("Breeder");
                });

            modelBuilder.Entity("RabbitRegister.Model.Trimm", b =>
                {
                    b.HasOne("RabbitRegister.Model.Rabbit", "Rabbit")
                        .WithMany()
                        .HasForeignKey("RabbitRegNo", "OriginRegNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rabbit");
                });
#pragma warning restore 612, 618
        }
    }
}
