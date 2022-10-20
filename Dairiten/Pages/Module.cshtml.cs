using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Pages
{
    [Authorize]
    public class Index1Model_Model : PageModel
    {
        private static readonly Dairiten.Data.ApplicationDbContext _context;
        //public Index1Model_Model(Dairiten.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //代理店名、コード、募集人キー取得
        public static string[] Dairiten_Get()
        {
            //string currentUserId = User.Identity.GetUserId();
            string currentUserId = "ad97ccd7 - 77ad - 4130 - 95fe - b18f6a201239";
            string[] arr = new string[2];

            var nowData = from m in _context.m_dairiten
                          join t in _context.appUsers
                          on m.id equals t.m_dairiten_id
                          where t.Id == currentUserId
                          select new
                          {
                              d_no = m.dairiten_code,
                              d_name = m.dairiten_mei,
                              bnin_no = t.employee_code
                          };
            nowData.ToList();
            if (nowData != null)
            {
                foreach (var item in nowData)
                {

                    arr[0] = item.d_no;
                    arr[1] = item.d_name;
                    arr[2] = item.bnin_no;
                }
            }

            return arr;
        }

        public void OnGet()
        {
        }
    }
}
