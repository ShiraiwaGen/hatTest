using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Http;

namespace Dairiten.Pages.Sofuichiran_Kj
{
    [Authorize]
    public class Sofuichiran_KjModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;
        public Sofuichiran_KjModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            main_data();
        }

        public string d_no, d_name;
        public int d_id, bnin_id;
        public void main_data()
        {
            var pm = new Program(_context);
            string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            d_no = arr[0];
            d_name = arr[1];
            //bnin_no = arr[2];
            d_id = Int32.Parse(arr[3]);
            bnin_id = Int32.Parse(arr[4]);
        }

        [BindProperty]
        public InputModel Input { get; set; }

        //ŒŸõ—p
        public class InputModel
        {
            [DisplayName("‘—•t—\’èŒ")]
            [Required]
            [StringLength(10, ErrorMessage = "10•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            public string? sofuyoteizuki { get; set; }

            [DisplayName("‘—•tóˆóü“ú")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            public string sofu_start { get; set; }
            public string sofu_end { get; set; }

            [DisplayName("‘—•t‹æ•ª")]
            public string? sofu_kbn { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? b_address2 { get; set; }

            [DisplayName("‰ñû“ú")]
            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? kaishubi_start { get; set; }
            public string? kaishubi_end { get; set; }

            [DisplayName("ØŒ””Ô†")]
            public string? shoken_no { get; set; }

            [DisplayName("ØŒ””­s“ú")]
            public string? keiyakusho_hakkobi_start { get; set; }
            public string? keiyakusho_hakkobi_end { get; set; }
        }
    }
}
