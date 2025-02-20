﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RabbitRegister.Migrations
{
    /// <inheritdoc />
    public partial class RabbitReg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeders",
                columns: table => new
                {
                    BreederRegNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeders", x => x.BreederRegNo);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    RecipientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Trimmings",
                columns: table => new
                {
                    TrimmingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RabbitRegNo = table.Column<int>(type: "int", nullable: false),
                    OriginRegNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeUsed = table.Column<int>(type: "int", nullable: true),
                    HairLengthByDayNinety = table.Column<float>(type: "real", nullable: true),
                    WoolDensity = table.Column<float>(type: "real", nullable: true),
                    FirstSortmentWeight = table.Column<int>(type: "int", nullable: false),
                    SecondSortmentWeight = table.Column<int>(type: "int", nullable: false),
                    DisposableWoolWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trimmings", x => x.TrimmingId);
                });

            migrationBuilder.CreateTable(
                name: "Wools",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    ImgString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreederRegNo = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wools", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Yarns",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fiber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeedleSize = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Tension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Washing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImgString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreederRegNo = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yarns", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Rabbits",
                columns: table => new
                {
                    RabbitRegNo = table.Column<int>(type: "int", nullable: false),
                    OriginRegNo = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    DeadOrAlive = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    IsForSale = table.Column<int>(type: "int", nullable: true),
                    SuitableForBreeding = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rabbits", x => new { x.RabbitRegNo, x.OriginRegNo });
                    table.ForeignKey(
                        name: "FK_Rabbits_Breeders_Owner",
                        column: x => x.Owner,
                        principalTable: "Breeders",
                        principalColumn: "BreederRegNo");
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => new { x.OrderLineId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderLines_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trimms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RabbitRegNo = table.Column<int>(type: "int", nullable: false),
                    OriginRegNo = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeUsed = table.Column<int>(type: "int", nullable: true),
                    HairLengthByDayNinety = table.Column<float>(type: "real", nullable: true),
                    WoolDensity = table.Column<float>(type: "real", nullable: true),
                    FirstSortmentWeight = table.Column<int>(type: "int", nullable: false),
                    SecondSortmentWeight = table.Column<int>(type: "int", nullable: false),
                    DisposableWoolWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trimms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trimms_Rabbits_RabbitRegNo_OriginRegNo",
                        columns: x => new { x.RabbitRegNo, x.OriginRegNo },
                        principalTable: "Rabbits",
                        principalColumns: new[] { "RabbitRegNo", "OriginRegNo" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rabbits_Owner",
                table: "Rabbits",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_Trimms_RabbitRegNo_OriginRegNo",
                table: "Trimms",
                columns: new[] { "RabbitRegNo", "OriginRegNo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Trimmings");

            migrationBuilder.DropTable(
                name: "Trimms");

            migrationBuilder.DropTable(
                name: "Wools");

            migrationBuilder.DropTable(
                name: "Yarns");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Rabbits");

            migrationBuilder.DropTable(
                name: "Breeders");
        }
    }
}
