using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Dairiten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;

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

        public List<String> yukojotais = new List<String>();
        public List<String> seiritsujokyoes = new List<String>();
        public List<String> inputters = new List<String>();
        public List<String> shohins = new List<String>();
        public List<String> codes = new List<String>();
        public List<String> shukinhohoes = new List<String>();


        public IList<t_keiyaku> Keiyakus { get; set; }

        public string d_no, d_name, bnin_key;

        [BindProperty]
        public InputModel Input { get; set; }
        //�����p
        public class InputModel
        {
            public string yukojotai { get; set; }
            public string seiritsujokyo { get; set; }
            public string keiyakushameiKana { get; set; }
            public string keiyakushamei { get; set; }
            public string inputter { get; set; }
            public string shohin { get; set; }
            public string hihokenshameiKana { get; set; }
            public string hihokenshamei { get; set; }
            public string shoken_no { get; set; }
            public string hihokenshaAdd { get; set; }
            public string old_shoken_no { get; set; }
            public string hihokenshaTatemono { get; set; }
            public string boshuninCD { get; set; }
            public DateTime sakuseibi_From { get; set; }
            public DateTime sakuseibi_To { get; set; }
            public string code { get; set; }
            public DateTime hokenshiki_From { get; set; }
            public DateTime hokenshiki_To { get; set; }
            public string shukinhoho { get; set; }
        }

        public async Task OnGetAsync()
        {
            main_data();
        }

        public void OnPost()
        {
            var moshikomis = from k in _context.t_keiyaku select k;

            //�L�����
            int yukojotai_num = -1;
            if (Input.yukojotai != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 16))
                {
                    if (Input.yukojotai.Equals(master.item_name))
                    {
                        yukojotai_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.yukojotai == yukojotai_num);
            }

            //������
            int seiritsujokyo_num = -1;
            if (Input.seiritsujokyo != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 30))
                {
                    if (Input.seiritsujokyo.Equals(master.item_name))
                    {
                        seiritsujokyo_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.seiritsujokyo == seiritsujokyo_num);
            }

            //���͎ҋ敪
            int inputter_num = -1;
            if (Input.inputter != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 18))
                {
                    if (Input.inputter.Equals(master.item_name))
                    {
                        inputter_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.inputter_kbn == inputter_num);
            }

            //���i�敪
            int shohin_num = -1;
            if (Input.shohin != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 7))
                {
                    if (Input.shohin.Equals(master.item_name))
                    {
                        shohin_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.shohin_kbn == shohin_num);
            }

            //�،��ԍ�
            if (!string.IsNullOrEmpty(Input.shoken_no))
            {
                moshikomis = moshikomis.Where(k => k.shoken_no.Equals(Input.shoken_no));
            }

            //���،��ԍ�
            if (!string.IsNullOrEmpty(Input.old_shoken_no))
            {
                moshikomis = moshikomis.Where(k => k.old_shoken_no.Equals(Input.old_shoken_no));
            }

            //��W�l�R�[�h
            if (!string.IsNullOrEmpty(Input.boshuninCD))
            {
                var d = from e in _context.t_dairiten_employee
                        where e.employee_code == Input.boshuninCD
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
            int code_num = -1;
            if (Input.code != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 33))
                {
                    if (Input.code.Equals(master.item_name))
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
            int shukinhoho_num = -1;
            if (Input.shukinhoho != null)
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 13))
                {
                    if (Input.shukinhoho.Equals(master.item_name))
                    {
                        shukinhoho_num = master.item_no;
                        break;
                    }
                }
                moshikomis = moshikomis.Where(k => k.shukinhoho == shukinhoho_num);
            }

            //�_��Җ��J�i
            string search_KeiyakushameiKana = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["keiyakushameiKana"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_KeiyakushameiKana))
            {
                moshikomis = moshikomis.Where(k => (k.k_kana).Contains(search_KeiyakushameiKana));
            }

            //�_��Җ�����
            string search_Keiyakushamei = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["keiyakushamei"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_Keiyakushamei))
            {
                moshikomis = moshikomis.Where(k => (k.k_name).Contains(search_Keiyakushamei));
            }

            //��ی��Җ��J�i
            string search_HihokenshameiKana = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["hihokenshameiKana"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_HihokenshameiKana))
            {
                moshikomis = moshikomis.Where(k => (k.h_kana).Contains(search_HihokenshameiKana));
            }

            //��ی��Җ�����
            string search_Hihokenshamei = System.Text.RegularExpressions.Regex.Replace((string)Request.Form["hihokenshamei"], @"[\s]+", "");
            if (!string.IsNullOrEmpty(search_Hihokenshamei))
            {
                moshikomis = moshikomis.Where(k => (k.h_name).Contains(search_Hihokenshamei));
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

            //�\�����쐬��(From)
            if (Input.sakuseibi_From.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.moshikomisho_day >= Input.sakuseibi_From);
            }

            //�\�����쐬��(To)
            if (Input.sakuseibi_To.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.moshikomisho_day <= Input.sakuseibi_To);
            }

            //�ی��n��(From)
            if (Input.hokenshiki_From.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.hokenshiki >= Input.hokenshiki_From);
            }

            //�ی��n��(To)
            if (Input.hokenshiki_To.Date != DateTime.Parse("0001/01/01 00:00:00"))
            {
                moshikomis = moshikomis.Where(k => k.hokenshiki <= Input.hokenshiki_To);
            }

            Keiyakus = moshikomis.ToList();
        }

        public void main_data()
        {
            var pm = new Program(_context);
            string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            d_no = arr[0];
            d_name = arr[1];
            bnin_key = arr[2];

            //�L�����
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 16))
            {
                yukojotais.Add(item.item_name);
            }

            //������
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 30))
            {
                seiritsujokyoes.Add(item.item_name);
            }

            //���͎ҋ敪
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 18))
            {
                inputters.Add(item.item_name);
            }

            //���i�敪
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 7))
            {
                shohins.Add(item.item_name);
            }

            //�R�[�h
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 33))
            {
                codes.Add(item.item_name);
            }

            //�W�����@
            foreach (var item in _context.m_master.Where(m => m.m_master_kbn_id == 13))
            {
                shukinhohoes.Add(item.item_name);
            }
        }
    }
}
