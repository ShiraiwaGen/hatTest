using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Pages
{
    [Authorize]
    public class Bukken_KModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Bukken_KModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public t_bukken t_bukken { get; set; }

        


    }
}
