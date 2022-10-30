using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public InputModel Input { get; set; }

        //ŒŸõ—p
        public class InputModel
        {
            [DisplayName("•¨Œ”Ô†")]
            [Required]
            [StringLength(10, ErrorMessage = "10•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            public string? bukken_no { get; set; }

            [DisplayName("—X•Ö”Ô†")]
            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”š‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            public string b_zip { get; set; }

            [DisplayName("ZŠi“s“¹•{Œ§s‹æ’¬‘ºj")]
            [Required]
            [StringLength(55, ErrorMessage = "ZŠi“s“¹•{Œ§s‹æ’¬‘ºj‚Í‚T‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? b_address1 { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? b_address2 { get; set; }

            [DisplayName("ZŠiŒš•¨–¼j")]
            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? b_address3 { get; set; }
            //public string? b_address4 { get; set; }
            //public string? b_address5 { get; set; }
            //public string? b_kodate { get; set; }
            //public string? d_code { get; set; }
        }
        //
        public class Bukken1
        {
            public int id { get; set; }
            public string? bukken_no { get; set; }
            public string? b_zip { get; set; }
            public string? b_address1 { get; set; }
            public string? b_address2 { get; set; }
            public string? b_address3 { get; set; }
            public string? b_address4 { get; set; }
            public string? b_address5 { get; set; }
            public int b_kodate { get; set; }
            public int m_dairiten_id { get; set; }
            public string? d_mei { get; set; }
        }
        //public List<t_bukken> mylist = new List<t_bukken>();
        public List<Bukken1> mylist = new List<Bukken1>();

        public string d_no, d_name;
        public int d_id, bnin_id;
        public void main_data()
        {
            var pm = new Program(_context);
            string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            //d_no = arr[0];
            //d_name = arr[1];
            //bnin_no = arr[2];
            d_id = Int32.Parse(arr[3]);
            //bnin_id = Int32.Parse(arr[4]);
        }

        public void OnPostHandle10()
        {
            main_data();

            //var mylist = _context.t_bukken
            //        .Where(x => x.m_dairiten_id == d_id)
            //        .OrderByDescending(x => x.bukken_no);

            //mylist = _context.t_bukken.ToList();
            //mylist.Join(
            //       _context.m_dairiten,
            //       t => t.m_dairiten_id,
            //       m => m.id,
            //       (t_bukken, m_dairiten) => new
            //       {
            //           t_bukken = t_bukken,
            //           d_mei = m_dairiten.dairiten_mei
            //       });

            //var mylist = from t in _context.t_bukken
            //             join m in _context.m_dairiten
            //             on t.m_dairiten_id equals m.id
            //             where t.m_dairiten_id == d_id
            //             orderby t.bukken_no
            //             select new
            //             {
            //                 t = t,
            //                 d_mei = m.dairiten_mei
            //             };

            //var mylist2 = (List<Bukken1>)(from t in _context.t_bukken
            //             join m in _context.m_dairiten
            //             on t.m_dairiten_id equals m.id
            //             where t.m_dairiten_id == d_id
            //             orderby t.bukken_no
            //             select new
            //             {
            //                id = t.id,
            //                bukken_no = t.bukken_no,
            //                b_zip = t.b_zip,
            //                b_address1 = t.b_address1,
            //                b_address2 = t.b_address2,
            //                b_address3 = t.b_address3,
            //                b_address4 = t.b_address4,
            //                b_address5 = t.b_address5,
            //                b_kodate = t.b_kodate,
            //                m_dairiten_id = t.m_dairiten_id,
            //                d_mei = m.dairiten_mei
            //             });
            
            var mylist2 = from t in _context.t_bukken
                          join m in _context.m_dairiten
                          on t.m_dairiten_id equals m.id
                          where t.m_dairiten_id == d_id
                          orderby t.bukken_no
                          select new
                          {
                              id = t.id,
                              bukken_no = t.bukken_no,
                              b_zip = t.b_zip,
                              b_address1 = t.b_address1,
                              b_address2 = t.b_address2,
                              b_address3 = t.b_address3,
                              b_address4 = t.b_address4,
                              b_address5 = t.b_address5,
                              b_kodate = t.b_kodate,
                              m_dairiten_id = t.m_dairiten_id,
                              d_mei = m.dairiten_mei
                          };

            if (Input.bukken_no != null)
            {
                mylist2 = mylist2.Where(t => t.bukken_no == Input.bukken_no);
            }
            if (Input.b_zip != null)
            {
                mylist2 = mylist2.Where(t => t.b_zip == Input.b_zip);
            }
            if (Input.b_address1 != null)
            {
                mylist2 = mylist2.Where(t => t.b_address1 == Input.b_address1);
            }
            if (Input.b_address2 != null)
            {
                mylist2 = mylist2.Where(t => t.b_address2 == Input.b_address2);
            }
            if (Input.b_address3 != null)
            {
                mylist2 = mylist2.Where(t => t.b_address3 == Input.b_address3);
            }
            //mylist.ToArray();

            //mylist = mylist2.ToList();

        }


    }
}
