using Dairiten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Pages
{
    public class Moshikomi_InModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Moshikomi_InModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<m_shohin> m_Shohin { get; set; }
        public IList<m_master> m_Master { get; set; }
        public async Task OnGetAsync()
        {
            m_Shohin = await _context.m_shohin.ToListAsync();
            m_Master = await _context.m_master.ToListAsync();
        }
        public void OnPost()
        {

        }
    }
}
