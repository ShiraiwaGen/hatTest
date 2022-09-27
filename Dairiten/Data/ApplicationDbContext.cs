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
        public DbSet<Dairiten.Models.m_master> m_master { get; set; }
        public DbSet<Dairiten.Models.m_master_kbn> m_master_kbn { get; set; }
        public DbSet<Dairiten.Models.m_tax> m_tax { get; set; }
        public DbSet<Dairiten.Models.t_keiyaku> t_keiyaku { get; set; }
        public DbSet<Dairiten.Models.t_bukken> t_bukken { get; set; }
        public DbSet<Dairiten.Models.t_karibukken> t_karibukken { get; set; }
        public DbSet<Dairiten.Models.t_company_employee> t_company_employee { get; set; }
        public DbSet<Dairiten.Models.t_dairiten_employee> t_dairiten_employee { get; set; }
        public DbSet<Dairiten.Models.t_seikyu> t_seikyu { get; set; }
        public DbSet<Dairiten.Models.t_moshikomisho> t_moshikomisho { get; set; }
        public DbSet<Dairiten.Models.t_nayose> t_nayose { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<m_company>().ToTable("m_company");
            modelBuilder.Entity<m_shohin>().ToTable("m_shohin");
            modelBuilder.Entity<m_dairiten>().ToTable("m_dairiten");
            modelBuilder.Entity<m_master>().ToTable("m_master");
            modelBuilder.Entity<m_master_kbn>().ToTable("m_master_kbn");
            modelBuilder.Entity<m_tax>().ToTable("m_tax");
            modelBuilder.Entity<t_keiyaku>().ToTable("t_keiyaku");
            modelBuilder.Entity<t_bukken>().ToTable("t_bukken");
            modelBuilder.Entity<t_karibukken>().ToTable("t_karibukken");
            modelBuilder.Entity<t_company_employee>().ToTable("t_company_employee");
            modelBuilder.Entity<t_dairiten_employee>().ToTable("t_dairiten_employee");
            modelBuilder.Entity<t_seikyu>().ToTable("t_seikyu");
            modelBuilder.Entity<t_moshikomisho>().ToTable("t_moshikomisho");
            modelBuilder.Entity<t_nayose>().ToTable("t_nayose");
        }
    }
}

