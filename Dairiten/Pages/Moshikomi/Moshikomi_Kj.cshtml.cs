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
            //���i�敪

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
            //�R�[�h
            //�W�����@

            //�_��Җ��J�i
            string keiyakushameiKana_selected = (string)Request.Form["keiyakushameiKana"];
            if (!string.IsNullOrEmpty(keiyakushameiKana_selected))
            {
                moshikomis = moshikomis.Where(k => (k.k_sei_kana + k.k_mei_kana).Equals(keiyakushameiKana_selected));
            }

            Keiyakus = moshikomis.ToList();
        }
    }
}
