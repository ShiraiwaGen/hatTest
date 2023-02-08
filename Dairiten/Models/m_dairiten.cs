using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class m_dairiten
    {
        public int id { get; set; }

        [DisplayName("代理店コード")]
        [Required]
        [StringLength(50, ErrorMessage = "代理店コードは５０文字以内でお願いします")]
        public string dairiten_code { get; set; } = null!;

        [DisplayName("代理店名")]
        [Required]
        [StringLength(50, ErrorMessage = "代理店名は５０文字以内でお願いします")]
        public string dairiten_mei { get; set; } = null!;

        [DisplayName("代理店手数料率")]
        [Required]
        public float dairiten_ritsu { get; set; }

        [DisplayName("電話番号")]
        [Required]
        [Phone]
        [StringLength(50, ErrorMessage = "電話番号は５０文字以内でお願いします")]
        public string dairiten_tel { get; set; } = null!;

        [DisplayName("ＦＡＸ番号")]
        [StringLength(50, ErrorMessage = "ＦＡＸ番号は５０文字以内でお願いします")]
        public string dairiten_fax { get; set; } = null!;

        [DisplayName("担当者")]
        [StringLength(50, ErrorMessage = "担当者は５０文字以内でお願いします")]
        public string dairiten_manager { get; set; } = null!;

        [DisplayName("郵便番号")]
        [Required]
        [StringLength(7, ErrorMessage = "郵便番号はハイフン（－）なしの数字７桁でお願いします")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public string dairiten_zip { get; set; } = null!;

        [DisplayName("所在地")]
        [StringLength(255, ErrorMessage = "所在地は２５５文字以内でお願いします")]
        public string dairiten_address { get; set; } = null!;

        [DisplayName("廃業区分")]
        //[RegularExpression(@"[0-9]+", ErrorMessage = "廃業区分は半角数字のみ入力できます")]
        //[Range(0, 1, ErrorMessage = "廃業区分は０か１でお願いします")]
        //public bool haigyo_kbn { get; set; } 
        public bool haigyo_kbn { get; set; }

        [DisplayName("精算")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "精算は半角数字のみ入力できます")]
        [Range(0, 1, ErrorMessage = "精算は０か１でお願いします")]
        public string seisan { get; set; } = null!;

        [DisplayName("都道府県コード")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "都道府県コードは半角数字のみ入力できます")]
        [StringLength(10, ErrorMessage = "都道府県コードは１０文字以内でお願いします")]
        public string todofuken_code { get; set; } = null!;

        [DisplayName("免許証番号")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "免許証番号は半角数字のみ入力できます")]
        [StringLength(10, ErrorMessage = "免許証番号は１０文字以内でお願いします")]
        public string license_no { get; set; } = null!;

        [DisplayName("免許証更新回数")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "免許証更新回数は半角数字のみ入力できます")]
        [StringLength(10, ErrorMessage = "免許証更新回数は１０文字以内でお願いします")]
        public string license_update { get; set; } = null!;

        [DisplayName("支店コード")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "支店コードは半角数字のみ入力できます")]
        [StringLength(10, ErrorMessage = "支店コードは３文字以内でお願いします")]
        public string dairiten_branch { get; set; } = null!;

        [DisplayName("ＦＡＸ送付")]
        public bool fax_kbn { get; set; }

        [DisplayName("代理店区分")]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "代理店区分は半角数字のみ入力できます")]
        [Range(1, 2, ErrorMessage = "代理店区分は１か２でお願いします")]
        public int dairiten_kbn { get; set; }

        [DisplayName("オンライン決済")]
        public bool online_payment { get; set; }

        [DisplayName("CSV出力")]
        public bool csv_kbn { get; set; }
    }
}
