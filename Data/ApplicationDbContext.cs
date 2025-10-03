using Microsoft.EntityFrameworkCore;
using CliqfyReportsService.Models;

namespace CliqfyReportsService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ordem> Ordens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configurar o modelo se necessário
            modelBuilder.Entity<Ordem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });
        }
    }
}