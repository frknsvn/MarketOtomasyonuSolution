using Microsoft.EntityFrameworkCore;
using MarketOtomasyonu.Alan.Modeller;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MarketOtomasyonu.Kalici
{
    public class AppDbContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
