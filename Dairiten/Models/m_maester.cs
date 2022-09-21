using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class m_maester
    {
        [DisplayName("マスター区分")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        [Required]
        public int m_master_kbn_id { get; set; }
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        [DisplayName("サブ区分")]
        [Required]
        public int item_no { get; set; }
        [DisplayName("項目名")]
        [Required]
        [StringLength(50, ErrorMessage = "項目名は５０文字以内でお願いします")]
        public string item_name { get; set; }
    }
}
