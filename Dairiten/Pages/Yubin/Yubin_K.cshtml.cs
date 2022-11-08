using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dairiten.Pages.Yubin_K
{
    [Authorize]
    public class Yubin_KModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Yubin_KModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        private int clear_flg = 0;

        //ŒŸõ—p
        public class InputModel
        {
            public string target_kbn { get; set; }

            [DisplayName("—X•Ö”Ô†")]
            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”š‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            public string zipcode { get; set; }

            [DisplayName("ZŠ")]
            //[Required]
            //[StringLength(55, ErrorMessage = "ZŠ‚Í‚T‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? address_kanji { get; set; }

            [DisplayName("ZŠiƒJƒij")]
            //[StringLength(50, ErrorMessage = "ZŠiƒJƒij‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            public string? address_kana { get; set; }
        }
        //•\¦—p
        public class Yubin1
        {
            public int id { get; set; }
            public string? zipcode { get; set; }
            public string? address_kanji { get; set; }
            public string? address_kana { get; set; }
        }
        public List<Yubin1> mylist = new List<Yubin1>();           

        public void OnGet(string pflg)
        {
        }

        public void OnPostHandle10()
        {
            if(clear_flg == 1)
            {
                return;
            }

            var mylist2 = from y in _context.m_yubin
                          orderby y.zipcode
                          select new { 
                              id = y.id,
                              zipcode = y.zipcode,
                              address_kanji = y.prefectures + y.municipality + y.town,
                              address_kana = y.prefectures_kana + y.municipality_kana + y.town_kana
                          };

            if (Input.target_kbn != null)
            {
                if (Input.target_kbn == "1")
                {
                    if (Input.zipcode != null)
                    {
                        mylist2 = mylist2.Where(y => y.zipcode == Input.zipcode);
                    }
                }
                if (Input.target_kbn == "2")
                {
                    if (Input.address_kanji != null)
                    {
                        mylist2 = mylist2.Where(y => y.address_kanji.Contains(Input.address_kanji));
                    }
                }
                if (Input.target_kbn == "3")
                {
                    if (Input.address_kana != null)
                    {
                        mylist2 = mylist2.Where(y => y.address_kana.Contains(Input.address_kana));
                    }
                }
            }  
            mylist2.ToList();
            if (mylist2 != null)
            {
                foreach (var item in mylist2)
                {
                    mylist.Add(new Yubin1
                    {
                        id = item.id,
                        zipcode = item.zipcode,
                        address_kanji = item.address_kanji,
                        address_kana = item.address_kana,
                    });
                }
            }

        }

        public void OnPostHandle11()
        {
            clear_flg = 1;
            OnPostHandle10();
        }

        public void OnPostHandle12()
        {
            //\‰æ–Ê‚ÖpostH
        }
    }
}
