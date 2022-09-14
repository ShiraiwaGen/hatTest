using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Dairiten.Pages
{
    [Authorize]
    public class MoshikomikensakuModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
