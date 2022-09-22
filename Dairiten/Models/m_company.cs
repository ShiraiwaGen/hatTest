using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dairiten.Models
{
    public class m_company
    {
        [DisplayName("保険会社名")]
        [Required]
        [StringLength(50, ErrorMessage = "保険会社名は５０文字以内でお願いします")]
        public string company_name { get; set; }

        [DisplayName("保険名称")]
        [Required]
        [StringLength(50, ErrorMessage = "保険名称は５０文字以内でお願いします")]
        public string insurance_name { get; set; }

        [DisplayName("事務所名")]
        [Required]
        [StringLength(50, ErrorMessage = "事務所名は５０文字以内でお願いします")]
        public string Office_name { get; set; }

        [DisplayName("事務所電話番号")]
        [Required]
        [Phone]
        [StringLength(50, ErrorMessage = "事務所電話番号は５０文字以内でお願いします")]
        public string Office_tel { get; set; }


        [DisplayName("受付開始時間")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime Office_start { get; set; }

        [DisplayName("受付終了時間")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime Office_end { get; set; }

        [DisplayName("営業日")]
        [Required]
        [StringLength(50, ErrorMessage = "営業日は５０文字以内でお願いします")]
        public string Office_day { get; set; }

        [DisplayName("金融機関")]
        [StringLength(50, ErrorMessage = "金融機関は５０文字以内でお願いします")]
        public string? bank { get; set; }

        [DisplayName("金融機関_支店")]
        [StringLength(50, ErrorMessage = "金融機関_支店は５０文字以内でお願いします")]
        public string? bank_shiten { get; set; }

        [DisplayName("口座種目")]
        [StringLength(10, ErrorMessage = "口座種目は1０文字以内でお願いします")]
        public string? bank_account_type { get; set; }

        [DisplayName("通帳記号")]
        [StringLength(50, ErrorMessage = "通帳記号は5０文字以内でお願いします")]
        public string? passbook_symbol { get; set; }

        [DisplayName("口座番号")]
        [StringLength(10, ErrorMessage = "口座番号は1０文字以内でお願いします")]
        public string? bank_account_no { get; set; }

        [DisplayName("口座名義人")]
        [StringLength(50, ErrorMessage = "口座名義人は5０文字以内でお願いします")]
        public string? bank_account_holder { get; set; }

        [DisplayName("口座名義人カナ")]
        [StringLength(50, ErrorMessage = "口座名義人カナは5０文字以内でお願いします")]
        public string? bank_account_holder_kana { get; set; }
    }
}
