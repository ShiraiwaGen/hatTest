using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class m_shohin
    {
        public int id { get; set; }
        [StringLength(10, ErrorMessage = "商品名は１０文字以内でお願いします")]
        [DisplayName("商品名")]
        public string shohin_name { get; set; }
        [DisplayName("保険料")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public int hokenryo { get; set; }
        [DisplayName("保険期間")]
        [Range(1, 2, ErrorMessage = "保険期間は１か２でお願いします")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public int hokenkikan { get; set; }

        //以降は保留

    }
}
