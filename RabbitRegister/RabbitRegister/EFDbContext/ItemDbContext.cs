using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using RabbitRegister.Model;

namespace RabbitRegister.EFDbContext
{
	public class ItemDbContext : DbContext
	{
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitRegisterDb; Integrated Security=True; Connect Timeout=30; Encrypt=False");
            //options.UseSqlServer(@"Data Source = mssql5.unoeuro.com; Initial Catalog = db_angora_dk_db_rabbit_register; User ID = db_angora_dk; Password = Amb95z4gaGyBRD2ft3xe; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rabbit>()
            .HasKey(r => new { r.RabbitRegNo, r.OriginRegNo });

            //modelBuilder.Entity<Rabbit>()
            //    .HasOne(r => r.Breeder)
            //    .WithMany(b => b.Rabbits)  
            //    .HasForeignKey(r => new { r.Owner });  
                     
            modelBuilder.Entity<OrderLine>()
            .HasKey(o => new { o.OrderLineId, o.OrderId });


            //modelBuilder.Entity<Trimm>()
            //.HasKey(t => t.Id);  // Dette angiver primærnøglen for Trimming

            //modelBuilder.Entity<Trimm>()
            //    .HasOne(t => t.Rabbit)       // Dette angiver relationen til Rabbit
            //    .WithMany(r => r.Trimms)   // En Rabbit kan have mange Trimmings
            //    .HasForeignKey(t => new { t.RabbitRegNo, t.OriginRegNo });  // Angiver fremmednøgleforholdet
        }

        public DbSet<Wool> Wools { get; set; }
        public DbSet<Breeder> Breeders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Trimming> Trimmings { get; set; }
		public DbSet<Yarn> Yarns { get; set; }
		public DbSet<Rabbit> Rabbits { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Trimm> Trimms { get; set; }

    }
}
