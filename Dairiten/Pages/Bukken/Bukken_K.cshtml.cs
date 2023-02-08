using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Dairiten.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dairiten.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public InputModel Input { get; set; } = null!;
        [BindProperty]
        public string pageFlg { get; set; } = null!;

        private int clear_flg = 0;

        //検索用
        public class InputModel
        {
            [DisplayName("物件番号")]
            [Required]
            [StringLength(10, ErrorMessage = "10文字以内でお願いします")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string? bukken_no { get; set; } = null!;

            [DisplayName("郵便番号")]
            [Required]
            [StringLength(7, ErrorMessage = "郵便番号はハイフン（−）なしの数字７桁でお願いします")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            public string b_zip { get; set; } = null!;

            [DisplayName("住所（都道府県市区町村）")]
            [Required]
            [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
            public string? b_address1 { get; set; } = null!;

            [Required]
            [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
            public string? b_address2 { get; set; } = null!;

            [DisplayName("住所（建物名）")]
            [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
            public string? b_address3 { get; set; } = null!;
            //public string? b_address4 { get; set; }
            //public string? b_address5 { get; set; }
            //public string? b_kodate { get; set; }
            //public string? d_code { get; set; }
        }
        //
        public class Bukken1
        {
            public int id { get; set; }
            public string? bukken_no { get; set; } = null!;
            public string? b_zip { get; set; } = null!;
            public string? b_address1 { get; set; } = null!;
            public string? b_address2 { get; set; } = null!;
            public string? b_address3 { get; set; } = null!;
            public string? b_address4 { get; set; } = null!;
            public string? b_address5 { get; set; } = null!;
            public string? b_kodate { get; set; } = null!;
            public int m_dairiten_id { get; set; }
            public string? dairiten_code { get; set; } = null!;
            public string? d_mei { get; set; } = null!;
        }
        //public List<t_bukken> mylist = new List<t_bukken>();
        public List<Bukken1> mylist = new List<Bukken1>();

        public string d_no = null!;
        public string d_name = null!;
        public int d_id, bnin_id;
        public void main_data()
        {
            var pm = new Program(_context);
            //string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            //var employeeCode = HttpContext.Session.GetString("employee_code");

            var ap = new AppUser();
            var employeeCode = ap.Id;

            if (employeeCode != null)
            {
                string[] arr = pm.Dairiten_Get(employeeCode);
                //d_no = arr[0];
                //d_name = arr[1];
                //bnin_no = arr[2];
                d_id = Int32.Parse(arr[3]);
                //bnin_id = Int32.Parse(arr[4]);
            }

        }

        public void OnGet(string pflg)
        {
            pageFlg = pflg;
        }

        public void OnPostHandle10()
        {
            main_data();

            if(clear_flg == 1)
            {
                return;
            }

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
                              dairiten_code = m.dairiten_code,
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
                mylist2 = mylist2.Where(t => t.b_address1.Contains(Input.b_address1));
            }
            if (Input.b_address2 != null)
            {
                mylist2 = mylist2.Where(t => t.b_address2.Contains(Input.b_address2));
            }
            if (Input.b_address3 != null)
            {
                mylist2 = mylist2.Where(t => t.b_address3.Contains(Input.b_address3));
            }
            //mylist.ToArray();

            //mylist = mylist2.ToList();       
            mylist2.ToList();
            if (mylist2 != null)
            {
                var kodateArray = from m in _context.m_master
                                  where m.m_master_kbn_id == 35
                                  select new { name = m.item_name };
                kodateArray.ToList();
                int i = 0;
                string[] kodate = new string[2];
                foreach (var item in kodateArray)
                {
                    kodate[i] = item.name;
                    i++;
                }

                foreach (var item in mylist2)
                {
                    mylist.Add(new Bukken1
                    {
                        id = item.id,
                        bukken_no = item.bukken_no,
                        b_zip = item.b_zip,
                        b_address1 = item.b_address1,
                        b_address2 = item.b_address2,
                        b_address3 = item.b_address3,
                        b_address4 = item.b_address4,
                        b_address5 = item.b_address5,
                        b_kodate = kodate[item.b_kodate],
                        m_dairiten_id = item.m_dairiten_id,
                        dairiten_code = item.dairiten_code,
                        d_mei = item.d_mei
                    });
                }
            }

        }

        public void OnPostHandle11()
        {
            clear_flg = 1;
            OnPostHandle10();
        }
    }
}
