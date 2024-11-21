using Microsoft.EntityFrameworkCore;
using EcoSmart.Model;

namespace EcoSmart.Persistencia
{
    public class EcoSmartDbContext : DbContext
    {
        public EcoSmartDbContext(DbContextOptions<EcoSmartDbContext> options) : base(options) { }

        public DbSet<EnergyRecord> EnergyRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergyRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DeviceId).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
            });
        }
    }
}
