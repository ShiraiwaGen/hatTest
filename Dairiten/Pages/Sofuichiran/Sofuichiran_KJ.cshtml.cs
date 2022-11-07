using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Http;
using Microsoft.CodeAnalysis.Options;
using Dairiten.Models;

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

        //public IList<t_keiyaku> Keiyakus { get; set; }
        //public IList<m_master> m_Master { get; set; }
        //public string[] sofu_kbns;
        public List<String> sofu_kbns = new List<String>();
        private String error_msg { get; set; } = "";

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

            //送付区分
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 26))
            {
                sofu_kbns.Add(item.item_name);
            }
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
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string sofu_start { get; set; }
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string sofu_end { get; set; }

            [DisplayName("送付区分")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string? sofu_kbn { get; set; }

            [DisplayName("回収日")]
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string? kaishubi_start { get; set; }
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string? kaishubi_end { get; set; }

            [DisplayName("証券番号")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string? shoken_no { get; set; }

            [DisplayName("証券発行日")]
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string? keiyakusho_hakkobi_start { get; set; }
            [DataType(DataType.Date, ErrorMessage = "日付で入力してください。")]
            public string? keiyakusho_hakkobi_end { get; set; }
        }
        //表示用
        public class Bukken1
        {
            public int keiyaku_id { get; set; }
            public string? shoken_no { get; set; }

            public int dairitem_id { get; set; }
            public int dairiten_code { get; set; }
            public string? dairiten_mei { get; set; }
            public int employee_id { get; set; }
            public string? employee_mei { get; set; }   //sei+mei
            public string? keiyakusha_mei { get; set; }  //sei+mei
            public string? hihokensha_mei { get; set; }  //sei+mei


            public int sofu_kbn { get; set; }
            public DateOnly sofuyoteizuki { get; set; }

        }

            public void OnPost()
        {
            error_msg = "";

            var moshikomis = from k in _context.t_keiyaku select k;

            //送付予定月
            if (Input.sofuyoteizuki == null)
            {
                error_msg = "送付予定月を入力してください。";
                return;
            }
            else
            {
                moshikomis = moshikomis.Where(k => k.sofuyoteizuki.ToString("yyyy/MM") == Input.sofuyoteizuki);
            }

            //送付状印刷日
            if (Input.sofu_start != null)
            {
                //moshikomis = moshikomis.Where(k => k.sofu_day) == Input.sofuyoteizuki);
            }

            //送付区分
            int sofu_kbn_num = -1;
            if (Input.sofu_kbn != null) { 
                string sofu_kbn_selected = Input.sofu_kbn;

                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 26))
                {
                    if (sofu_kbn_selected.Equals(master.item_name))
                    {
                        sofu_kbn_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.sofu_kbn == sofu_kbn_num);
            }

            //Keiyakus = moshikomis.ToList();
        }
    }
}
