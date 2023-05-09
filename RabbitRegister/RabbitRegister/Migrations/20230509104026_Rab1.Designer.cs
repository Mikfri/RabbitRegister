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
    [Migration("20230509104026_Rab1")]
    partial class Rab1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
#pragma warning restore 612, 618
        }
    }
}
