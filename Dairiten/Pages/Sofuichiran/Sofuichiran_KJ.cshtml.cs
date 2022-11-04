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

        //�����p
        public class InputModel
        {
            [DisplayName("���t�\�茎")]
            [Required]
            [StringLength(10, ErrorMessage = "10�����ȓ��ł��肢���܂�")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            public string? sofuyoteizuki { get; set; }

            [DisplayName("���t������")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            public string sofu_start { get; set; }
            public string sofu_end { get; set; }

            [DisplayName("���t�敪")]
            public string? sofu_kbn { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "�Z���i���ڔԒn�j�͂Q�T�����ȓ��ł��肢���܂�")]
            public string? b_address2 { get; set; }

            [DisplayName("�����")]
            [StringLength(50, ErrorMessage = "�Z���i�������j�͂T�O�����ȓ��ł��肢���܂�")]
            public string? kaishubi_start { get; set; }
            public string? kaishubi_end { get; set; }

            [DisplayName("�،��ԍ�")]
            public string? shoken_no { get; set; }

            [DisplayName("�،����s��")]
            public string? keiyakusho_hakkobi_start { get; set; }
            public string? keiyakusho_hakkobi_end { get; set; }
        }
    }
}
