using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class t_nayose
    {
        [DisplayName("名寄せキー")]
        public int id { get; set; }

        [DisplayName("契約キー")]
        [Required]
        public int t_keiyaku_id { get; set; }

        [DisplayName("名寄せ状況")]
        [Required]
        public int nayose_kbn { get; set; }

        [DisplayName("エラー発生日時")]
        [Required]
        public DateTime error_datetime { get; set; }

        [DisplayName("名寄せ処理日時")]
        [Required]
        public DateTime shori_datetime { get; set; }

        [DisplayName("理由備考")]
        [StringLength(100, ErrorMessage = "理由備考は１００文字以内でお願いします")]
        public string riyu { get; set; }

        [DisplayName("募集人キー")]
        [Required]
        public int t_company_employee_id { get; set; }

        [DisplayName("名寄せエラー区分")]
        [Required]
        public int nayose_error_kbn { get; set; }
    }
}
