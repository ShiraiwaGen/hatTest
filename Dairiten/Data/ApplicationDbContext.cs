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

        public DbSet<Dairiten.Models.t_keiyaku> t_keiyaku { get; set; }
        public DbSet<Dairiten.Models.t_bukken> t_bukken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<t_keiyaku>().ToTable("t_keiyaku");
            modelBuilder.Entity<t_bukken>().ToTable("t_bukken");
        }
    }
}