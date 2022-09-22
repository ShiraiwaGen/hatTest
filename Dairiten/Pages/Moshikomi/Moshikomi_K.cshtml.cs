using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Dairiten.Pages
{
    [Authorize]
    public class Moshikomi_KModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
