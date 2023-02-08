using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dairiten.Models
{
    public class t_moshikomisho
    {
        [DisplayName("申込書送付状キー")]
        public int id { get; set; }

        [DisplayName("送付予定月")]
        [Required]
        public string sofuyoteizuki { get; set; } = null!;

        [DisplayName("送付区分")]
        [Required]
        public int sofu_kbn { get; set; }

        [DisplayName("送付状印刷日")]
        [Required]
        public int sofu_day { get; set; }

        [DisplayName("募集人キー")]
        [Required]
        public int t_dairiten_employee_id { get; set; }

        [ForeignKey("t_seikyu")]
        [DisplayName("請求キー")]
        public int t_seikyu_id { get; set; }
    }
}
