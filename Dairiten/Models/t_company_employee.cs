using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class t_company_employee
    {
        [DisplayName("保険会社社員キー")]
        public int id { get; set; }

        [DisplayName("社員コード")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "社員コードは半角英数字のみ入力できます")]
        [StringLength(10, ErrorMessage = "社員コードは１０文字以内でお願いします")]
        public string employee_code { get; set; } = null!;

        [DisplayName("社員_姓")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_姓は５０文字以内でお願いします")]
        public string employee_sei { get; set; } = null!;

        [DisplayName("社員_名")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_名は５０文字以内でお願いします")]
        public string employee_mei { get; set; } = null!;

        [DisplayName("パスワード")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9 -/:-@\[-\`\{-\~]+", ErrorMessage = "半角英数字記号のみ入力できます")]
        [StringLength(10, ErrorMessage = "パスワードは１０文字以内でお願いします")]
        public string employee_pass { get; set; } = null!;

        public DateTime pass_day { get; set; }
        public bool employee_del { get; set; }

    }
}
