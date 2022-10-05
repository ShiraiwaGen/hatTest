using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Pages
{
    [Authorize]
    public class Moshikomi_KjModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Moshikomi_KjModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<m_master> m_Master { get; set; }

        public IList<t_keiyaku> Keiyakus { get; set; }

        [BindProperty]
        public t_keiyaku data { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime sakuseibi_s { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime sakuseibi_e { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime hokenshiki_s { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime hokenshiki_e { get; set; }

        public async Task OnGetAsync()
        {
            m_Master = await _context.m_master.ToListAsync();
        }

        public void OnPost()
        {
            m_Master = _context.m_master.ToList();
            var moshikomis = from k in _context.t_keiyaku select k;

            int yukojotai_num = -1;       //�L�����
            int seiritsujokyo_num = -1;   //������
            int inputter_num = -1;        //���͎ҋ敪
            int shohin_num = -1;          //���i�敪
            int code_num = -1;            //�R�[�h
            int shukinhoho_num = -1;      //�W�����@

            //�L�����
            string yukojotai_selected = (string)Request.Form["yukojotai"];
            if (!string.IsNullOrEmpty(yukojotai_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 16))
                {
                    if (yukojotai_selected.Equals(master.item_name))
                    {
                        yukojotai_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.yukojotai == yukojotai_num);
            }

            //������
            string seiritsujokyo_selected = (string)Request.Form["seiritsujokyo"];
            if (!string.IsNullOrEmpty(seiritsujokyo_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 30))
                {
                    if (seiritsujokyo_selected.Equals(master.item_name))
                    {
                        seiritsujokyo_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.seiritsujokyo == seiritsujokyo_num);
            }

            //���͎ҋ敪
            string inputter_selected = (string)Request.Form["inputter"];
            if (!string.IsNullOrEmpty(inputter_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 18))
                {
                    if (inputter_selected.Equals(master.item_name))
                    {
                        inputter_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.inputter_kbn == inputter_num);
            }

            //���i�敪
            string shohin_selected = (string)Request.Form["shohin"];
            if (!string.IsNullOrEmpty(shohin_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 7))
                {
                    if (shohin_selected.Equals(master.item_name))
                    {
                        shohin_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.shohin_kbn == shohin_num);
            }

            //�،��ԍ�
            if (!string.IsNullOrEmpty(data.shoken_no))
            {
                moshikomis = moshikomis.Where(k => k.shoken_no.Equals(data.shoken_no));
            }

            //���،��ԍ�
            if (!string.IsNullOrEmpty(data.old_shoken_no))
            {
                moshikomis = moshikomis.Where(k => k.old_shoken_no.Equals(data.old_shoken_no));
            }

            //��W�l�R�[�h
            string search_boshuninCD = (string)Request.Form["boshuninCD"];
            if (!string.IsNullOrEmpty(search_boshuninCD))
            {
                var d = from e in _context.t_dairiten_employee
                        where e.employee_code == search_boshuninCD
                        select e.id;
                if (d.Count() > 0)
                { 
                    moshikomis = moshikomis.Where(k => k.employee_key == d.First());
                }
                else 
                {
                    moshikomis = moshikomis.Where(k => k.employee_key == -1);
                }
            }

            //�R�[�h
            string code_selected = (string)Request.Form["code"];
            if (!string.IsNullOrEmpty(code_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 33))
                {
                    if (code_selected.Equals(master.item_name))
                    {
                        code_num = master.item_no;
                        break;
                    }
                }
                if (moshikomis.Where(k => k.other_code1 == code_num).Count() > 0)
                { 
                    moshikomis = moshikomis.Where(k => k.other_code1 == code_num);
                }
                else if (moshikomis.Where(k => k.other_code2 == code_num).Count() > 0)
                {
                    moshikomis = moshikomis.Where(k => k.other_code2 == code_num);
                }
                else if (moshikomis.Where(k => k.other_code3 == code_num).Count() > 0)
                {
                    moshikomis = moshikomis.Where(k => k.other_code3 == code_num);
                }
                else
                {
                    moshikomis = moshikomis.Where(k => k.other_code3 == -1);
                }
            }

            //�W�����@
            string shukinhoho_selected = (string)Request.Form["shukinhoho"];
            if (!string.IsNullOrEmpty(shukinhoho_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 13))
                {
                    if (shukinhoho_selected.Equals(master.item_name))
                    {
                        shukinhoho_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.shukinhoho == shukinhoho_num);
            }

            //�_��Җ��J�i
            string search_KeiyakushameiKana = (string)Request.Form["keiyakushameiKana"];
            if (!string.IsNullOrEmpty(search_KeiyakushameiKana))
            {
                moshikomis = moshikomis.Where(k => (k.k_sei_kana + k.k_mei_kana).Contains(search_KeiyakushameiKana));
            }

            //�_��Җ�����
            string search_Keiyakushamei = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["keiyakushamei"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_Keiyakushamei))
            {
                moshikomis = moshikomis.Where(k => (k.k_sei + k.k_mei).Contains(search_Keiyakushamei));
            }

            //��ی��Җ��J�i
            string search_HihokenshameiKana = (string)Request.Form["hihokenshameiKana"];
            if (!string.IsNullOrEmpty(search_HihokenshameiKana))
            {
                moshikomis = moshikomis.Where(k => (k.h_sei_kana + k.h_mei_kana).Contains(search_HihokenshameiKana));
            }

            //��ی��Җ�����
            string search_Hihokenshamei = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["hihokenshamei"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_Hihokenshamei))
            {
                moshikomis = moshikomis.Where(k => (k.h_sei + k.h_mei).Contains(search_Hihokenshamei));
            }

            //��ی��ҏZ��
            string search_HihokenshaAdd = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["hihokenshaAdd"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_HihokenshaAdd))
            {
                moshikomis = moshikomis.Where(k => (k.h_address1 + k.h_address2).Contains(search_HihokenshaAdd));
            }

            //��ی��Ҍ�����
            string search_HihokenshaTatemono = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["hihokenshaTatemono"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_HihokenshaTatemono))
            {
                moshikomis = moshikomis.Where(k => k.h_address3.Contains(search_HihokenshaTatemono));
            }

            //�\�����쐬��(Start)
            if (sakuseibi_s.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.moshikomisho_day >= sakuseibi_s);
            }

            //�\�����쐬��(End)
            if (sakuseibi_e.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.moshikomisho_day <= sakuseibi_e);
            }

            //�ی��n��(Start)
            if (hokenshiki_s.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.hokenshiki >= hokenshiki_s);
            }

            //�ی��n��(End)
            if (hokenshiki_e.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.hokenshiki <= hokenshiki_e);
            }

            Keiyakus = moshikomis.ToList();
        }
    }
}
