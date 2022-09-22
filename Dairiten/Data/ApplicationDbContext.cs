using Dairiten.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dairiten.Models.m_company> m_company { get; set; }
        public DbSet<Dairiten.Models.m_shohin> m_shohin { get; set; }
        public DbSet<Dairiten.Models.m_dairiten> m_dairiten { get; set; }
        public DbSet<Dairiten.Models.t_keiyaku> t_keiyaku { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<m_company>().ToTable("m_company");
            modelBuilder.Entity<m_shohin>().ToTable("m_shohin");
            modelBuilder.Entity<m_dairiten>().ToTable("m_dairiten");
            modelBuilder.Entity<t_keiyaku>().ToTable("t_keiyaku");            
        }
    }
}