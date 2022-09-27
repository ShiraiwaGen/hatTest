using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dairiten.Models
{
    public class t_seikyu
    {
        [DisplayName("請求キー")]
        public int id { get; set; }

        [DisplayName("請求書番号")]
        public int seikyu_no { get; set; }

        [DisplayName("払込手続状況")]
        [Required]
        public int haraikomi_kbn { get; set; }

        [DisplayName("計上日")]
        [Required]
        public DateTime keijobi { get; set; }

        [DisplayName("払込手続日")]
        [Required]
        public DateTime haraikomi_day { get; set; }

        [DisplayName("合計精算金額")]
        [Required]
        public int seisankingaku { get; set; }

        [DisplayName("代理店キー")]
        [Required]
        public int m_dairiten_id { get; set; }

        [DisplayName("募集人キー")]
        [Required]
        public int t_company_employee_id { get; set; }
    }
}
