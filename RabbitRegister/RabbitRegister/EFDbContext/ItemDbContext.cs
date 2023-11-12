using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RabbitRegister.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System;

namespace RabbitRegister.EFDbContext
{
	public class ItemDbContext : DbContext
	{
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitRegisterDb; Integrated Security=True; Connect Timeout=30; Encrypt=False");
            options.UseSqlServer(@"Data Source = mssql5.unoeuro.com; Initial Catalog = db_angora_dk_db_rabbit_register; User ID = db_angora_dk; Password = Amb95z4gaGyBRD2ft3xe; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rabbit>()
            .HasKey(r => new { r.RabbitRegNo, r.OriginRegNo });
            modelBuilder.Entity<OrderLine>()
            .HasKey(o => new { o.OrderLineId, o.OrderId });
        }

        public DbSet<Wool> Wools { get; set; }
        public DbSet<Breeder> Breeders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Trimming> Trimmings { get; set; }
		public DbSet<Yarn> Yarns { get; set; }
		public DbSet<Rabbit> Rabbits { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
    }
}
