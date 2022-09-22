using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dairiten.Models;

namespace Dairiten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Dairiten.Models.m_dairiten> m_dairiten { get; set; } = default!;
        public DbSet<m_dairiten> m_dairiten { get; set; }
    }
}