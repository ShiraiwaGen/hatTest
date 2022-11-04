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

        //検索用
        public class InputModel
        {
            [DisplayName("送付予定月")]
            [Required]
            [StringLength(10, ErrorMessage = "10文字以内でお願いします")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string? sofuyoteizuki { get; set; }

            [DisplayName("送付状印刷日")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string sofu_start { get; set; }
            public string sofu_end { get; set; }

            [DisplayName("送付区分")]
            public string? sofu_kbn { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
            public string? b_address2 { get; set; }

            [DisplayName("回収日")]
            [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
            public string? kaishubi_start { get; set; }
            public string? kaishubi_end { get; set; }

            [DisplayName("証券番号")]
            public string? shoken_no { get; set; }

            [DisplayName("証券発行日")]
            public string? keiyakusho_hakkobi_start { get; set; }
            public string? keiyakusho_hakkobi_end { get; set; }
        }
    }
}
