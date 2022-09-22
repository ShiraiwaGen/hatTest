using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Dairiten.Pages
{
    [Authorize]
    public class Keiyaku_KjModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
