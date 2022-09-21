using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class m_master_kbn
    {
        [DisplayName("マスター区分")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public int master_kbn { get; set; }
        [DisplayName("マスター区分名")]
        [Required]
        [StringLength(50, ErrorMessage = "マスター区分名は５０文字以内でお願いします")]
        public string master_kbn_name { get; set; }
    }
}
